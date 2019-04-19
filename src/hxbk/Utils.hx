package hxbk;

class Utils {
    public static function recursify(val, func, iterations) {
			var v = val;
			for(i in 0...iterations) {
				v = func(v);
			}
			return v;
		}
}