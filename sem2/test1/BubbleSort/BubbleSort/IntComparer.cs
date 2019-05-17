using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    public class IntComparer : IComparable<int>
    {
        public int Compare(int first, int second)
        {
            if (first > second)
            {
                return 1;
            }
            else if (first < second)
            {
                return -1;
            }
            return 0;
        }
    }
}
