using System;
using SinglyLinkedList;

namespace ModifiedHashTable
{
    /// <summary>
    /// Hash table, a data structure that is used to store (key, value) pairs.
    /// </summary>
    public class HashTable : IHashTable
    {
        private const uint initialSize = 5;

        /// <summary>
        /// Size of the buckets of the hash table.
        /// </summary>
        public uint Size { get; private set; }

        private List[] buckets;
        private int numberOfElements;
        private readonly IHashFunction hashFunction;

        public HashTable(IHashFunction hashFunction)
        {
            buckets = new List[initialSize];
            Size = initialSize;

            for (int i = 0; i < initialSize; ++i)
            {
                buckets[i] = new List();
            }

            this.hashFunction = hashFunction;
        }

        /// <summary>
        /// Adds string value to the hash table.
        /// </summary>
        /// <param name="data">A string to add.</param>
        public void Add(string data)
        {
            if (Exists(data))
            {
                Console.WriteLine("Value is already in the hash table");
                return;
            }

            var hash = HashFunction(data);
            const int position = 1;

            buckets[hash].Add(position, data);
            ++numberOfElements;

            if (LoadFactor() > 1)
            {
                Expand();
            }
        }

        private void Expand()
        {
            Size *= 2;
            var newBuckets = new List[Size];

            for (int i = 0; i < newBuckets.Length; ++i)
            {
                newBuckets[i] = new List();
            }

            foreach (var list in buckets)
            {
                const int position = 1;
                for (int i = 1; i <= list.Length; ++i)
                {
                    string data = list.GetData(i);
                    var hash = HashFunction(data);

                    newBuckets[hash].Add(position, data);
                }
            }

            buckets = newBuckets;
        }

        /// <summary>
        /// Removes string value from the hash table.
        /// </summary>
        /// <param name="data">A string to remove.</param>
        public void Remove(string data)
        {
            if (!Exists(data))
            {
                throw new InvalidOperationException();
            }

            var hash = HashFunction(data);
            int position = buckets[hash].FindPositionByData(data);
            buckets[hash].Remove(position);
        }

        /// <summary>
        /// Checks if value is in the hash table.
        /// </summary>
        /// <param name="data">A string to check if it's in the hash table.</param>
        /// <returns>True if string is in the hash table and false if it is not.</returns>
        public bool Exists(string data)
        {
            var hash = HashFunction(data);
            int position = buckets[hash].FindPositionByData(data);

            return position != -1;
        }

        private float LoadFactor() => (float)numberOfElements / Size;

        private ulong HashFunction(string data) => hashFunction.Hash(data) % Size;

        /// <summary>
        /// Prints hash table.
        /// </summary>
        public void Print()
        {
            Console.WriteLine("The hash table:");
            for (int i = 0; i < Size; ++i)
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
            for (int i = 0; i < Size; ++i)
            {
                buckets[i].Clear();
            }

            Size = initialSize;
        }
    }
}

