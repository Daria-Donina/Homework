using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace GenericSet
{
    /// <summary>
    /// Representes a collection of objects.
    /// </summary>
    /// <typeparam name="T">The type of elements in the set.</typeparam>
    public class Set<T> : ISet<T> where T : IComparable<T>
    {
        /// <summary>
        /// An element of the set.
        /// </summary>
        private class Node
        {
            /// <summary>
            /// Object that node contains.
            /// </summary>
            public T Item { get; set; }

            /// <summary>
            /// A link to the left child of the node.
            /// </summary>
            public Node LeftChild { get; set; }

            /// <summary>
            /// A link to the left child of the node.
            /// </summary>
            public Node RightChild { get; set; }

            public Node(T item, Node leftChild, Node rightChild)
            {
                Item = item;
                LeftChild = leftChild;
                RightChild = rightChild;
            }
        }

        /// <summary>
        /// Gets the number of elements contained in the set.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the set is read-only.
        /// </summary>
        public bool IsReadOnly { get; }

        private Node root;

        private bool IsEmpty() => root == null;

        /// <summary>
        /// Adds an element to the current set and 
        /// returns a value to indicate if the element was successfully added.
        /// </summary>
        /// <param name="item">The element to add to the set.</param>
        /// <returns>true if the element is added to the set; false if the element is already in the set.</returns>
        public bool Add(T item)
        {
            if (IsEmpty())
            {
                root = new Node(item, null, null);
            }
            else if (!Contains(item))
            {
                root = RecursiveAdd(root, item);
            }
            else
            {
                return false;
            }

            ++Count;
            return true;
        }

        private Node RecursiveAdd(Node current, T item)
        {
            if (current == null)
            {
                return new Node(item, null, null);
            }

            if (item.CompareTo(current.Item) < 0)
            {
                current.LeftChild = RecursiveAdd(current.LeftChild, item);
            }
            else
            {
                current.RightChild = RecursiveAdd(current.RightChild, item);
            }

            return current;
        }

        /// <summary>
        /// Adds an item to the set.a
        /// </summary>
        /// <param name="item">The object to add to the set.</param>
        void ICollection<T>.Add(T item) => Add(item);

        /// <summary>
        /// Removes all items from the set.
        /// </summary>
        public void Clear()
        {
            Count = 0;
            root = null;
        }

        /// <summary>
        /// Determines whether the set contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the set.</param>
        /// <returns>true if item is found in the set; otherwise, false.</returns>
        public bool Contains(T item) => Contains(root, item);

        private bool Contains(Node current, T item)
        {
            if (current == null)
            {
                return false;
            }

            if (Equals(current.Item, item))
            {
                return true;
            }

            if (item.CompareTo(current.Item) < 0)
            {
                return Contains(current.LeftChild, item);
            }
            else
            {
                return Contains(current.RightChild, item);
            }
        }

        /// <summary>
        /// Copies the elements of the set to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from set. 
        /// The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException();
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (arrayIndex + Count > array.Length)
            {
                throw new ArgumentException();
            }

            CopyToInfixTraverse(root, array, ref arrayIndex);
        }

        private void CopyToInfixTraverse(Node current, T[] array, ref int index)
        {
            if (current != null)
            {
                CopyToInfixTraverse(current.LeftChild, array, ref index);
                array[index] = current.Item;
                ++index;
                CopyToInfixTraverse(current.RightChild, array, ref index);
            }
        }

        /// <summary>
        /// Removes all elements in the specified collection from the current set.
        /// </summary>
        /// <param name="other">The collection of items to remove from the set.</param>
        public void ExceptWith(IEnumerable<T> other)
        {
            if (other is null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in other)
            {
                Remove(item);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through set.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through set.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var current = root;
            var stack = new Stack<Node>();

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.LeftChild;
                }

                current = stack.Pop();
                yield return current.Item;
                current = current.RightChild;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through set.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through set.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Modifies the current set so that it contains only elements 
        /// that are also in a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        public void IntersectWith(IEnumerable<T> other)
        {
            if (other is null)
            {
                throw new ArgumentNullException();
            }

            var toRemoveCollection = new List<T>();

            foreach (var item in this)
            {
                if (!other.Contains(item))
                {
                    toRemoveCollection.Add(item);
                }
            }

            ExceptWith(toRemoveCollection);
        }

        /// <summary>
        /// Determines whether the current set is a proper (strict) subset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>true if the current set is a proper subset of other; otherwise, false.</returns>
        public bool IsProperSubsetOf(IEnumerable<T> other) => IsSubsetOf(other) && !SetEquals(other);

        /// <summary>
        /// Determines whether the current set is a proper (strict) superset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>true if the current set is a proper superset of other; otherwise, false.</returns>
        public bool IsProperSupersetOf(IEnumerable<T> other) => IsSupersetOf(other) && !SetEquals(other);

        /// <summary>
        /// Determines whether a set is a subset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>true if the current set is a subset of other; otherwise, false.</returns>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (other is null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in this)
            {
                if (!other.Contains(item))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether the current set is a superset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>true if the current set is a superset of other; otherwise, false.</returns>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            if (other is null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in other)
            {
                if (!Contains(item))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether the current set overlaps with the specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>true if the current set and other share at least one common element; otherwise, false.</returns>
        public bool Overlaps(IEnumerable<T> other)
        {
            if (other is null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in other)
            {
                if (Contains(item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the set.
        /// </summary>
        /// <param name="item">The object to remove from the set.</param>
        /// <returns>true if item was successfully removed from the set; otherwise, false.
        /// This method also returns false if item is not found in the original set.</returns>
        public bool Remove(T item)
        {
            if (!Contains(item))
            {
                return false;
            }
            else
            {
                root = RecursiveRemove(root, item);
                --Count;
                return true;
            }
        }

        private Node RecursiveRemove(Node current, T item)
        {
            if (item.CompareTo(current.Item) < 0)
            {
                current.LeftChild = RecursiveRemove(current.LeftChild, item);
            }
            else if (item.CompareTo(current.Item) > 0)
            {
                current.RightChild = RecursiveRemove(current.RightChild, item);
            }
            else
            {
                if (current.LeftChild is null && current.RightChild is null)
                {
                    return null;
                }
                else if (current.LeftChild is null)
                {
                    return current.RightChild;
                }
                else if (current.RightChild is null)
                {
                    return current.LeftChild;
                }
                else
                {
                    var newCurrent = MinimumRightNode(current.RightChild);
                    (current.Item, newCurrent.Item) = (newCurrent.Item, current.Item);
                    current.RightChild = RecursiveRemove(current.RightChild, newCurrent.Item);
                }
            }

            return current;
        }

        private static Node MinimumRightNode(Node current)
        {
            while (current.LeftChild != null)
            {
                current = current.LeftChild;
            }

            return current;
        }

        /// <summary>
        /// Determines whether the current set and the specified collection contain the same elements.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>true if the current set is equal to other; otherwise, false.</returns>
        public bool SetEquals(IEnumerable<T> other) => IsSubsetOf(other) && IsSupersetOf(other);

        /// <summary>
        /// Modifies the current set so that it contains only elements
        /// that are present either in the current set or in the specified collection, but not both.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            if (other is null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in other)
            {
                if (Contains(item))
                {
                    Remove(item);
                }
                else
                {
                    Add(item);
                }
            }
        }

        /// <summary>
        /// Modifies the current set so that it contains all elements
        /// that are present in the current set, in the specified collection, or in both.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        public void UnionWith(IEnumerable<T> other)
        {
            if (other is null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in other)
            {
                Add(item);
            }
        }
    }
}
