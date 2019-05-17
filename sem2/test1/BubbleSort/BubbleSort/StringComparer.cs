using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    public class StringComparer : IComparable<string>
    {
        public int Compare(string first, string second)
        {
            if (first.Length > second.Length)
            {
                return 1;
            }
            else if (first.Length < second.Length)
            {
                return -1;
            }
            return 0;
        }
    }
}
