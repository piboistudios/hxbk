// Generated by Haxe 4.0.0-rc.2+77068e10c

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace tink.core {
	public class Outcome : global::haxe.lang.Enum {
		
		protected Outcome(int index) : base(index) {
		}
		
		
		public static global::tink.core.Outcome Success(object data) {
			return new global::tink.core.Outcome_Success(data);
		}
		
		
		public static global::tink.core.Outcome Failure(object failure) {
			return new global::tink.core.Outcome_Failure(failure);
		}
		
		
		protected static readonly string[] __hx_constructs = new string[]{"Success", "Failure"};
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace tink.core {
	public sealed class Outcome_Success : global::tink.core.Outcome {
		
		public Outcome_Success(object data) : base(0) {
			this.data = data;
		}
		
		
		public override global::Array<object> getParams() {
			return new global::Array<object>(new object[]{this.data});
		}
		
		
		public override string getTag() {
			return "Success";
		}
		
		
		public override int GetHashCode() {
			return global::haxe.lang.Enum.paramsGetHashCode(0, new object[]{this.data});
		}
		
		
		public override bool Equals(object other) {
			if (global::System.Object.ReferenceEquals(((object) (this) ), ((object) (other) ))) {
				return true;
			}
			
			global::tink.core.Outcome_Success en = ( other as global::tink.core.Outcome_Success );
			if (( en == null )) {
				return false;
			}
			
			if ( ! (global::Type.enumEq<object>(((object) (this.data) ), ((object) (en.data) ))) ) {
				return false;
			}
			
			return true;
		}
		
		
		public override string toString() {
			return global::haxe.lang.Enum.paramsToString("Success", new object[]{this.data});
		}
		
		
		public readonly object data;
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace tink.core {
	public sealed class Outcome_Failure : global::tink.core.Outcome {
		
		public Outcome_Failure(object failure) : base(1) {
			this.failure = failure;
		}
		
		
		public override global::Array<object> getParams() {
			return new global::Array<object>(new object[]{this.failure});
		}
		
		
		public override string getTag() {
			return "Failure";
		}
		
		
		public override int GetHashCode() {
			unchecked {
				return global::haxe.lang.Enum.paramsGetHashCode(1, new object[]{this.failure});
			}
		}
		
		
		public override bool Equals(object other) {
			if (global::System.Object.ReferenceEquals(((object) (this) ), ((object) (other) ))) {
				return true;
			}
			
			global::tink.core.Outcome_Failure en = ( other as global::tink.core.Outcome_Failure );
			if (( en == null )) {
				return false;
			}
			
			if ( ! (global::Type.enumEq<object>(((object) (this.failure) ), ((object) (en.failure) ))) ) {
				return false;
			}
			
			return true;
		}
		
		
		public override string toString() {
			return global::haxe.lang.Enum.paramsToString("Failure", new object[]{this.failure});
		}
		
		
		public readonly object failure;
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace tink.core {
	public class OutcomeTools : global::haxe.lang.HxObject {
		
		public OutcomeTools(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public OutcomeTools() {
			global::tink.core.OutcomeTools.__hx_ctor_tink_core_OutcomeTools(this);
		}
		
		
		protected static void __hx_ctor_tink_core_OutcomeTools(global::tink.core.OutcomeTools __hx_this) {
		}
		
		
		public static D sure<D, F>(global::tink.core.Outcome outcome) {
			unchecked {
				switch (outcome._hx_index) {
					case 0:
					{
						D data = global::haxe.lang.Runtime.genericCast<D>(( outcome as global::tink.core.Outcome_Success ).data);
						return data;
					}
					
					
					case 1:
					{
						F failure = global::haxe.lang.Runtime.genericCast<F>(( outcome as global::tink.core.Outcome_Failure ).failure);
						global::tink.core.TypedError _g = global::tink.core.TypedError<object>.asError(failure);
						if (( _g == null )) {
							throw global::haxe.lang.HaxeException.wrap(failure);
						}
						else {
							global::tink.core.TypedError e = _g;
							return global::haxe.lang.Runtime.genericCast<D>(e.throwSelf());
						}
						
					}
					
					
				}
				
				return default(D);
			}
		}
		
		
		public static global::haxe.ds.Option toOption<D, F>(global::tink.core.Outcome outcome) {
			unchecked {
				switch (outcome._hx_index) {
					case 0:
					{
						D data = global::haxe.lang.Runtime.genericCast<D>(( outcome as global::tink.core.Outcome_Success ).data);
						return global::haxe.ds.Option.Some(data);
					}
					
					
					case 1:
					{
						return global::haxe.ds.Option.None;
					}
					
					
				}
				
				return null;
			}
		}
		
		
		public static global::tink.core.Outcome toOutcome<D>(global::haxe.ds.Option option, object pos) {
			unchecked {
				switch (option._hx_index) {
					case 0:
					{
						D @value = global::haxe.lang.Runtime.genericCast<D>(( option as global::haxe.ds.Option_Some ).v);
						return global::tink.core.Outcome.Success(@value);
					}
					
					
					case 1:
					{
						return global::tink.core.Outcome.Failure(new global::tink.core.TypedError<object>(new global::haxe.lang.Null<int>(((int) (404) ), true), global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat("Some value expected but none found in ", global::haxe.lang.Runtime.toString(global::haxe.lang.Runtime.getField(pos, "fileName", 1648581351, true))), "@line "), global::haxe.lang.Runtime.toString(((int) (global::haxe.lang.Runtime.getField_f(pos, "lineNumber", 1981972957, true)) ))), new global::haxe.lang.DynamicObject(new int[]{302979532, 1547539107, 1648581351}, new object[]{"toOutcome", "tink.core.OutcomeTools", "tink/core/Outcome.hx"}, new int[]{1981972957}, new double[]{((double) (47) )})));
					}
					
					
				}
				
				return null;
			}
		}
		
		
		public static global::haxe.lang.Null<D> orNull<D, F>(global::tink.core.Outcome outcome) {
			unchecked {
				switch (outcome._hx_index) {
					case 0:
					{
						D data = global::haxe.lang.Runtime.genericCast<D>(( outcome as global::tink.core.Outcome_Success ).data);
						return new global::haxe.lang.Null<D>(data, true);
					}
					
					
					case 1:
					{
						return default(global::haxe.lang.Null<D>);
					}
					
					
				}
				
				return default(global::haxe.lang.Null<D>);
			}
		}
		
		
		public static D orUse<D, F>(global::tink.core.Outcome outcome, global::tink.core._Lazy.LazyObject<D> fallback) {
			unchecked {
				switch (outcome._hx_index) {
					case 0:
					{
						D data = global::haxe.lang.Runtime.genericCast<D>(( outcome as global::tink.core.Outcome_Success ).data);
						return data;
					}
					
					
					case 1:
					{
						return global::haxe.lang.Runtime.genericCast<D>(((global::tink.core._Lazy.LazyObject<D>) (fallback) ).@get());
					}
					
					
				}
				
				return default(D);
			}
		}
		
		
		public static global::tink.core.Outcome orTry<D, F>(global::tink.core.Outcome outcome, global::tink.core._Lazy.LazyObject<object> fallback) {
			unchecked {
				switch (outcome._hx_index) {
					case 0:
					{
						return outcome;
					}
					
					
					case 1:
					{
						return ((global::tink.core.Outcome) (((global::tink.core._Lazy.LazyObject<object>) (fallback) ).@get()) );
					}
					
					
				}
				
				return null;
			}
		}
		
		
		public static bool @equals<D, F>(global::tink.core.Outcome outcome, D to) {
			unchecked {
				switch (outcome._hx_index) {
					case 0:
					{
						D data = global::haxe.lang.Runtime.genericCast<D>(( outcome as global::tink.core.Outcome_Success ).data);
						return global::haxe.lang.Runtime.eq(data, to);
					}
					
					
					case 1:
					{
						return false;
					}
					
					
				}
				
				return default(bool);
			}
		}
		
		
		public static global::tink.core.Outcome map<A, B, F>(global::tink.core.Outcome outcome, global::haxe.lang.Function transform) {
			unchecked {
				switch (outcome._hx_index) {
					case 0:
					{
						A a = global::haxe.lang.Runtime.genericCast<A>(( outcome as global::tink.core.Outcome_Success ).data);
						return global::tink.core.Outcome.Success(global::haxe.lang.Runtime.genericCast<B>(transform.__hx_invoke1_o(default(double), a)));
					}
					
					
					case 1:
					{
						F f = global::haxe.lang.Runtime.genericCast<F>(( outcome as global::tink.core.Outcome_Failure ).failure);
						return global::tink.core.Outcome.Failure(f);
					}
					
					
				}
				
				return null;
			}
		}
		
		
		public static bool isSuccess<D, F>(global::tink.core.Outcome outcome) {
			if (( outcome._hx_index == 0 )) {
				return true;
			}
			else {
				return false;
			}
			
		}
		
		
		public static global::tink.core.Outcome flatMap<DIn, FIn, DOut, FOut>(global::tink.core.Outcome o, object mapper) {
			return global::tink.core._Outcome.OutcomeMapper_Impl_.apply<DIn, FIn, DOut, FOut>(((object) (mapper) ), ((global::tink.core.Outcome) (o) ));
		}
		
		
		public static global::tink.core.Outcome swap<A, B, F>(global::tink.core.Outcome outcome, B v) {
			unchecked {
				switch (outcome._hx_index) {
					case 0:
					{
						A a = global::haxe.lang.Runtime.genericCast<A>(( outcome as global::tink.core.Outcome_Success ).data);
						return global::tink.core.Outcome.Success(v);
					}
					
					
					case 1:
					{
						F f = global::haxe.lang.Runtime.genericCast<F>(( outcome as global::tink.core.Outcome_Failure ).failure);
						return global::tink.core.Outcome.Failure(f);
					}
					
					
				}
				
				return null;
			}
		}
		
		
		public static global::tink.core.Outcome attempt<D, F>(global::haxe.lang.Function f, global::haxe.lang.Function report) {
			try {
				return global::tink.core.Outcome.Success(global::haxe.lang.Runtime.genericCast<D>(f.__hx_invoke0_o()));
			}
			catch (global::System.Exception catchallException){
				global::haxe.lang.Exceptions.exception = catchallException;
				object e = ( (( catchallException is global::haxe.lang.HaxeException )) ? (((global::haxe.lang.HaxeException) (catchallException) ).obj) : ((object) (catchallException) ) );
				return global::tink.core.Outcome.Failure(global::haxe.lang.Runtime.genericCast<F>(report.__hx_invoke1_o(default(double), e)));
			}
			
			
		}
		
		
		public static global::tink.core.Outcome flatten<D, F>(global::tink.core.Outcome o) {
			unchecked {
				switch (o._hx_index) {
					case 0:
					{
						switch (((global::tink.core.Outcome) (( o as global::tink.core.Outcome_Success ).data) )._hx_index) {
							case 0:
							{
								D d = global::haxe.lang.Runtime.genericCast<D>(( ((global::tink.core.Outcome) (( o as global::tink.core.Outcome_Success ).data) ) as global::tink.core.Outcome_Success ).data);
								return global::tink.core.Outcome.Success(d);
							}
							
							
							case 1:
							{
								F f = global::haxe.lang.Runtime.genericCast<F>(( ((global::tink.core.Outcome) (( o as global::tink.core.Outcome_Success ).data) ) as global::tink.core.Outcome_Failure ).failure);
								return global::tink.core.Outcome.Failure(f);
							}
							
							
						}
						
						break;
					}
					
					
					case 1:
					{
						F f1 = global::haxe.lang.Runtime.genericCast<F>(( o as global::tink.core.Outcome_Failure ).failure);
						return global::tink.core.Outcome.Failure(f1);
					}
					
					
				}
				
				return null;
			}
		}
		
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace tink.core._Outcome {
	public sealed class OutcomeMapper_Impl_ {
		
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		public static object _new<DIn, FIn, DOut, FOut>(global::haxe.lang.Function f) {
			object this1 = new global::haxe.lang.DynamicObject(new int[]{102}, new object[]{f}, new int[]{}, new double[]{});
			return ((object) (this1) );
		}
		
		
		public static global::tink.core.Outcome apply<DIn, FIn, DOut, FOut>(object this1, global::tink.core.Outcome o) {
			return ((global::tink.core.Outcome) (global::haxe.lang.Runtime.callField(this1, "f", 102, new object[]{o})) );
		}
		
		
		public static object withSameError<In, Out, Error>(global::haxe.lang.Function f) {
			return global::tink.core._Outcome.OutcomeMapper_Impl_._new<In, Error, Out, Error>(((global::haxe.lang.Function) (new global::tink.core._Outcome.OutcomeMapper_Impl__withSameError_155__Fun<Out, Error, In>(f)) ));
		}
		
		
		public static object withEitherError<DIn, FIn, DOut, FOut>(global::haxe.lang.Function f) {
			return global::tink.core._Outcome.OutcomeMapper_Impl_._new<DIn, FIn, DOut, object>(((global::haxe.lang.Function) (new global::tink.core._Outcome.OutcomeMapper_Impl__withEitherError_164__Fun<FOut, DOut, FIn, DIn>(f)) ));
		}
		
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace tink.core._Outcome {
	public class OutcomeMapper_Impl__withSameError_155__Fun<Out, Error, In> : global::haxe.lang.Function {
		
		public OutcomeMapper_Impl__withSameError_155__Fun(global::haxe.lang.Function f) : base(1, 0) {
			this.f = f;
		}
		
		
		public override object __hx_invoke1_o(double __fn_float1, object __fn_dyn1) {
			unchecked {
				global::tink.core.Outcome o = ( (( __fn_dyn1 == global::haxe.lang.Runtime.undefined )) ? (((global::tink.core.Outcome) (((object) (__fn_float1) )) )) : (((global::tink.core.Outcome) (__fn_dyn1) )) );
				switch (o._hx_index) {
					case 0:
					{
						In d = global::haxe.lang.Runtime.genericCast<In>(( o as global::tink.core.Outcome_Success ).data);
						return ((global::tink.core.Outcome) (this.f.__hx_invoke1_o(default(double), d)) );
					}
					
					
					case 1:
					{
						Error f1 = global::haxe.lang.Runtime.genericCast<Error>(( o as global::tink.core.Outcome_Failure ).failure);
						return global::tink.core.Outcome.Failure(f1);
					}
					
					
				}
				
				return null;
			}
		}
		
		
		public global::haxe.lang.Function f;
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace tink.core._Outcome {
	public class OutcomeMapper_Impl__withEitherError_164__Fun<FOut, DOut, FIn, DIn> : global::haxe.lang.Function {
		
		public OutcomeMapper_Impl__withEitherError_164__Fun(global::haxe.lang.Function f) : base(1, 0) {
			this.f = f;
		}
		
		
		public override object __hx_invoke1_o(double __fn_float1, object __fn_dyn1) {
			unchecked {
				global::tink.core.Outcome o = ( (( __fn_dyn1 == global::haxe.lang.Runtime.undefined )) ? (((global::tink.core.Outcome) (((object) (__fn_float1) )) )) : (((global::tink.core.Outcome) (__fn_dyn1) )) );
				switch (o._hx_index) {
					case 0:
					{
						DIn d = global::haxe.lang.Runtime.genericCast<DIn>(( o as global::tink.core.Outcome_Success ).data);
						global::tink.core.Outcome _g = ((global::tink.core.Outcome) (this.f.__hx_invoke1_o(default(double), d)) );
						switch (_g._hx_index) {
							case 0:
							{
								DOut d1 = global::haxe.lang.Runtime.genericCast<DOut>(( _g as global::tink.core.Outcome_Success ).data);
								return global::tink.core.Outcome.Success(d1);
							}
							
							
							case 1:
							{
								FOut f1 = global::haxe.lang.Runtime.genericCast<FOut>(( _g as global::tink.core.Outcome_Failure ).failure);
								return global::tink.core.Outcome.Failure(global::haxe.ds.Either.Right(f1));
							}
							
							
						}
						
						break;
					}
					
					
					case 1:
					{
						FIn f2 = global::haxe.lang.Runtime.genericCast<FIn>(( o as global::tink.core.Outcome_Failure ).failure);
						return global::tink.core.Outcome.Failure(global::haxe.ds.Either.Left(f2));
					}
					
					
				}
				
				return null;
			}
		}
		
		
		public global::haxe.lang.Function f;
		
	}
}


