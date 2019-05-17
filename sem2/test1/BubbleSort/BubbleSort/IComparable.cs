using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    public interface IComparable<T>
    {
        int Compare(T first, T second);
    }
}
