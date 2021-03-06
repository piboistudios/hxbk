// Generated by Haxe 4.0.0-rc.2+77068e10c

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.ds {
	public class Option : global::haxe.lang.Enum {
		
		protected Option(int index) : base(index) {
		}
		
		
		public static global::haxe.ds.Option Some(object v) {
			return new global::haxe.ds.Option_Some(v);
		}
		
		
		public static readonly global::haxe.ds.Option None = new global::haxe.ds.Option_None();
		
		protected static readonly string[] __hx_constructs = new string[]{"Some", "None"};
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.ds {
	public sealed class Option_Some : global::haxe.ds.Option {
		
		public Option_Some(object v) : base(0) {
			this.v = v;
		}
		
		
		public override global::Array<object> getParams() {
			return new global::Array<object>(new object[]{this.v});
		}
		
		
		public override string getTag() {
			return "Some";
		}
		
		
		public override int GetHashCode() {
			return global::haxe.lang.Enum.paramsGetHashCode(0, new object[]{this.v});
		}
		
		
		public override bool Equals(object other) {
			if (global::System.Object.ReferenceEquals(((object) (this) ), ((object) (other) ))) {
				return true;
			}
			
			global::haxe.ds.Option_Some en = ( other as global::haxe.ds.Option_Some );
			if (( en == null )) {
				return false;
			}
			
			if ( ! (global::Type.enumEq<object>(((object) (this.v) ), ((object) (en.v) ))) ) {
				return false;
			}
			
			return true;
		}
		
		
		public override string toString() {
			return global::haxe.lang.Enum.paramsToString("Some", new object[]{this.v});
		}
		
		
		public readonly object v;
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.ds {
	public sealed class Option_None : global::haxe.ds.Option {
		
		public Option_None() : base(1) {
		}
		
		
		public override string getTag() {
			return "None";
		}
		
		
	}
}


