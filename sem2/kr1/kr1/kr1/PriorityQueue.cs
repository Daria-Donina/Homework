namespace kr1
{
    /// <summary>
    /// Priority queue, an abstract container of (priority, value) pairs.
    /// </summary>
    public class PriorityQueue
    {
        /// <summary>
        /// An element of the priority queue.
        /// </summary>
        private class Node
        {
            public string Data { get; private set; }
            public Node Next { get; set; }
            public int Key { get; private set; }

            public Node(int newKey, string newData, Node newNext)
            {
                Data = newData;
                Key = newKey;
                Next = newNext;
            }
        }

        /// <summary>
        /// The element first added to the priority queue.
        /// </summary>
        private Node head = null;

        /// <summary>
        /// The element last added to the priority queue.
        /// </summary>
        private Node tail = null;

        /// <summary>
        /// Checks if the priority queue is empty.
        /// </summary>
        /// <returns>True if the priority queue is empty and false if it's not.</returns>
        public bool IsEmpty() => head == null;

        private void EnqueueWhenQueueIsEmpty(int key, string data)
        {
            head = new Node(key, data, head);
            tail = head;
        }

        /// <summary>
        /// Adds (priority, value) pair to the priority queue.
        /// </summary>
        /// <param name="key">An integer number, priority of the value.</param>
        /// <param name="data">A string data to add.</param>
        public void Enqueue(int key, string data)
        {
            if (IsEmpty())
            {
                EnqueueWhenQueueIsEmpty(key, data);
                return;
            }

            tail.Next = new Node(key, data, null);
            tail = tail.Next;
        }

        private Node SearchMax()
        {
            var node = head;
            var maxPriority = head;
            while (node != null)
            {
                if (node.Key > maxPriority.Key)
                {
                    maxPriority = node;
                }
                node = node.Next;
            }
            return maxPriority;
        }

        private string DequeueFromHead(Node maxPriority)
        {
            head = maxPriority.Next;
            return maxPriority.Data;
        }

        private Node FindPreviousNode(Node node)
        {
            var temp = head.Next;
            var previous = head;

            while (temp != null)
            {
                if (temp == node)
                {
                    return previous;
                }

                previous = temp;
                temp = temp.Next;
            }

            return null;
        }

        /// <summary>
        /// Removes value with maximum priority from the priority queue.
        /// </summary>
        /// <returns>A value with maximum priority.</returns>
        public string Dequeue()
        {
            if (IsEmpty())
            {
                throw new DequeueWhenQueueIsEmptyException();
            }

            var maxPriority = SearchMax();

            if (maxPriority == head)
            {
                return DequeueFromHead(maxPriority);
            }

            var previous = FindPreviousNode(maxPriority);

            if (maxPriority != tail)
            {
                previous.Next = maxPriority.Next;
            }
            else
            {
                previous.Next = null;
                tail = previous;
            }

            return maxPriority.Data;
        }
    }
}
