// Generated by Haxe 4.0.0-rc.2+77068e10c

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace tink.runloop {
	public interface Worker : global::haxe.lang.IHxObject {
		
		global::tink.RunLoop get_owner();
		
		string get_id();
		
		global::tink.runloop.TaskObject work(global::tink.runloop.TaskObject task);
		
		global::tink.runloop.TaskObject asap(global::tink.runloop.TaskObject task);
		
		global::tink.runloop.TaskObject atNextStep(global::tink.runloop.TaskObject task);
		
		global::tink.runloop.WorkResult step();
		
		void kill();
		
	}
}


