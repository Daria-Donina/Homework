using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    public class ListComparer<T> : IComparable<List<T>>
    {
        public int Compare(List<T> first, List<T> second)
        {
            if (first.Count > second.Count)
            {
                return 1;
            }
            else if (first.Count < second.Count)
            {
                return -1;
            }
            return 0;
        }
    }
}
