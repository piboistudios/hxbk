package hxbk;

using hxbk.storage.Serializer;

class StorageTools {
	public static function size<T>(object:T) {
		return object.serialize().length * 4;
	}
}
