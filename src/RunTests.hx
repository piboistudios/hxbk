package;
import haxe.io.Bytes;
import sys.io.File;
import sys.Http;
using hxbk.IteratorTools;
using Lambda;
import tink.testrunner.*;
import tink.unit.Assert.assert;
import tink.unit.*;

using tink.CoreApi;

import tink.core.Error.ErrorCode;
import hxbk.*;
import hxbk.storage.*;

class RunTests {
	static function main() {
		Runner.run(TestBatch.make([new TestPage()])).handle(Runner.exit);
	}
}

@:asserts
@:timeout(100000)
class TestPage {
	public function new() {}

	public function test_no_engine() {
		try {
			Book.open('test');
		} catch (e:Error) {
			asserts.assert(e.code == InternalError && e.message == hxbk.Messages.NotInitialized);
			asserts.done();
		}
		return asserts;
	}

	@:exclude
	public function test_write() {
		Engine.start({path: 'test'});
		var book = Book.open('test');
		book.getFreePage().handle(page -> {
			var page_access = page
				.create('abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz'.split('').map(_ -> new Record({name: 'test'})));
			asserts.assert(page_access);
			book.write(page).handle(() -> {
				var inMemory = page.bytes.toString();
				book.read(page.number.value).handle(page -> {
					asserts.assert(page.bytes.toString() == inMemory);
					asserts.done();
				});
			});
		});
		return asserts;
	}
	@:exclude
	@:variant(1)
	@:variant(5)
	@:variant(10)
	@:variant(25)
	@:variant(50)
	@:variant(75)
	@:variant(100)
	@:variant(250)
	
	// @:variant(500)
	// @:variant(1000)
	public function test_book_write(repetitions:Int) {
		Engine.start({path: 'test'});
			var book = Book.open('test');
		book.count().handle(preCount -> {

			book.create((0...repetitions).toArray().map(_ -> new Record({name: 'test'}))).handle(() -> {
				book.commit().handle(() -> {
					book.count().handle(postCount -> {
						asserts.assert(preCount + repetitions == postCount);
						asserts.done();
					});
				});
			});
		});
		return asserts;
	}
	@:exclude
	@:variant(2500)
	@:variant(5000)
	public function test_insert(repetitions:Int) {
		Engine.start({path: 'test'});
		var book = Book.open('test');
			book.create((0...repetitions).toArray().map(_ -> new Record({name: 'test'}))).handle(() -> {
					book.commit().handle(() -> {
						book.count().handle(postCount -> {
							asserts.assert(postCount != 0);
							asserts.done();
						});
					});
		});
		return asserts;
	}
	@:variant(100)
	public function test_random(count:Int) {
		Engine.start({path: 'test'});
		var request = () -> {
			var done = Future.trigger();
			var http = new Http('https://randomuser.me/api?results=$count');
			http.onData = function(d) done.trigger(Success(haxe.Json.parse(d)));
			http.onError = function(e) done.trigger(Failure(e));
			http.request(false);
			return done.asFuture();
		};
		request().handle(results -> {
			trace('results: $results');
			switch(results) {
				case Success(randoms):
			var book = Book.open('test');
			var records:Array<Record> = randoms.results.map(random -> new Record(random));
			trace('records: $records');
			book.create(records)
			.handle(() -> {
				book.commit().handle(() -> {
					book.count().handle(count -> {
						asserts.assert(count != 0);
						asserts.done();
					});
				});
			});
			default:
			}
			return Noise;
		});
		return asserts;
	}
	public function test_dump() {
		Engine.start({path: 'test'});
		var book = Book.open('test');
		var dump = File.write('./dump.json');
		dump.writeString('[');
		trace('Opening');
		dump.flush();
		dump.close();
		Promise.iterate((0...book.pages).toArray().map(pageNo -> {
			return book.read(pageNo).map(Success);
		}), page -> {
			var dump = File.append('./dump.json');
			trace('Adding tree');
			 dump.writeString(haxe.Json.stringify(page.records) + (page.number.value != book.pages - 1  ? ',' : ''));
			dump.flush();
			dump.close();
			if(false) return Some(false);
			return None;
		}, Promise.lazy(cast(Lazy.ofFunc(() -> {
			trace('Done');
			var dump = File.append('./dump.json');
			dump.writeString(']');
			dump.flush();
			dump.close();
			var done = Future.trigger();
			asserts.done();
			done.trigger(true);
			return done.asFuture();
			
		}))));
		return asserts;
	}
	
	public function test_storage_plan() {
		Engine.start({path: 'test'});
		var book = Book.open('test-storage-plan');
		var recurse = (val, func, iterations) -> {
			var v = val;
			for(i in 0...iterations) {
				v = func(v);
			}
			return v;
		}
		
		book.addStoragePlan(
			bytes -> {
				var string = bytes.toString();
				return Bytes.ofString('GABRIEL$string');
			},
			bytes -> {
				var string= bytes.toString();
				return Bytes.ofString(string.substr('GABRIEL'.length));
			}
		);
		var request = () -> {
			var done = Future.trigger();
			var http = new Http('https://randomuser.me/api?results=100');
			http.onData = function(d) done.trigger(Success(haxe.Json.parse(d)));
			http.onError = function(e) done.trigger(Failure(e));
			http.request(false);
			return done.asFuture();
		}
		request().handle(results -> {
			// trace('results: $results');
			switch(results) {
				case Success(randoms):
			var records:Array<Record> = randoms.results.map(random -> new Record(random));
			// trace('records: $records');
			book.create(records)
			.handle(() -> {
				book.commit().handle(() -> {
					book.count().handle(count -> {
						asserts.assert(count != 0);
						asserts.done();
					});
				});
			});
			default:
			}
			return Noise;
		});
		return asserts;
	}
	@:variant(1)
	@:variant(2)
	@:variant(3)
	@:variant(4)
	@:variant(5)
	public function test_compression(compressionLevel:Int) {
		Engine.start({path: 'test'});
		var book = Book.open('test');
		var cBook = Book.open('test-compression-level-$compressionLevel');
		cBook.addStoragePlan(
			hxbk.Utils.recursify.bind(_, haxe.zip.Compress.run.bind(_, 1), compressionLevel),
			hxbk.Utils.recursify.bind(_, haxe.zip.Uncompress.run.bind(_, null), compressionLevel)
		);
		Promise.iterate((0...book.pages).toArray().map(pageNo -> {
			return book.read(pageNo).map(Success);
		}), page -> {
			cBook.create(page.records.array()).handle(() -> {
				cBook.commit().handle(() -> {
					if(page.number.value == book.pages - 1) {
						asserts.done();
					}
				});
			});
			return None;
		}, () -> {
			return Future.sync(Some(true));
		});
		return asserts;
	}
}
