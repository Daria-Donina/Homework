using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write($"Enter dimesion of array (odd number): ");
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine();

            var rand = new Random();

            if (n % 2 != 1 || n < 0)
            {
                Console.WriteLine("Entered number is not correct");
                return;
            }

            Console.WriteLine($"The array:");

            var array = new int[n, n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    array[i, j] = rand.Next(10);
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"Spiral output:");
            Output(array);
            Console.WriteLine();
        }

        static void Output(int[,] array)
        {
            int n = array.GetLength(0);
            int i = n / 2;
            int j = n / 2;
            int center = array[i, j];
            Console.Write($"{center} ");
 
            for (int elements = 1; elements < n; ++elements)
            {
                if (elements % 2 == 1)
                {
                    StepsRight(array, elements, ref i, ref j);

                    StepsDown(array, elements, ref i, ref j);
                }

                if (elements % 2 == 0)
                {
                    StepsLeft(array, elements, ref i, ref j);

                    StepsUp(array, elements, ref i, ref j);
                }
            }

            for (j = 1; j < n; ++j)
            {
                Console.Write($"{array[0, j]} ");
            }
        }

        private static void StepsRight(int[,] array, int elements, ref int i, ref int j)
        {
            for (int k = 1; k <= elements; ++k)
            {
                Console.Write($"{array[i, j + k]} ");
            }
            j = j + elements;
        }

        private static void StepsDown(int[,] array, int elements, ref int i, ref int j)
        {
            for (int k = 1; k <= elements; ++k)
            {
                Console.Write($"{array[i + k, j]} ");
            }
            i = i + elements;
        }

        private static void StepsLeft(int[,] array, int elements, ref int i, ref int j)
        {
            for (int k = 1; k <= elements; ++k)
            {
                Console.Write($"{array[i, j - k]} ");
            }
            j = j - elements;
        }

        private static void StepsUp(int[,] array, int elements, ref int i, ref int j)
        {
            for (int k = 1; k <= elements; ++k)
            {
                Console.Write($"{array[i - k, j]} ");
            }
            i = i - elements;
        }
    }
}
