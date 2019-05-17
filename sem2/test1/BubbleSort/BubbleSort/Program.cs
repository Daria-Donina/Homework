using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringSet = new BubbleSort<string>();
            var stringComparer = new StringComparer();

            List<string> list = new List<string> { "i", "abcde", "abcd", "", "abgh" };
            var sortedList = stringSet.Sort(list, stringComparer);

            for (int i = 1; i < sortedList.Count; ++i)
            {
                if (stringComparer.Compare(sortedList.ElementAt(i - 1), sortedList.ElementAt(i)) != -1)
                {
                    return;
                }
            }

            return;
        }
    }
}
