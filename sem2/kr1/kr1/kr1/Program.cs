using System;

namespace kr1
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new PriorityQueue();

            queue.Enqueue(6, "aaaa");
            queue.Enqueue(10, "bbbb");
            queue.Enqueue(7, "cccc");
            queue.Enqueue(-9, "dddd");
            queue.Enqueue(0, "eeee");

            while (!queue.IsEmpty())
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
