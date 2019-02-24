using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of lines in the matrix: ");
            int n = Int32.Parse(Console.ReadLine());
            Console.Write("Enter number of columns in the matrix: ");
            int m = Int32.Parse(Console.ReadLine());
            Console.WriteLine();

            if (n <= 0 || m <= 0)
            {
                Console.WriteLine("Input data is incorrect");
                return;
            }

            var rand = new Random();

            Console.WriteLine("The matrix:");
            int[,] matrix = new int[n, m];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    matrix[i, j] = rand.Next(10);
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Matrix columnns sorted by first elements:");
            QuickSortingOfMatrixColumns(matrix, 0, m - 1);

            MatrixOutput(matrix);
        }

        static void QuickSortingOfMatrixColumns(int[,] matrix, int firstColumn, int lastColumn)
        {
            int left = firstColumn;
            int right = lastColumn;
            int pivot = matrix[0, left];

            while (left <= right)
            {
                while (matrix[0, left] < pivot)
                {
                    left++;
                }

                while (matrix[0, right] > pivot)
                {
                    right--;
                }

                if (left <= right)
                {
                    SwapColumns(matrix, left, right);
                    left++;
                    right--;
                }
            }

            if (right > firstColumn)
            {
                QuickSortingOfMatrixColumns(matrix, firstColumn, right);
            }

            if (lastColumn > left)
            {
                QuickSortingOfMatrixColumns(matrix, left, lastColumn);
            }
        }

        static void SwapColumns(int[,] matrix, int first, int second)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                Swap(ref matrix[i, first], ref matrix[i, second]);
            }
        }

        private static void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }

        static void MatrixOutput(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
