using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericList
{
    /// <summary>
    /// Represents a strongly typed list of objects that can be accessed by index. 
    /// Provides methods to search and manipulate lists.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class List<T> : IList<T>
    {
        /// <summary>
        /// An element of the list.
        /// </summary>
        private class Node
        {
            /// <summary>
            /// Object that node contains.
            /// </summary>
            public T Item { get; set; }

            /// <summary>
            /// A link to the next node of the list.
            /// </summary>
            public Node Next { get; set; }

            public Node(T item, Node next)
            {
                Item = item;
                Next = next;
            }
        }

        private Node head;

        private bool IsCorrectIndex(int index) => index >= 0 && index < Count;

        /// <summary>
        /// Gets the number of elements contained in the List<T>.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the List<T> is read-only.
        /// </summary>
        public bool IsReadOnly { get; }

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        public T this[int index]
        {
            get => GetNodeByIndex(index).Item;
            set => GetNodeByIndex(index).Item = value;
        }

        private Node GetNodeByIndex(int index)
        {
            if (!IsCorrectIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            var current = head;

            for (int i = 0; i < index; ++i)
            {
                current = current.Next;
            }

            return current;
        }

        private bool IsEmpty() => head == null;

        /// <summary>
        /// Adds an item to the end of the List<T>.
        /// </summary>
        /// <param name="item">The object to add to the List<T>.</param>
        public void Add(T item) => Insert(Count, item);

        /// <summary>
        /// Removes all items from the List<T>.
        /// </summary>
        public void Clear()
        {
            head = null;
            Count = 0;
        }

        /// <summary>
        /// Determines whether the List<T> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the List<T>.</param>
        /// <returns>true if item is found in the List<T>; otherwise, false.</returns>
        public bool Contains(T item) => IndexOf(item) != -1;

        /// <summary>
        /// Copies the elements of the List<T> to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List<T>. 
        /// The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = 0; i < Count; ++i)
            {
                if (i + arrayIndex < array.Length)
                {
                    array[i + arrayIndex] = this[i];
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a list.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through the list.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var current = head;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a list.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through the list.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Determines the index of a specific item in the List<T>.
        /// </summary>
        /// <param name="item">The object to locate in the List<T>.</param>
        /// <returns>The index of item if found in the List<T>; otherwise, -1.</returns>
        public int IndexOf(T item)
        {
            var current = head;

            for (int i = 0; i < Count; ++i)
            {
                if (Equals(current.Item, item))
                {
                    return i;
                }
                current = current.Next;
            }

            return -1;
        }

        /// <summary>
        /// Inserts an item to the List<T> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert into the List<T>.</param>
        public void Insert(int index, T item)
        {
            if (!IsCorrectIndex(index) && index != Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (IsEmpty() || index == 0)
            {
                head = new Node(item, head);
            }
            else
            {
                var previousNode = GetNodeByIndex(index - 1);
                previousNode.Next = new Node(item, previousNode.Next);
            }

            ++Count;
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the List<T>.
        /// </summary>
        /// <param name="item">The object to remove from the List<T>.</param>
        /// <returns>true if item was successfully removed from the List<T>; otherwise, false.
        /// This method also returns false if item is not found in the original List<T>.</returns>
        public bool Remove(T item)
        {
            var index = IndexOf(item);

            if (index == -1)
            {
                return false;
            }
            else
            {
                RemoveAt(index);
                return true;
            }
        }

        /// <summary>
        /// Removes the List<T> item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        public void RemoveAt(int index)
        {
            if (!IsCorrectIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            if (index == 0)
            {
                head = head.Next;
            }
            else
            {
                var previousItem = GetNodeByIndex(index - 1);
                previousItem.Next = previousItem.Next.Next;
            }

            --Count;
        }
    }
}
