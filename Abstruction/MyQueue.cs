using System;
using System.Linq;

namespace Abstruction
{ 
    internal class MyQueue<T> : MyList<T>
    {
        public MyQueue() : base("Queue is Empty")
        { }
        public override void Add(T item)
        {
            base.Add(item);
        }
        public override T Pop()
        {
            if (isEmpty)
            {
                throw new ArgumentOutOfRangeException(popMethMsg, new Exception());
            }
            else
            {
                mainArr = mainArr.Reverse().ToArray();
                popMethReturnTos = mainArr[count - 1];
                RemoveAt(count - 1);
                return popMethReturnTos;
            }
        }
    }
}
