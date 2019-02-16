using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"The first Fibonacci number: {Fibonacci(1)}");
            Console.WriteLine($"The sixth Fibonacci number: {Fibonacci(6)}");
            Console.WriteLine($"The seventh Fibonacci number: {Fibonacci(7)}");
        }

        private static int Fibonacci(int n)
        {
            if (n < 0)
            {
                return -1;
            }

            else if (n == 0)
            {
                return 0;
            }

            else if (n == 1)
            {
                return 1;
            }

            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }
    }
}
