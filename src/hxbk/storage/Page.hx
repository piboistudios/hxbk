package hxbk.storage;
using Lambda;
import hxbk.storage.*;
import haxe.io.Bytes;
import tink.CoreApi;
import haxe.ds.BalancedTree;
using hxbk.storage.Serializer;
typedef PageNo = Ref<Int>;
class Page {
	public var number(default, null):PageNo;
	public var dirty(default, null):Bool;

	@:noCompletion public function touch() {
		if(book != null) @:privateAccess book.dirtyPages.set(number.value != -1 ? number.value : -book.dirtyPages.count(), this);
		dirty = true;
	}

	@:noCompletion public function cleanse() {
		
		dirty = false;
	}

	var book:Book;

	function setNumber(n) {
		if (number == null)
			number = n;
		else
			number.value = n;
	}

	public function new(b:Book) {
		records = new BalancedTree<Int, Record>();
		book = b;
	}

	public var records(default, null):BalancedTree<Int, Record>;

	public var bytes(get, never):Bytes;

	public function get_bytes() {
		return this.serialize(book.postSerialization);
	}

	public var size(get, never):Int;

	public function get_size() {
		return bytes.length;
	}

	function attempt(operation:Void->Void) {
		var tmpRecords = records.array();
		var wasDirty = dirty;
		try {
			operation();
			touch();
		} catch (e:Dynamic) {
			throw e;
		}
		if (size >= book.pageSize) {
			trace('Overflow $size >= ${book.pageSize} (${bytes.length})');
			records = new BalancedTree<Int, Record>();
			tmpRecords.iter(record -> records.set(record.index, record));
			if(!wasDirty) cleanse();
			return false;
		}
		return true;
	}

	public function create(r:Array<Record>) {
		return attempt(() -> {
			for (record in r) {
				var lastRecord = records.get(records.count() - 1);
				var nextIndex = lastRecord != null ? lastRecord.index + 1 : 0;
				@:privateAccess record.index = nextIndex;
				records.set(nextIndex, record);
			}
		});
	}

	public function retrieve(predicate:Record->Bool) {
		return records.filter(predicate);
	}

	public function update(predicate:Record->Bool, transformation:Record->Void) {
		return attempt(() -> {
			records.filter(predicate).iter(transformation);
		});
	}

	public function delete(predicate:Record->Bool) {
		return attempt(() -> {
			var reversePredicate = d -> !predicate(d);
			records.filter(reversePredicate).iter(record -> records.remove(record.index));
		});
	}

	@:keep
	public function hxSerialize(s:haxe.Serializer) {
		s.serialize(records);
	}

	@:keep
	public function hxUnserialize(u:haxe.Unserializer) {
		records = u.unserialize();
	}
}
