using System;
using SinglyLinkedList;

namespace Modified_Hash_Table
{
    /// <summary>
    /// Hash table, a data structure that is used to store (key, value) pairs.
    /// </summary>
    public class HashTable : IHashTable
    {
        private const int initialSize = 5;
        private int size = initialSize;
        private List[] buckets;
        private int numberOfElements;

        public HashTable()
        {
            buckets = new List[size];

            for (int i = 0; i < size; ++i)
            {
                buckets[i] = new List();
            }
        }

        /// <summary>
        /// Adds value to the hash table.
        /// </summary>
        /// <param name="value">An integer number to add.</param>
        public void Add(int value)
        {
            if (Exists(value))
            {
                Console.WriteLine("Value is already in the hash table");
                return;
            }

            int hash = HashFunction(value);
            const int position = 1;

            buckets[hash].Add(position, value);
            ++numberOfElements;

            if (LoadFactor() > 1)
            {
                Expand();
            }
        }

        private void Expand()
        {
            size = size * 2;
            var newBuckets = new List[size];

            for (int i = 0; i < newBuckets.Length; ++i)
            {
                newBuckets[i] = new List();
            }

            foreach (var list in buckets)
            {
                const int position = 1;
                for (int i = 1; i <= list.Length; ++i)
                {
                    int value = list.GetValue(i);
                    int hash = HashFunction(value);

                    newBuckets[hash].Add(position, value);
                }
            }

            buckets = newBuckets;
        }

        /// <summary>
        /// Removes value from the hash table.
        /// </summary>
        /// <param name="value">An integer number to remove.</param>
        public void Remove(int value)
        {
            if (!Exists(value))
            {
                Console.Write("There's no such value in the hash table");
                return;
            }

            int hash = HashFunction(value);
            int position = buckets[hash].FindPositionByValue(value);
            buckets[hash].Remove(position);
        }

        /// <summary>
        /// Checks if value is in the hash table.
        /// </summary>
        /// <param name="value">An integer number to check if it's in the hash table.</param>
        /// <returns>True if value is in the hash table and false if it is not.</returns>
        public bool Exists(int value)
        {
            int hash = HashFunction(value);
            int position = buckets[hash].FindPositionByValue(value);

            return position != 1;
        }

        private float LoadFactor() => (float)numberOfElements / size;

        private int HashFunction(int value) => Math.Abs(value) % size;

        /// <summary>
        /// Prints hash table.
        /// </summary>
        public void Print()
        {
            Console.WriteLine("The hash table:");
            for (int i = 0; i < size; ++i)
            {
                var list = buckets[i];
                Console.Write($"[{i}]: ");
                list.Print();
            }
        }

        /// <summary>
        /// Removes all the elements from the hash table.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < size; ++i)
            {
                buckets[i].Clear();
            }

            size = initialSize;
        }
    }
}

