package hxbk.operations;
import hxbk.storage.*;
import tink.CoreApi;
using Lambda;
class Create {
	public static function yield(page:Page, records:Array<Record>, book:Book) {
        try {

		if (page.create(records)) {
			@:privateAccess book.dirtyPages.set(page.number.value, page);
			return Some([page]);
		} else {
			return None;
		}
        } catch(e:Dynamic) {
            throw e;
        }
	}
    public static function newPage(records:Array<Record>, book:Book) {
        try {

			var done = Future.trigger();
			var newPage = @:privateAccess book.createPage();
			if (newPage.create(records)) {
				@:privateAccess book.dirtyPages.set(Std.random(1000), newPage);
                // trace(haxe.CallStack.toString(haxe.CallStack.callStack()));
                // trace("Created page for " + records);
                // trace(haxe.Json.stringify(newPage));
				return Success([newPage]);
			} else {
				return Failure(new Error(InternalError, "Data overflow."));
			}
        }catch(e:Dynamic) {
            throw e;
        }
			
		}
    public static function split(records:Array<Record>, book:Book) {
        try {

        var done = Future.trigger();
        var middle = Std.int(records.length / 2);
					var a = records.slice(0, middle);
					var b = records.slice(middle);
					var aggregate:Array<Page> = [];
                    
					Future.ofMany([book.create(a, true), book.create(b, true)]).handle(results -> {
        
                        
                        results.iter(result -> {

						switch (result) {
							case Success(pages):
								aggregate = aggregate.concat(pages);
							default:
						}
                        return Noise;
                        });
                        done.trigger(aggregate);
						return Noise;
					});
        return done.asFuture();
        } catch(e:Dynamic) {
            throw e;
        }
    }
	public static function finally(records:Array<Record>, book:Book) {
        

		var done = Future.trigger();

        
		var result = newPage(records, book);
        
            
			switch (result) {
				case Success(results): done.trigger(results);
				default:
                    
					split(records, book).handle(result -> {
                        
                        done.trigger(result);
                    });
			}
		
        
        
		return done.asFuture();
    
	}
}
