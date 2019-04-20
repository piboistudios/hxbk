package hxbk.storage;

using hxbk.StorageTools;

import hxbk.operations.Result;
import hxbk.storage.*;
import hxbk.concurrency.*;
import hxbk.operations.Create;
using hxbk.IteratorTools;
using Lambda;
using haxe.Json;

import tink.core.Error.ErrorCode;
import haxe.io.Bytes;
import haxe.ds.BalancedTree;
import tink.CoreApi;
import sys.*;
import sys.io.*;

class Book {
	var dirtyPages:Map<Int, Page> = [];
	public var name(default, null):String;
	public var pageSize:Int;
	public var file(get, never):String;
	var _stat:FileStat;

	public function get_file() {
		Engine.ensure();
		return './${Engine.path}/$name.hxbk';
	}

	public var stat(get, never):FileStat;

	public function get_stat() {
		ensure();
		if(_stat == null) _stat = FileSystem.stat(file);
		return _stat;
	}

	public var size(get, never):Int;

	public function get_size() {
		return stat.size;
	}

	public var pages(get, never):Int;

	public function get_pages() {
		return Std.int(size / pageSize);
	}

	function ensure() {
		if (!FileSystem.exists(file)) {
			var output = File.write(file, true);
			output.writeString('');
			output.flush();
			output.close();
		}
	}

	function new(n:String) {
		name = n;
	}

	public static function open(name:String) {
		var book = @:privateAccess new Book(name);
		book.ensure();
		book.pageSize = Engine.config.book.pageSize;
		return book;
	}

	function createPage() {
		var newPage = new Page(this);
		@:privateAccess newPage.setNumber(-1);
		return newPage;
	}

	public function getFreePage():Future<Page> {
		for (pageNo in 0...pages) {
			if (!SharedAccess.locked('book-$name-page-$pageNo')) {
				return read(pageNo);
			}
		}

		return createPage();
	}

	var serializationHooks:Array<Bytes->Bytes> = [];
	var deserializationHooks:Array<Bytes->Bytes> = [];

	@:noCompletion public dynamic function postSerialization(_b:Bytes) {
		var b = _b;
		for (hook in serializationHooks) {
			b = hook(b);
		}
		return b;
	}

	@:noCompletion public dynamic function preDeserialization(_b:Bytes) {
		var b = _b;
		for (hook in deserializationHooks) {
			b = hook(b);
		}
		return b;
	}

	public function addStoragePlan(serialize:Bytes->Bytes, deserialize:Bytes->Bytes) {
		serializationHooks.push(serialize);
		deserializationHooks.insert(0, deserialize);
	}

	public function write(page:Page) {
		var done = Future.trigger();
		trace('Beginning write: ${page.number}');

		SharedAccess.acquire('book-$name-page-${page.number}').handle(unlock -> {
			if (page.number.value == -1) {
				@:privateAccess page.setNumber(pages);
				var appendStream = File.append(file, true);
				appendStream.write(Bytes.alloc(pageSize));
				appendStream.flush();
				appendStream.close();
			}
			var stream = File.update(file, true);
			stream.seek(page.number.value * pageSize, FileSeek.SeekBegin);
			stream.writeInt16(page.bytes.length);
			stream.write(page.bytes);
			stream.flush();
			stream.close();
			_stat = null;
			trace("Wrote " + page.number);
			done.trigger(Noise);
			unlock();
		});
		return done.asFuture();
	}

	public function read(pageNo:Int) {
		trace('reading page: $pageNo');
		if(dirtyPages.exists(pageNo)) {
			return Future.sync(dirtyPages[pageNo]);
		}
		var done = Future.trigger();
		SharedAccess.acquire('book-$name-page-${pageNo}').handle(unlock -> {
			var read = File.read(file, true);
			read.seek(pageNo * pageSize, FileSeek.SeekBegin);
			var length = read.readInt16();
			var pageBytes = read.read(length);
			if (pageBytes.length > 0) {
				var page:Page = Serializer.deserialize(pageBytes, preDeserialization);
				@:privateAccess page.setNumber(pageNo);
				@:privateAccess page.book = this;
				done.trigger(page);
			} else {
				done.trigger(null);
			}
			read.close();
			unlock();
		});
		return done.asFuture();
	}

	public function peek(pageNo:Int):Int {
		trace('peek');
		var read = File.read(file, true);
		read.seek(pageNo * pageSize, FileSeek.SeekBegin);
		var size = read.readInt16();
		read.close();
		trace('done peeking $size');
		if (size == 0)
			return 0;
		else
			return size + 2;
	}
	public function peekAll():Array<Int> {
		var read = File.read(file, true);
		var result = [];
		for(i in 0...pages) {
			if(!dirtyPages.exists(i)) {

			read.seek(i * pageSize, FileSeek.SeekBegin);
			result.push(read.readInt16());
			} else {
				result.push(dirtyPages[i].size);
			}
		}
		read.close();
		return result;
	}

