using System;

namespace Abstruction
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MyList<MyList<Int32>> references = new MyList<MyList<Int32>>();

                references.Add(new MyStack<Int32> { 17, 18, 19, 20 });
                references.Add(new MyQueue<Int32> { 100, 101, 102, 103 });
                foreach (MyList<Int32> item in references)
                {
                    Console.WriteLine("[Item: {0} Type: {1}]", item.Pop(), item.GetType().Name);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
