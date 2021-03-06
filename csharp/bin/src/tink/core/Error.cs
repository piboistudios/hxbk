// Generated by Haxe 4.0.0-rc.2+77068e10c

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace tink.core {
	public class TypedError<T> : global::haxe.lang.HxObject, global::tink.core.TypedError {
		
		public TypedError(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public TypedError(global::haxe.lang.Null<int> code, string message, object pos) {
			global::tink.core.TypedError<object>.__hx_ctor_tink_core_TypedError<T>(((global::tink.core.TypedError<T>) (this) ), ((global::haxe.lang.Null<int>) (code) ), ((string) (message) ), ((object) (pos) ));
		}
		
		
		protected static void __hx_ctor_tink_core_TypedError<T_c>(global::tink.core.TypedError<T_c> __hx_this, global::haxe.lang.Null<int> code, string message, object pos) {
			unchecked {
				__hx_this.isTinkError = true;
				{
					global::haxe.lang.Null<int> code1 = ( ( ! (code.hasValue) ) ? (new global::haxe.lang.Null<int>(500, true)) : (code) );
					__hx_this.code = (code1).@value;
					__hx_this.message = message;
					__hx_this.pos = pos;
					__hx_this.exceptionStack = new global::Array<object>(new object[]{});
					__hx_this.callStack = new global::Array<object>(new object[]{});
				}
				
			}
		}
		
		
		public static object __hx_cast<T_c_c>(global::tink.core.TypedError me) {
			return ( (( me != null )) ? (me.tink_core_TypedError_cast<T_c_c>()) : default(object) );
		}
		
		
		public static global::tink.core.TypedError withData(global::haxe.lang.Null<int> code, string message, object data, object pos) {
			return global::tink.core.TypedError<object>.typed<object>(((global::haxe.lang.Null<int>) (code) ), ((string) (message) ), ((object) (data) ), ((object) (pos) ));
		}
		
		
		public static global::tink.core.TypedError<A> typed<A>(global::haxe.lang.Null<int> code, string message, A data, object pos) {
			global::tink.core.TypedError<A> ret = new global::tink.core.TypedError<A>(code, message, pos);
			ret.data = data;
			return ret;
		}
		
		
		public static global::tink.core.TypedError asError(object v) {
			return ((global::tink.core.TypedError) (( ((object) (v) ) as global::tink.core.TypedError )) );
		}
		
		
		public static global::tink.core.Outcome catchExceptions<A>(global::haxe.lang.Function f, global::haxe.lang.Function report, object pos) {
			try {
				return global::tink.core.Outcome.Success(global::haxe.lang.Runtime.genericCast<A>(f.__hx_invoke0_o()));
			}
			catch (global::System.Exception catchallException){
				global::haxe.lang.Exceptions.exception = catchallException;
				object e = ( (( catchallException is global::haxe.lang.HaxeException )) ? (((global::haxe.lang.HaxeException) (catchallException) ).obj) : ((object) (catchallException) ) );
				global::tink.core.TypedError _g = global::tink.core.TypedError<object>.asError(e);
				global::tink.core.TypedError tmp = null;
				if (( _g == null )) {
					tmp = ( (( report == null )) ? (global::tink.core.TypedError<object>.withData(default(global::haxe.lang.Null<int>), "Unexpected Error", e, pos)) : (((global::tink.core.TypedError) (((global::haxe.lang.Function) (report) ).__hx_invoke1_o(default(double), e)) )) );
				}
				else {
					global::tink.core.TypedError e1 = _g;
					tmp = e1;
				}
				
				return global::tink.core.Outcome.Failure(tmp);
			}
			
			
		}
		
		
		public static global::haxe.lang.Function reporter(global::haxe.lang.Null<int> code, string message, object pos) {
			return new global::tink.core.TypedError_reporter_133__Fun(pos, message, code);
		}
		
		
		public static object rethrow(object any) {
			throw global::haxe.lang.HaxeException.wrap(any);
		}
		
		
		public static T1 tryFinally<T1>(global::haxe.lang.Function f, global::haxe.lang.Function cleanup) {
			try {
				T1 ret = global::haxe.lang.Runtime.genericCast<T1>(f.__hx_invoke0_o());
				cleanup.__hx_invoke0_o();
				return ret;
			}
			catch (global::System.Exception catchallException){
				global::haxe.lang.Exceptions.exception = catchallException;
				object e = ( (( catchallException is global::haxe.lang.HaxeException )) ? (((global::haxe.lang.HaxeException) (catchallException) ).obj) : ((object) (catchallException) ) );
				cleanup.__hx_invoke0_o();
				throw global::haxe.lang.HaxeException.wrap(e);
			}
			
			
		}
		
		
		public virtual object tink_core_TypedError_cast<T_c>() {
			if (global::haxe.lang.Runtime.eq(typeof(T), typeof(T_c))) {
				return this;
			}
			
			global::tink.core.TypedError<T_c> new_me = new global::tink.core.TypedError<T_c>(global::haxe.lang.EmptyObject.EMPTY);
			global::Array<object> fields = global::Reflect.fields(this);
			int i = 0;
			while (( i < fields.length )) {
				string field = global::haxe.lang.Runtime.toString(fields[i++]);
				global::Reflect.setField(new_me, field, global::Reflect.field(this, field));
			}
			
			return new_me;
		}
		
		
		public string message;
		
		public int code;
		
		public T data;
		
		public object pos;
		
		public global::Array<object> callStack;
		
		public global::Array<object> exceptionStack;
		
		public bool isTinkError;
		
		public virtual string printPos() {
			return global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.toString(global::haxe.lang.Runtime.getField(this.pos, "className", 1547539107, true)), "."), global::haxe.lang.Runtime.toString(global::haxe.lang.Runtime.getField(this.pos, "methodName", 302979532, true))), ":"), global::haxe.lang.Runtime.toString(((int) (global::haxe.lang.Runtime.getField_f(this.pos, "lineNumber", 1981972957, true)) )));
		}
		
		
		public virtual string toString() {
			string ret = global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat("Error#", global::haxe.lang.Runtime.toString(this.code)), ": "), this.message);
			if (( this.pos != null )) {
				ret = global::haxe.lang.Runtime.concat(ret, global::haxe.lang.Runtime.concat(" @ ", this.printPos()));
			}
			
			return ret;
		}
		
		
		public virtual object throwSelf() {
			object any = ((object) (this) );
			throw global::haxe.lang.HaxeException.wrap(any);
		}
		
		
		public override double __hx_setField_f(string field, int hash, double @value, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 5594516:
					{
						this.pos = ((object) (@value) );
						return @value;
					}
					
					
					case 1113806378:
					{
						this.data = global::haxe.lang.Runtime.genericCast<T>(((object) (@value) ));
						return ((double) (global::haxe.lang.Runtime.toDouble(((object) (@value) ))) );
					}
					
					
					case 1103409453:
					{
						this.code = ((int) (@value) );
						return @value;
					}
					
					
					default:
					{
						return base.__hx_setField_f(field, hash, @value, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override object __hx_setField(string field, int hash, object @value, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 374667308:
					{
						this.isTinkError = global::haxe.lang.Runtime.toBool(@value);
						return @value;
					}
					
					
					case 190204025:
					{
						this.exceptionStack = ((global::Array<object>) (global::Array<object>.__hx_cast<object>(((global::Array) (@value) ))) );
						return @value;
					}
					
					
					case 273334730:
					{
						this.callStack = ((global::Array<object>) (global::Array<object>.__hx_cast<object>(((global::Array) (@value) ))) );
						return @value;
					}
					
					
					case 5594516:
					{
						this.pos = ((object) (@value) );
						return @value;
					}
					
					
					case 1113806378:
					{
						this.data = global::haxe.lang.Runtime.genericCast<T>(@value);
						return @value;
					}
					
					
					case 1103409453:
					{
						this.code = ((int) (global::haxe.lang.Runtime.toInt(@value)) );
						return @value;
					}
					
					
					case 437335495:
					{
						this.message = global::haxe.lang.Runtime.toString(@value);
						return @value;
					}
					
					
					default:
					{
						return base.__hx_setField(field, hash, @value, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 1944494034:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "throwSelf", 1944494034)) );
					}
					
					
					case 946786476:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "toString", 946786476)) );
					}
					
					
					case 689395559:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "printPos", 689395559)) );
					}
					
					
					case 374667308:
					{
						return this.isTinkError;
					}
					
					
					case 190204025:
					{
						return this.exceptionStack;
					}
					
					
					case 273334730:
					{
						return this.callStack;
					}
					
					
					case 5594516:
					{
						return this.pos;
					}
					
					
					case 1113806378:
					{
						return this.data;
					}
					
					
					case 1103409453:
					{
						return this.code;
					}
					
					
					case 437335495:
					{
						return this.message;
					}
					
					
					default:
					{
						return base.__hx_getField(field, hash, throwErrors, isCheck, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override double __hx_getField_f(string field, int hash, bool throwErrors, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 5594516:
					{
						return ((double) (global::haxe.lang.Runtime.toDouble(this.pos)) );
					}
					
					
					case 1113806378:
					{
						return ((double) (global::haxe.lang.Runtime.toDouble(((object) (this.data) ))) );
					}
					
					
					case 1103409453:
					{
						return ((double) (this.code) );
					}
					
					
					default:
					{
						return base.__hx_getField_f(field, hash, throwErrors, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override object __hx_invokeField(string field, int hash, object[] dynargs) {
			unchecked {
				switch (hash) {
					case 1944494034:
					{
						return this.throwSelf();
					}
					
					
					case 946786476:
					{
						return this.toString();
					}
					
					
					case 689395559:
					{
						return this.printPos();
					}
					
					
					default:
					{
						return base.__hx_invokeField(field, hash, dynargs);
					}
					
				}
				
			}
		}
		
		
		public override void __hx_getFields(global::Array<object> baseArr) {
			baseArr.push("isTinkError");
			baseArr.push("exceptionStack");
			baseArr.push("callStack");
			baseArr.push("pos");
			baseArr.push("data");
			baseArr.push("code");
			baseArr.push("message");
			base.__hx_getFields(baseArr);
		}
		
		
		public override string ToString(){
			return this.toString();
		}
		
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace tink.core {
	public class TypedError_reporter_133__Fun : global::haxe.lang.Function {
		
		public TypedError_reporter_133__Fun(object pos, string message, global::haxe.lang.Null<int> code) : base(1, 0) {
			this.pos = pos;
			this.message = message;
			this.code = code;
		}
		
		
		public override object __hx_invoke1_o(double __fn_float1, object __fn_dyn1) {
			object e = ( (( __fn_dyn1 == global::haxe.lang.Runtime.undefined )) ? (((object) (__fn_float1) )) : (((object) (__fn_dyn1) )) );
			return global::tink.core.TypedError<object>.withData(this.code, this.message, e, this.pos);
		}
		
		
		public object pos;
		
		public string message;
		
		public global::haxe.lang.Null<int> code;
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace tink.core {
	[global::haxe.lang.GenericInterface(typeof(global::tink.core.TypedError<object>))]
	public interface TypedError : global::haxe.lang.IHxObject, global::haxe.lang.IGenericObject {
		
		object tink_core_TypedError_cast<T_c>();
		
		string printPos();
		
		string toString();
		
		object throwSelf();
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace tink.core._Error {
	public sealed class Stack_Impl_ {
		
		public static string toString(global::Array<object> this1) {
			return "Error stack not available. Compile with -D error_stack.";
		}
		
		
	}
}


