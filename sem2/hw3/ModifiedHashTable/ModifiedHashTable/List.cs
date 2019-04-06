using System;

namespace SinglyLinkedList
{
    /// <summary>
    /// List, a container of integer values.
    /// </summary>
    public class List : IList
    {
        /// <summary>
        /// An element of list.
        /// </summary>
        private class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }

            public Node(int newData, Node newNext)
            {
                Data = newData;
                Next = newNext;
            }
        }

        public int Length { get; private set; }
        private Node head = null;

        /// <summary>
        /// Checks if the list is empty.
        /// </summary>
        /// <returns>True if the list is empty and false if it's not.</returns>
        public bool IsEmpty() => head == null;

        private bool IsPositionCorrect(int position) => position > 0 && position <= Length;

        private Node FindNodeByPosition(int position)
        {
            Node node = head;

            for (int i = 1; i < position; ++i)
            {
                node = node.Next;
            }

            return node;
        }

        private int ValueNotInLastPosition(int value)
        {
            Node node = head;

            for (int i = 1; i < Length; ++i)
            {
                if (Equals(node.Data, value))
                {
                    return i;
                }
                node = node.Next;
            }

            return -1;
        }

        private bool IfValueInLastPosition(int value)
        {
            var node = FindNodeByPosition(Length);

            return Equals(value, node.Data);
        }

        /// <summary>
        /// Finds a serial number of value in the list and returns that number.
        /// </summary>
        /// <param name="value">An integer number which position to be returned.</param>
        /// <returns>A serial number of value in the list or -1 if value is not in the list.</returns>
        public int FindPositionByValue(int value)
        {
            if (IsEmpty())
            {
                return -1;

            }
            int notLastPosition = ValueNotInLastPosition(value);

            if (notLastPosition == -1)
            {
                if (IfValueInLastPosition(value))
                {
                    return Length;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return notLastPosition;
            }
        }

        private void AddFirst(int data)
        {
            head = new Node(data, head);
            ++Length;
        }

        private void AddNotFirst(int data, Node node)
        {
            var temp = node.Next;
            node.Next = new Node(data, temp);
            ++Length;
        }

        /// <summary>
        /// Adds value at the given position of the list.
        /// </summary>
        /// <param name="position">A number of position in the list to add a value.</param>
        /// <param name="data">An integer number to add.</param>
        public void Add(int position, int data)
        {
            if (!IsPositionCorrect(position) && position != Length + 1)
            {
                Console.WriteLine("Position is incorrect");
                return;
            }

            if (IsEmpty() || position == 1)
            {
                AddFirst(data);
                return;
            }

            var node = FindNodeByPosition(position - 1);

            AddNotFirst(data, node);
        }

        private void RemoveFirst()
        {
            head = head.Next;
            --Length;
        }

        private void RemoveNotFirst(Node node)
        {
            Node newNext = node.Next.Next;
            node.Next = newNext;
            --Length;
        }

        /// <summary>
        /// Removes value from the given position of the list.
        /// </summary>
        /// <param name="position">A number of position in the list to remove a value.</param>
        public void Remove(int position)
        {
            if (IsEmpty() || !IsPositionCorrect(position))
            {
                Console.WriteLine("Position is incorrect");
            }

            if (position == 1)
            {
                RemoveFirst();
                return;
            }

            var node = FindNodeByPosition(position - 1);

            RemoveNotFirst(node);
        }

        /// <summary>
        /// Returns value at the given position of the list.
        /// </summary>
        /// <param name="position">A number of position in the list to get a value.</param>
        /// <returns>A value at the given position.</returns>
        public int GetValue(int position)
        {
            if (IsEmpty() || !IsPositionCorrect(position))
            {
                Console.WriteLine("Position is incorrect");
                return -1;
            }

            var node = FindNodeByPosition(position);

            return node.Data;
        }

        /// <summary>
        /// Sets value at the given position of the list.
        /// </summary>
        /// <param name="position">A number of position in the list to set a value.</param>
        /// <param name="value">An integer number to add.</param>
        public void SetValue(int position, int value)
        {
            if (IsEmpty() || !IsPositionCorrect(position))
            {
                Console.WriteLine("Position is incorrect");
                return;
            }

            var node = FindNodeByPosition(position);

            node.Data = value;
        }

        /// <summary>
        /// Prints all the elements of the list.
        /// </summary>
        public void Print()
        {
            Node node = head;
            for (int i = 1; i <= Length; ++i)
            {
                Console.Write($"{node.Data} ");
                node = node.Next;
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Removes all the elements from list.
        /// </summary>
        public void Clear()
        {
            head = null;
            Length = 0;
        }
    }
}
