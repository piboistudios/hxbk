package hxbk.operations;

enum Result<T> {
    Continue(result:T);
    Done(result:T);
}