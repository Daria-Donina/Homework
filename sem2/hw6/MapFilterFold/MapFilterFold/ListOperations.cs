using System;
using System.Collections.Generic;

namespace MapFilterFold
{
    /// <summary>
    /// Class containing list operations.
    /// </summary>
    public static class ListOperations
    {
        /// <summary>
        /// Transforms each element of the list.
        /// </summary>
        /// <param name="list">List to transform.</param>
        /// <param name="transform">Function that defines transformation.</param>
        /// <returns>Transformed list.</returns>
        public static List<int> Map(List<int> list, Func<int, int> transform)
        {
            var result = new List<int>();

            foreach (var element in list)
            {
                result.Add(transform(element));
            }
            return result;
        }

        /// <summary>
        /// Filters the list.
        /// </summary>
        /// <param name="list">List to filter.</param>
        /// <param name="filter">Function that defines whether an element is appropriate or not.</param>
        /// <returns>Filtered list.</returns>
        public static List<int> Filter(List<int> list, Func<int, bool> filter)
        {
            var result = new List<int>();

            foreach (var element in list)
            {
                if (filter(element))
                {
                    result.Add(element);
                }
            }
            return result;
        }

        /// <summary>
        /// Computes accumulated value of the list.
        /// </summary>
        /// <param name="list">List to compute accumulated value.</param>
        /// <param name="initialValue">Initial value to start accumulation.</param>
        /// <param name="accumulate">Function that defines the way of computing accumulated value.</param>
        /// <returns>Accumulated value of the list.</returns>
        public static int Fold(List<int> list, int initialValue, Func<int, int, int> accumulate)
        {
            int result = initialValue;
            foreach (var element in list)
            {
                result = accumulate(result, element);
            }
            return result;
        }
    }
}
