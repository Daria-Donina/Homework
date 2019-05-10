using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// An object that compares two lists of strings.
    /// </summary>
    /// <typeparam name="T">A List<string> type of object to compare.</typeparam>
    public class ListComparer<T> where T : List<string>
    {
        /// <summary>
        /// Compares two lists of strings.
        /// </summary>
        /// <param name="first">First list to compare.</param>
        /// <param name="second">Second list to compare.</param>
        /// <returns></returns>
        public int Compare(T first, T second)
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
