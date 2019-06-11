using System;
using System.Collections.Generic;

namespace MapFilterFold
{
    /// <summary>
    /// Class containing list operations.
    /// </summary>
    public static class ListOperations<TArgument, TReturn>
    {
        /// <summary>
        /// Transforms each element of the list.
        /// </summary>
        /// <param name="list">List to transform.</param>
        /// <param name="transform">Function that defines transformation.</param>
        /// <returns>Transformed list.</returns>
        public static List<TReturn> Map(List<TArgument> list, Func<TArgument, TReturn> transform)
        {
            if (list is null)
            {
                throw new ArgumentNullException();
            }

            var result = new List<TReturn>();

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
        public static List<TArgument> Filter(List<TArgument> list, Func<TArgument, bool> filter)
        {
            if (list is null)
            {
                throw new ArgumentNullException();
            }

            var result = new List<TArgument>();

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
        public static TReturn Fold(List<TArgument> list, TReturn initialValue, Func<TReturn, TArgument, TReturn> accumulate)
        {
            if (list is null)
            {
                throw new ArgumentNullException();
            }

            TReturn result = initialValue;
            foreach (var element in list)
            {
                result = accumulate(result, element);
            }
            return result;
        }
    }
}
