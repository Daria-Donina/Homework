using System;

namespace UniqueList
{
    /// <summary>
    /// List, a container of string values.
    /// </summary>
    public class List
    {
        /// <summary>
        /// An element of list.
        /// </summary>
        private class Node
        {
            /// <summary>
            /// A string data that contains in the node.
            /// </summary>
            public string Data { get; set; }

            /// <summary>
            /// A link to the next node.
            /// </summary>
            public Node Next { get; set; }

            public Node(string newData, Node newNext)
            {
                Data = newData;
                Next = newNext;
            }
        }

        /// <summary>
        /// Number of elements of the hash table.
        /// </summary>
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

        private int DataNotInLastPosition(string data)
        {
            Node node = head;

            for (int i = 1; i < Length; ++i)
            {
                if (Equals(node.Data, data))
                {
                    return i;
                }
                node = node.Next;
            }

            return -1;
        }

        private bool IfDataInLastPosition(string data)
        {
            var node = FindNodeByPosition(Length);

            return Equals(data, node.Data);
        }

        /// <summary>
        /// Finds a serial number of a string in the list and returns that number.
        /// </summary>
        /// <param name="data">A string which position to be returned.</param>
        /// <returns>A serial number of string in the list or -1 if string is not in the list.</returns>
        public int FindPositionByData(string data)
        {
            if (IsEmpty())
            {
                return -1;

            }
            int notLastPosition = DataNotInLastPosition(data);

            if (notLastPosition == -1)
            {
                if (IfDataInLastPosition(data))
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

        private void AddFirst(string data)
        {
            head = new Node(data, head);
            ++Length;
        }

        private void AddNotFirst(string data, Node node)
        {
            var temp = node.Next;
            node.Next = new Node(data, temp);
            ++Length;
        }

        /// <summary>
        /// Adds data at the given position of the list.
        /// </summary>
        /// <param name="position">A number of position in the list to add a string.</param>
        /// <param name="data">A string to add.</param>
        public virtual void Add(int position, string data)
        {
            if (!IsPositionCorrect(position) && position != Length + 1)
            {
                throw new InvalidOperationException();
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
        /// Removes data from the given position of the list.
        /// </summary>
        /// <param name="position">A number of position in the list to remove a string.</param>
        public void Remove(int position)
        {
            if (IsEmpty() || !IsPositionCorrect(position))
            {
                throw new RemoveElementThatDoesNotExistException();
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
        /// Returns data at the given position of the list.
        /// </summary>
        /// <param name="position">A number of position in the list to get data.</param>
        /// <returns>Data at the given position.</returns>
        public string GetData(int position)
        {
            if (IsEmpty() || !IsPositionCorrect(position))
            {
                throw new InvalidOperationException();
            }

            var node = FindNodeByPosition(position);

            return node.Data;
        }

        /// <summary>
        /// Sets new data at the given position of the list.
        /// </summary>
        /// <param name="position">A number of position in the list to set new data.</param>
        /// <param name="data">A string to add.</param>
        public virtual void SetData(int position, string data)
        {
            if (IsEmpty() || !IsPositionCorrect(position))
            {
                throw new InvalidOperationException();
            }

            var node = FindNodeByPosition(position);

            node.Data = data;
        }

        /// <summary>
        /// Checks if data is in the list.
        /// </summary>
        /// <param name="data">A string data to check if it's in the list.</param>
        /// <returns>"True" if data is in the list and "false" if it's not.</returns>
        public bool Exists(string data)
        {
            var node = head;

            while (node != null)
            {
                if (node.Data == data)
                {
                    return true;
                }

                node = node.Next;
            }

            return false;
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
