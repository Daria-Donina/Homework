using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class SortedSet
    {
        /// <summary>
        /// An element of the set.
        /// </summary>
        private class Element
        {
            /// <summary>
            /// A list of strings that the element contains.
            /// </summary>
            public List<string> Data { get; set; }

            /// <summary>
            /// A link to the next element.
            /// </summary>
            public Element Next { get; set; }

            public Element(List<string> data, Element next)
            {
                Data = data;
                Next = next;
            }
        }

        private Element head;

        /// <summary>
        /// Checks if the set is empty.
        /// </summary>
        /// <returns>True if the set is empty and false if it's not.</returns>
        public bool IsEmpty() => head == null;

        private int count;

        ListComparer<List<string>> comparer = new ListComparer<List<string>>();

        /// <summary>
        /// Adds list to the set.
        /// </summary>
        /// <param name="data">A list to add.</param>
        public void Add(List<string> data)
        {
            if (IsEmpty() || comparer.Compare(data, head.Data) < 0)
            {
                head = new Element(data, head);
                ++count;
                return;
            }

            var current = head;

            for (int i = 0; i < count; ++i)
            {
                if (comparer.Compare(data, current.Data) > 0)
                {
                    var newNext = current.Next;
                    current.Next = new Element(data, newNext);
                    ++count;
                    return;
                }

                current = current.Next;
            }
        }

        /// <summary>
        /// Prints set.
        /// </summary>
        public void Print()
        {
            var current = head;

            for (int i = 0; i < count; ++i)
            {
                foreach (var word in current.Data)
                {
                    Console.Write($"{word} ");
                }
                Console.WriteLine();
                current = current.Next;
            }
        }
    }
}
