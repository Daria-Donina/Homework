using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Factorial of 1: {Factorial(1)}");
            Console.WriteLine($"Factorial of 5: {Factorial(5)}");
        }

        private static int Factorial(int n)
            => n <= 1 ? 1 : n * Factorial(n - 1);
    }
}
