// Generated by Haxe 4.0.0-rc.2+77068e10c

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe {
	public class StackItem : global::haxe.lang.Enum {
		
		protected StackItem(int index) : base(index) {
		}
		
		
		public static readonly global::haxe.StackItem CFunction = new global::haxe.StackItem_CFunction();
		
		public static global::haxe.StackItem Module(string m) {
			return new global::haxe.StackItem_Module(m);
		}
		
		
		public static global::haxe.StackItem FilePos(global::haxe.StackItem s, string file, int line, global::haxe.lang.Null<int> column) {
			return new global::haxe.StackItem_FilePos(s, file, line, column);
		}
		
		
		public static global::haxe.StackItem Method(string classname, string method) {
			return new global::haxe.StackItem_Method(classname, method);
		}
		
		
		public static global::haxe.StackItem LocalFunction(global::haxe.lang.Null<int> v) {
			return new global::haxe.StackItem_LocalFunction(v);
		}
		
		
		protected static readonly string[] __hx_constructs = new string[]{"CFunction", "Module", "FilePos", "Method", "LocalFunction"};
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe {
	public sealed class StackItem_CFunction : global::haxe.StackItem {
		
		public StackItem_CFunction() : base(0) {
		}
		
		
		public override string getTag() {
			return "CFunction";
		}
		
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe {
	public sealed class StackItem_Module : global::haxe.StackItem {
		
		public StackItem_Module(string m) : base(1) {
			this.m = m;
		}
		
		
		public override global::Array<object> getParams() {
			return new global::Array<object>(new object[]{this.m});
		}
		
		
		public override string getTag() {
			return "Module";
		}
		
		
		public override int GetHashCode() {
			unchecked {
				return global::haxe.lang.Enum.paramsGetHashCode(1, new object[]{this.m});
			}
		}
		
		
		public override bool Equals(object other) {
			if (global::System.Object.ReferenceEquals(((object) (this) ), ((object) (other) ))) {
				return true;
			}
			
			global::haxe.StackItem_Module en = ( other as global::haxe.StackItem_Module );
			if (( en == null )) {
				return false;
			}
			
			if ( ! (global::Type.enumEq<object>(((object) (this.m) ), ((object) (en.m) ))) ) {
				return false;
			}
			
			return true;
		}
		
		
		public override string toString() {
			return global::haxe.lang.Enum.paramsToString("Module", new object[]{this.m});
		}
		
		
		public readonly string m;
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe {
	public sealed class StackItem_FilePos : global::haxe.StackItem {
		
		public StackItem_FilePos(global::haxe.StackItem s, string file, int line, global::haxe.lang.Null<int> column) : base(2) {
			this.s = s;
			this.file = file;
			this.line = line;
			this.column = column;
		}
		
		
		public override global::Array<object> getParams() {
			return new global::Array<object>(new object[]{this.s, this.file, this.line, (this.column).toDynamic()});
		}
		
		
		public override string getTag() {
			return "FilePos";
		}
		
		
		public override int GetHashCode() {
			unchecked {
				return global::haxe.lang.Enum.paramsGetHashCode(2, new object[]{this.s, this.file, this.line, (this.column).toDynamic()});
			}
		}
		
		
		public override bool Equals(object other) {
			if (global::System.Object.ReferenceEquals(((object) (this) ), ((object) (other) ))) {
				return true;
			}
			
			global::haxe.StackItem_FilePos en = ( other as global::haxe.StackItem_FilePos );
			if (( en == null )) {
				return false;
			}
			
			if ( ! (global::Type.enumEq<object>(((object) (this.s) ), ((object) (en.s) ))) ) {
				return false;
			}
			
			if ( ! (global::Type.enumEq<object>(((object) (this.file) ), ((object) (en.file) ))) ) {
				return false;
			}
			
			if ( ! (global::Type.enumEq<object>(((object) (this.line) ), ((object) (en.line) ))) ) {
				return false;
			}
			
			if ( ! (global::Type.enumEq<object>((this.column).toDynamic(), (en.column).toDynamic())) ) {
				return false;
			}
			
			return true;
		}
		
		
		public override string toString() {
			return global::haxe.lang.Enum.paramsToString("FilePos", new object[]{this.s, this.file, this.line, (this.column).toDynamic()});
		}
		
		
		public readonly global::haxe.StackItem s;
		
		public readonly string file;
		
		public readonly int line;
		
		public readonly global::haxe.lang.Null<int> column;
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe {
	public sealed class StackItem_Method : global::haxe.StackItem {
		
		public StackItem_Method(string classname, string method) : base(3) {
			this.classname = classname;
			this.method = method;
		}
		
		
		public override global::Array<object> getParams() {
			return new global::Array<object>(new object[]{this.classname, this.method});
		}
		
		
		public override string getTag() {
			return "Method";
		}
		
		
		public override int GetHashCode() {
			unchecked {
				return global::haxe.lang.Enum.paramsGetHashCode(3, new object[]{this.classname, this.method});
			}
		}
		
		
		public override bool Equals(object other) {
			if (global::System.Object.ReferenceEquals(((object) (this) ), ((object) (other) ))) {
				return true;
			}
			
			global::haxe.StackItem_Method en = ( other as global::haxe.StackItem_Method );
			if (( en == null )) {
				return false;
			}
			
			if ( ! (global::Type.enumEq<object>(((object) (this.classname) ), ((object) (en.classname) ))) ) {
				return false;
			}
			
			if ( ! (global::Type.enumEq<object>(((object) (this.method) ), ((object) (en.method) ))) ) {
				return false;
			}
			
			return true;
		}
		
		
		public override string toString() {
			return global::haxe.lang.Enum.paramsToString("Method", new object[]{this.classname, this.method});
		}
		
		
		public readonly string classname;
		
		public readonly string method;
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe {
	public sealed class StackItem_LocalFunction : global::haxe.StackItem {
		
		public StackItem_LocalFunction(global::haxe.lang.Null<int> v) : base(4) {
			this.v = v;
		}
		
		
		public override global::Array<object> getParams() {
			return new global::Array<object>(new object[]{(this.v).toDynamic()});
		}
		
		
		public override string getTag() {
			return "LocalFunction";
		}
		
		
		public override int GetHashCode() {
			unchecked {
				return global::haxe.lang.Enum.paramsGetHashCode(4, new object[]{(this.v).toDynamic()});
			}
		}
		
		
		public override bool Equals(object other) {
			if (global::System.Object.ReferenceEquals(((object) (this) ), ((object) (other) ))) {
				return true;
			}
			
			global::haxe.StackItem_LocalFunction en = ( other as global::haxe.StackItem_LocalFunction );
			if (( en == null )) {
				return false;
			}
			
			if ( ! (global::Type.enumEq<object>((this.v).toDynamic(), (en.v).toDynamic())) ) {
				return false;
			}
			
			return true;
		}
		
		
		public override string toString() {
			return global::haxe.lang.Enum.paramsToString("LocalFunction", new object[]{(this.v).toDynamic()});
		}
		
		
		public readonly global::haxe.lang.Null<int> v;
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe {
	public class CallStack : global::haxe.lang.HxObject {
		
		public CallStack(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public CallStack() {
			global::haxe.CallStack.__hx_ctor_haxe_CallStack(this);
		}
		
		
		protected static void __hx_ctor_haxe_CallStack(global::haxe.CallStack __hx_this) {
		}
		
		
		public static global::Array<object> callStack() {
			unchecked {
				return global::haxe.CallStack.makeStack(new global::System.Diagnostics.StackTrace(((int) (1) ), ((bool) (true) )));
			}
		}
		
		
		public static global::Array<object> exceptionStack() {
			return global::haxe.CallStack.makeStack(new global::System.Diagnostics.StackTrace(((global::System.Exception) (global::haxe.lang.Exceptions.exception) ), ((bool) (true) )));
		}
		
		
		public static string toString(global::Array<object> stack) {
			global::StringBuf b = new global::StringBuf();
			{
				int _g = 0;
				while (( _g < stack.length )) {
					global::haxe.StackItem s = ((global::haxe.StackItem) (stack[_g]) );
					 ++ _g;
					b.b.Append(((string) ("\nCalled from ") ));
					global::haxe.CallStack.itemToString(b, s);
				}
				
			}
			
			return b.b.ToString();
		}
		
		
		public static void itemToString(global::StringBuf b, global::haxe.StackItem s) {
			unchecked {
				switch (s._hx_index) {
					case 0:
					{
						b.b.Append(((string) ("a C function") ));
						break;
					}
					
					
					case 1:
					{
						string m = ( s as global::haxe.StackItem_Module ).m;
						{
							b.b.Append(((string) ("module ") ));
							b.b.Append(((string) (global::Std.@string(m)) ));
						}
						
						break;
					}
					
					
					case 2:
					{
						global::haxe.lang.Null<int> col = ( s as global::haxe.StackItem_FilePos ).column;
						int line = ( s as global::haxe.StackItem_FilePos ).line;
						string file = ( s as global::haxe.StackItem_FilePos ).file;
						global::haxe.StackItem s1 = ( s as global::haxe.StackItem_FilePos ).s;
						{
							if (( s1 != null )) {
								global::haxe.CallStack.itemToString(b, s1);
								b.b.Append(((string) (" (") ));
							}
							
							b.b.Append(((string) (global::Std.@string(file)) ));
							b.b.Append(((string) (" line ") ));
							b.b.Append(((string) (global::Std.@string(line)) ));
							if (col.hasValue) {
								b.b.Append(((string) (" column ") ));
								b.b.Append(((string) (global::Std.@string((col).toDynamic())) ));
							}
							
							if (( s1 != null )) {
								b.b.Append(((string) (")") ));
							}
							
						}
						
						break;
					}
					
					
					case 3:
					{
						string meth = ( s as global::haxe.StackItem_Method ).method;
						string cname = ( s as global::haxe.StackItem_Method ).classname;
						{
							b.b.Append(((string) (global::Std.@string(cname)) ));
							b.b.Append(((string) (".") ));
							b.b.Append(((string) (global::Std.@string(meth)) ));
						}
						
						break;
					}
					
					
					case 4:
					{
						global::haxe.lang.Null<int> n = ( s as global::haxe.StackItem_LocalFunction ).v;
						{
							b.b.Append(((string) ("local function #") ));
							b.b.Append(((string) (global::Std.@string((n).toDynamic())) ));
						}
						
						break;
					}
					
					
				}
				
			}
		}
		
		
		public static global::Array<object> makeStack(global::System.Diagnostics.StackTrace s) {
			global::Array<object> stack = new global::Array<object>(new object[]{});
			{
				int _g = 0;
				int _g1 = s.FrameCount;
				while (( _g < _g1 )) {
					int i = _g++;
					global::System.Diagnostics.StackFrame frame = s.GetFrame(((int) (i) ));
					global::System.Reflection.MethodBase m = frame.GetMethod();
					if (( m == null )) {
						continue;
					}
					
					global::haxe.StackItem method = global::haxe.StackItem.Method(( ( m as global::System.Reflection.MemberInfo ).ReflectedType as global::System.Reflection.MemberInfo ).ToString(), ( m as global::System.Reflection.MemberInfo ).Name);
					string fileName = frame.GetFileName();
					int lineNumber = frame.GetFileLineNumber();
					if (( ( fileName != null ) || ( lineNumber >= 0 ) )) {
						stack.push(global::haxe.StackItem.FilePos(method, fileName, lineNumber, default(global::haxe.lang.Null<int>)));
					}
					else {
						stack.push(method);
					}
					
				}
				
			}
			
			return stack;
		}
		
		
	}
}


