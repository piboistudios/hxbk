// Generated by Haxe 4.0.0-rc.2+77068e10c

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace tink.runloop {
	public class QueueWorker : global::haxe.lang.HxObject, global::tink.runloop.Worker {
		
		public QueueWorker(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public QueueWorker(global::tink.RunLoop owner, string id) {
			global::tink.runloop.QueueWorker.__hx_ctor_tink_runloop_QueueWorker(this, owner, id);
		}
		
		
		protected static void __hx_ctor_tink_runloop_QueueWorker(global::tink.runloop.QueueWorker __hx_this, global::tink.RunLoop owner, string id) {
			__hx_this.id = id;
			global::haxe.ds.List<object> this1 = new global::haxe.ds.List<object>();
			global::haxe.ds.List<object> this2 = ((global::haxe.ds.List<object>) (this1) );
			__hx_this.tasks = ((global::haxe.ds.List<object>) (this2) );
			__hx_this.owner = owner;
			string this3 = "Fake Main Thread";
			__hx_this.thread = ((string) (this3) );
		}
		
		
		public string id;
		
		public string get_id() {
			return this.id;
		}
		
		
		public global::tink.RunLoop owner;
		
		public global::tink.RunLoop get_owner() {
			return this.owner;
		}
		
		
		public global::haxe.ds.List<object> tasks;
		
		public string thread;
		
		public virtual void log(object v, object p) {
			this.owner.log(v, p);
		}
		
		
		public virtual global::tink.runloop.TaskObject work(global::tink.runloop.TaskObject task) {
			if (( task.get_state() == global::tink.runloop.TaskState.Pending )) {
				this.tasks.@add(task);
			}
			
			return task;
		}
		
		
		public virtual global::tink.runloop.TaskObject atNextStep(global::tink.runloop.TaskObject task) {
			if (( task.get_state() == global::tink.runloop.TaskState.Pending )) {
				this.tasks.push(task);
			}
			
			return task;
		}
		
		
		public virtual global::tink.runloop.TaskObject asap(global::tink.runloop.TaskObject task) {
			string this1 = "Fake Main Thread";
			if (( this.thread == ((string) (this1) ) )) {
				task.perform();
			}
			else {
				this.atNextStep(task);
			}
			
			return task;
		}
		
		
		public virtual void kill() {
			this.tasks = null;
		}
		
		
		public virtual void error(global::tink.core.TypedError e, global::tink.runloop.TaskObject t) {
			global::tink.runloop.QueueWorker _gthis = this;
			this.owner.asap(global::tink.runloop._Task.Task_Impl_.ofFunction(new global::tink.runloop.QueueWorker_error_56__Fun(t, e, _gthis)));
		}
		
		
		public virtual global::tink.runloop.WorkResult execute(global::tink.runloop.TaskObject t) {
			unchecked {
				if (( t == null )) {
					return global::tink.runloop.WorkResult.Idle;
				}
				else {
					try {
						t.perform();
						if (t.get_recurring()) {
							this.work(t);
						}
						
					}
					catch (global::System.Exception catchallException){
						global::haxe.lang.Exceptions.exception = catchallException;
						object realException = ( (( catchallException is global::haxe.lang.HaxeException )) ? (((global::haxe.lang.HaxeException) (catchallException) ).obj) : ((object) (catchallException) ) );
						if (( realException is global::tink.core.TypedError )) {
							global::tink.core.TypedError e = ((global::tink.core.TypedError) (realException) );
							this.error(e, t);
						}
						else {
							object e1 = realException;
							this.error(global::tink.core.TypedError<object>.withData(default(global::haxe.lang.Null<int>), global::haxe.lang.Runtime.concat("Uncaught exception: ", global::Std.@string(e1)), e1, new global::haxe.lang.DynamicObject(new int[]{302979532, 1547539107, 1648581351}, new object[]{"execute", "tink.runloop.QueueWorker", "tink/runloop/QueueWorker.hx"}, new int[]{1981972957}, new double[]{((double) (70) )})), t);
						}
						
					}
					
					
					return global::tink.runloop.WorkResult.Progressed;
				}
				
			}
		}
		
		
		public virtual string toString() {
			return global::haxe.lang.Runtime.concat("Worker:", this.id);
		}
		
		
		public global::tink.runloop.WorkResult step() {
			string this1 = "Fake Main Thread";
			if (( this.thread == ((string) (this1) ) )) {
				return this.doStep();
			}
			else {
				return global::tink.runloop.WorkResult.WrongThread;
			}
			
		}
		
		
		public virtual global::tink.runloop.WorkResult doStep() {
			if (( this.tasks == null )) {
				return global::tink.runloop.WorkResult.Aborted;
			}
			else {
				return this.execute(((global::tink.runloop.TaskObject) ((((global::haxe.ds.List<object>) (this.tasks) ).pop()).@value) ));
			}
			
		}
		
		
		public override object __hx_setField(string field, int hash, object @value, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 247036618:
					{
						this.thread = global::haxe.lang.Runtime.toString(@value);
						return @value;
					}
					
					
					case 183541134:
					{
						this.tasks = ((global::haxe.ds.List<object>) (global::haxe.ds.List<object>.__hx_cast<object>(((global::haxe.ds.List) (@value) ))) );
						return @value;
					}
					
					
					case 947296307:
					{
						this.owner = ((global::tink.RunLoop) (@value) );
						return @value;
					}
					
					
					case 23515:
					{
						this.id = global::haxe.lang.Runtime.toString(@value);
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
					case 476023927:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "doStep", 476023927)) );
					}
					
					
					case 1281091404:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "step", 1281091404)) );
					}
					
					
					case 946786476:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "toString", 946786476)) );
					}
					
					
					case 1275922997:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "execute", 1275922997)) );
					}
					
					
					case 1932118984:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "error", 1932118984)) );
					}
					
					
					case 1191829406:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "kill", 1191829406)) );
					}
					
					
					case 1081428577:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "asap", 1081428577)) );
					}
					
					
					case 1131760114:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "atNextStep", 1131760114)) );
					}
					
					
					case 1325203921:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "work", 1325203921)) );
					}
					
					
					case 5395588:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "log", 5395588)) );
					}
					
					
					case 247036618:
					{
						return this.thread;
					}
					
					
					case 183541134:
					{
						return this.tasks;
					}
					
					
					case 2082469002:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "get_owner", 2082469002)) );
					}
					
					
					case 947296307:
					{
						return ( (handleProperties) ? (this.get_owner()) : (this.owner) );
					}
					
					
					case 590344996:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "get_id", 590344996)) );
					}
					
					
					case 23515:
					{
						return ( (handleProperties) ? (this.get_id()) : (this.id) );
					}
					
					
					default:
					{
						return base.__hx_getField(field, hash, throwErrors, isCheck, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override object __hx_invokeField(string field, int hash, object[] dynargs) {
			unchecked {
				switch (hash) {
					case 476023927:
					{
						return this.doStep();
					}
					
					
					case 1281091404:
					{
						return this.step();
					}
					
					
					case 946786476:
					{
						return this.toString();
					}
					
					
					case 1275922997:
					{
						return this.execute(((global::tink.runloop.TaskObject) (dynargs[0]) ));
					}
					
					
					case 1932118984:
					{
						this.error(((global::tink.core.TypedError) (dynargs[0]) ), ((global::tink.runloop.TaskObject) (dynargs[1]) ));
						break;
					}
					
					
					case 1191829406:
					{
						this.kill();
						break;
					}
					
					
					case 1081428577:
					{
						return this.asap(((global::tink.runloop.TaskObject) (dynargs[0]) ));
					}
					
					
					case 1131760114:
					{
						return this.atNextStep(((global::tink.runloop.TaskObject) (dynargs[0]) ));
					}
					
					
					case 1325203921:
					{
						return this.work(((global::tink.runloop.TaskObject) (dynargs[0]) ));
					}
					
					
					case 5395588:
					{
						this.log(dynargs[0], dynargs[1]);
						break;
					}
					
					
					case 2082469002:
					{
						return this.get_owner();
					}
					
					
					case 590344996:
					{
						return this.get_id();
					}
					
					
					default:
					{
						return base.__hx_invokeField(field, hash, dynargs);
					}
					
				}
				
				return null;
			}
		}
		
		
		public override void __hx_getFields(global::Array<object> baseArr) {
			baseArr.push("thread");
			baseArr.push("tasks");
			baseArr.push("owner");
			baseArr.push("id");
			base.__hx_getFields(baseArr);
		}
		
		
		public override string ToString(){
			return this.toString();
		}
		
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace tink.runloop {
	public class QueueWorker_error_56__Fun : global::haxe.lang.Function {
		
		public QueueWorker_error_56__Fun(global::tink.runloop.TaskObject t, global::tink.core.TypedError e, global::tink.runloop.QueueWorker _gthis) : base(0, 0) {
			this.t = t;
			this.e = e;
			this._gthis = _gthis;
		}
		
		
		public override object __hx_invoke0_o() {
			global::haxe.lang.Function _gthis1 = this._gthis.owner.onError;
			global::Array<object> tmp = global::haxe.CallStack.exceptionStack();
			_gthis1.__hx_invoke4_o(default(double), this.e, default(double), this.t, default(double), this._gthis, default(double), tmp);
			return null;
		}
		
		
		public global::tink.runloop.TaskObject t;
		
		public global::tink.core.TypedError e;
		
		public global::tink.runloop.QueueWorker _gthis;
		
	}
}


