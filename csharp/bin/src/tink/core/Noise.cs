// Generated by Haxe 4.0.0-rc.2+77068e10c

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace tink.core {
	public class TinkNoise : global::haxe.lang.Enum {
		
		protected TinkNoise(int index) : base(index) {
		}
		
		
		public static readonly global::tink.core.TinkNoise Noise = new global::tink.core.TinkNoise_Noise();
		
		protected static readonly string[] __hx_constructs = new string[]{"Noise"};
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace tink.core {
	public sealed class TinkNoise_Noise : global::tink.core.TinkNoise {
		
		public TinkNoise_Noise() : base(0) {
		}
		
		
		public override string getTag() {
			return "Noise";
		}
		
		
	}
}


