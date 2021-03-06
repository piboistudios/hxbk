// Generated by Haxe 4.0.0-rc.2+77068e10c

#pragma warning disable 109, 114, 219, 429, 168, 162
public class Sys : global::haxe.lang.HxObject {
	
	public Sys(global::haxe.lang.EmptyObject empty) {
	}
	
	
	public Sys() {
		global::Sys.__hx_ctor__Sys(this);
	}
	
	
	protected static void __hx_ctor__Sys(global::Sys __hx_this) {
	}
	
	
	public static string systemName() {
		unchecked {
			switch (global::haxe.lang.Runtime.concat(global::Std.@string(global::System.Environment.OSVersion.Platform), "")) {
				case "MacOSX":
				{
					return "Mac";
				}
				
				
				case "Unix":
				{
					return "Linux";
				}
				
				
				case "Xbox":
				{
					return "Xbox";
				}
				
				
				default:
				{
					int ver = ((int) (global::haxe.lang.Runtime.toInt(((object) (global::System.Environment.OSVersion.Platform) ))) );
					if (( ( ( ver == 4 ) || ( ver == 6 ) ) || ( ver == 128 ) )) {
						return "Linux";
					}
					
					return "Windows";
				}
				
			}
			
		}
	}
	
	
	public static readonly long epochTicks = new global::System.DateTime(1970, 1, 1).Ticks;
	
	public static double time() {
		return ( ((double) (((long) (( ((long) (global::System.DateTime.UtcNow.Ticks) ) - ((long) (global::Sys.epochTicks) ) )) )) ) / ((double) (global::System.TimeSpan.TicksPerSecond) ) );
	}
	
	
}


