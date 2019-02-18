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
            Console.Write($"Enter dimesion of array: ");
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine();

            Random rand = new Random();

            Console.WriteLine($"The array:");
            int[,] array = new int[n, n];
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
            Output(array, n);
            Console.WriteLine();
        }

        static void Output(int[,] array, int n)
        {
            int i = n / 2;
            int j = n / 2;
            int center = array[i, j];
            Console.Write($"{center} ");
 
            for (int elements = 1; elements < n; ++elements)
            {
                if (elements % 2 == 1)
                {
                    for (int k = 1; k <= elements; ++k)
                    {
                        Console.Write($"{array[i , j + k]} ");
                    }
                    j = j + elements;

                    for (int k = 1; k <= elements; ++k)
                    {
                        Console.Write($"{array[i + k, j]} ");
                    }
                    i = i + elements;
                }

                if (elements % 2 == 0)
                {
                    for (int k = 1; k <= elements; ++k)
                    {
                        Console.Write($"{array[i, j - k]} ");
                    }
                    j = j - elements;

                    for (int k = 1; k <= elements; ++k)
                    {
                        Console.Write($"{array[i - k, j]} ");
                    }
                    i = i - elements;
                }
            }

            for (j = 1; j < n; ++j)
            {
                Console.Write($"{array[0, j]} ");
            }
        }
    }
}
