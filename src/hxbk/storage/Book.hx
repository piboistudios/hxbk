package hxbk.storage;
import hxbk.storage.*;
import hxbk.concurrency.*;
import hxbk.operations.*;
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

	public function get_file() {
		Engine.ensure();
		return './${Engine.path}/$name.hxbk';
	}

	public var stat(get, never):FileStat;

	public function get_stat() {
		ensure();
		return FileSystem.stat(file);
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

	public function write(page:Page) {
		var done = Future.trigger();
		SharedAccess.acquire('book-$name-page-${page.number}').handle(unlock -> {
			if (page.number.value == -1) {
				@:privateAccess page.setNumber(pages);
				var appendStream = File.append(file, true);
				appendStream.write(Bytes.alloc(8000));
				appendStream.flush();
				appendStream.close();
			}
			var stream = File.update(file, true);
			stream.seek(page.number.value * pageSize, FileSeek.SeekBegin);
			stream.writeInt16(page.bytes.length);
			stream.write(page.bytes);
			stream.flush();
			stream.close();
			done.trigger(Noise);
			unlock();
		});
		return done.asFuture();
	}

	public function read(pageNo:Int) {
		var done = Future.trigger();
		SharedAccess.acquire('book-$name-page-${pageNo}').handle(unlock -> {
			var read = File.read(file, true);
			read.seek(pageNo * pageSize, FileSeek.SeekBegin);
			var length = read.readInt16();
			var pageBytes = read.read(length);
			if (pageBytes.length > 0) {
				var page:Page = Serializer.deserialize(pageBytes);
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
	public function count() {
		var stackEntry = haxe.CallStack.toString(haxe.CallStack.callStack().slice(0, 1));
		return Future.ofMany((0...pages).toArray().map(read)).map(pages -> {
			var total = 0;
			pages.iter(page -> {
				var count = page.records.count();
				total += count;
			});
			
			return total;
		});
	}

	public function commit() {
		return Future.ofMany([for(key in dirtyPages.keys()) key].map(key -> dirtyPages.get(key)).map(write)).flatMap(results -> {
			var keys = dirtyPages.keys();
			for(key in keys) {
				dirtyPages.get(key).cleanse();
				
			}
			dirtyPages = [];
			return Noise;
		});
	}

	public function create(records:Array<Record>, newPage = false):Promise<Array<Page>> {
		trace('Creating: $newPage');
		if (records == null || records.length == 0)
			return Future.sync([]);
		else if(records.length > Engine.config.book.maxInsertSize) {
			return Create.split(records, this);
			
		}
		var splitRecords = () -> {}
		var middle = Std.int(records.length / 2);
		var pageNos = (0...pages).toArray();
		// var newPageRoutine = Create.newPage.bind(records, this);
		var getPromises = () -> {
			try {

			pageNos.map(pageNo -> {
				

				return read(pageNo).map(Success);
			
			});
			} catch(e:Dynamic) {
				throw e;
			}
		}
		var l = Lazy.ofFunc(() -> Create.finally(records, this));
		var lazy:Lazy<Promise<Array<Page>>> = cast(l);
		trace('lazy: $l');
		var operation = {
			promises: !newPage ? getPromises() : [],
			yield: Create.yield.bind(_, records, this),
			finally: Promise.lazy(lazy)
		};
		try {
		return Promise.iterate(operation.promises, operation.yield, operation.finally);
			} catch(e:Dynamic) {
					throw e;
				}
	}
}



