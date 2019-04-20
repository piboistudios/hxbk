package hxbk.operations;
import hxbk.storage.*;
import tink.CoreApi;
using Lambda;
typedef CreateResult = {
	var depth:Int;
	var page:Page;
	var owner:Int;
	var id:Int;
}

class IdGen {
	static var current = 0;
	public static function getId() {
		return current++;
	}
}