package hxbk;

class IteratorTools {
    
	public static function toArray(iterator:IntIterator) {
		var retVal = [];
		for (i in iterator) {
			retVal.push(i);
		}
		return retVal;
	}
    
}
