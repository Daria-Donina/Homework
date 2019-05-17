using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    public class BubbleSort<T>
    {
        public List<T> Sort(List<T> list, IComparable<T> comparer)
        {
            for (int i = list.Count - 1; i >= 0; --i)
            {
                for (int j = i - 1; j >= 0; --j)
                {
                    if (comparer.Compare(list.ElementAt(i), list.ElementAt(j)) == -1)
                    {
                        var temp = list.ElementAt(i);
                        list[i] = list.ElementAt(j);
                        list[j] = temp;
                    }
                }
            }

            return list;
        }
    }
}