	public function count(listener:SignalTrigger<Int>) {
		var limit = pages;
		for(i in 0...pages) {
			read(i).handle(page -> {
				listener.trigger(page.records.count());
				trace('Got ${page.records.count()} (limit: ${limit}/${pages})');
			});
		}
		return limit;
	}

	public function commit() {
		return Promise.inSequence([for (key in dirtyPages.keys()) key].map(key -> dirtyPages.get(key)).map(page -> {
			return cast(write(page).map(Success));	
		})).flatMap(results -> {
			var keys = dirtyPages.keys();
			for (key in keys) {
				dirtyPages.get(key).cleanse();
			}
			
			dirtyPages = [];
			return Noise;
		});
	}

	public function create(records:Array<Record>, emitter:SignalTrigger<CreateResult>, ?depth:Int = 0, ?owner = 0, ?id = 0) {
		// trace('create: $depth');
		// trace('Create: ${records.length}');
		var emit = result -> {
			emitter.trigger(result);
			// trace('result: $result, $depth');
			// trace(haxe.CallStack.toString(haxe.CallStack.callStack().slice(0,2)));
		};
		var result = page -> ({depth: depth, page: page, owner: owner, id:id});
		if (records == null || records.length == 0) {
			emit(result(null));
			return;
		}
		var done = false;
		var reverse = Std.random(2) == 1;
		var sizes = peekAll();
		var recordTree = new BalancedTree<Int, Record>();
		var index = 0;
		records.iter(record -> {
			recordTree.set(index++, record);
		});
		var recordSize = recordTree.size();
		var a = (0...pages).toArray();
		var greatestAvailability = 0;
		// trace('a: $a, $sizes, $recordSize');
		for (pageNo in a) {
			if (sizes[pageNo] + recordSize < pageSize && !SharedAccess.locked('book-$name-page-$pageNo')) {
				trace('Fits $pageNo');
				read(pageNo).handle(page -> {
					if (page.create(records)) {
						emit(result(page));
						done = true;
					} else {
						throw 'This should never happen. (${haxe.Json.stringify({sizes: sizes, pageNo: pageNo, pageSize: page.size, recordSize: recordSize})})';
					}
				});
				return;
			} else {
				if(sizes[pageNo] - recordSize > greatestAvailability) greatestAvailability = sizes[pageNo] - recordSize;
				// if(pageNo == pages - 1) trace("Records could not fit any pages.");
				// trace('Records cannot fit: ${records.size()}/$pageSize');
			}
		}
		
		var newPage = createPage();
		// if(recordSize < pageSize) trace('try new page');
		// trace('Splitting');	
		if (recordSize < pageSize &&  (recordSize / 2 > greatestAvailability) && newPage.create(records)) {
			// trace('Fits new page');
			emit(result(newPage));

			return;
		} else {
			var overflowFactor = Std.int((recordSize / pageSize) / 2) + 1;
			// trace('overgrowth factor: $overflowFactor');
			var segments:Array<Array<Record>> = (0...Std.int(Math.min(overflowFactor, 5))).toArray().fold((current, aggregate:Array<Dynamic>) -> {
				var tmpAggregate = [];
				for(array in aggregate) {
					var middle = Std.int(array.length / 2);
					var a:Array<Record> = middle > 0 ? array.slice(0, middle) : array;
					var b:Array<Record> = middle > 0 ? array.slice(middle, array.length) : [];
					if(a.length != 0) tmpAggregate.push(a);
					if(b.length != 0) tmpAggregate.push(b);
					// trace('tmpAggregate: ${tmpAggregate.length}');
				}
				return tmpAggregate;
			},[records]);
			// if(segments.length > 1)trace('Segments: ${haxe.Json.stringify(segments.map(segment -> segment.length))}');
			var done = [];
			for(segment in segments) {
				// trace('CREATE SEGMENT');
				
				create(segment, emitter, segment == segments[segments.length-1] ? depth : depth + 1, id, IdGen.getId());
			}
			// if(depth == 0)
			// emitter.asSignal().handle(result -> {
			// 	if(result.owner == id) {
			// 		done.push(result.depth);
			// 		trace('Completed: ${result}');
			// 		commit();
			// 	}
			// 	if(done.length == segments.length) {
			// 		trace('Done with depth: $depth');
			// 		result.depth = depth;
			// 	}
			// 	trace('${done.length}/${segments.length}, ${result.owner}/${id}');
			// 	emit(result);
			// });
			// trace('Couldnt fit records, splitting: ${haxe.Json.stringify({recordSize: records.size(), aSize: a.size(), bSize: b.size()})}');
			return;
		}
	}

}