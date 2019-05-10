using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of strings");

            if (!int.TryParse(Console.ReadLine(), out int numberOfStrings))
            {
                throw new FormatException();
            }

            SortedSet set = new SortedSet();

            string[] data = new string[numberOfStrings];

            for (int i = 0; i < numberOfStrings; ++i)
            {
                data[i] = Console.ReadLine();

                var list = new List<string>();
                var arrayOfStrings = data[i].Split(' ');

                for (int j = 0; j < arrayOfStrings.Length; ++j)
                {
                    list.Add(arrayOfStrings[j]);
                }

                set.Add(list);
            }

            set.Print();
        }
    }
}
