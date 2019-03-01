using System;

namespace SinglyLinkedList
{
    class List : IList
    {
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

        public bool IsEmpty() => head == null;

        public bool IsPositionCorrect(int position) => position > 0 && position <= Length;

        private void AddFirst(int data)
        {
            head = new Node(data, null);
            ++Length;
        }

        private Node FindNodeByPosition(int position)
        {
            Node node = head;

            for (int i = 1; i < position; ++i)
            {
                node = node.Next;
            }

            return node;
        }

        private void AddToHead(int data)
        {
            var temp = head;
            head = new Node(data, temp);
            ++Length;
        }

        private void AddNotToHead(int data, Node node)
        {
            var temp = node.Next;
            node.Next = new Node(data, temp);
            ++Length;
        }

        public void Add(int position, int data)
        {
            if (!IsPositionCorrect(position) && position != Length + 1)
            {
                Console.WriteLine("Position is incorrect");
                return;
            }

            if (IsEmpty())
            {
                AddFirst(data);
                return;
            }

            if (position == 1)
            {
                AddToHead(data);
                return;
            }

            var node = FindNodeByPosition(position - 1);

            AddNotToHead(data, node);
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

        public void Remove(int position)
        {
            if (IsEmpty() || !IsPositionCorrect(position))
            {
                Console.WriteLine("Position is incorrect");
                return;
            }

            if (position == 1)
            {
                RemoveFirst();
                return;
            }

            var node = FindNodeByPosition(position - 1);

            RemoveNotFirst(node);
        }

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

        public void Print()
        {
            Node node = head;

            Console.WriteLine($"The List:");
            for (int i = 1; i <= Length; ++i)
            {
                Console.Write($"{node.Data} ");
                node = node.Next;
            }

            Console.WriteLine();
        }
    }
}

