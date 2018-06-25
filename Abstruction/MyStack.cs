namespace Abstruction
{
    internal class MyStack<T> : MyList<T>
    {
        public MyStack() : base("Stack is Empty")
        { }
        public override void Add(T item)
        {
            base.Add(item);
        }
        public override T Pop()
        {
            return base.Pop();
        }
    }
}
