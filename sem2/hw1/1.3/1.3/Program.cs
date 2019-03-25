using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 7, 3, 5, 1, 0, 3, 4, 8, 2, 7 };
            QSort(array, 0, 9);

            foreach (var element in array)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();
        }

        private static void QSort(int[] array, int first, int last)
        {
            int left = first;
            int right = last;
            int pivot = array[left];

            while (left <= right)
            {
                while (array[left] < pivot)
                {
                    left++;
                }

                while (array[right] > pivot)
                {
                    right--;
                }

                if (left <= right)
                {
                    Swap(ref array[left], ref array[right]);
                    left++;
                    right--;
                }
            }

            if (right > first)
            {
                QSort(array, first, right);
            }

            if (last > left)
            {
                QSort(array, left, last);
            }
        }

        private static void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }
    }
}
