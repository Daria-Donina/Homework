namespace Modified_Hash_Table
{
    /// <summary>
    /// Interface for hash table, a data structure that is used to store (key, value) pairs.
    /// </summary>
    interface IHashTable
    {
        /// <summary>
        /// Adds string value to the hash table.
        /// </summary>
        /// <param name="data">A string to add.</param>
        void Add(string data);

        /// <summary>
        /// Removes string value from the hash table.
        /// </summary>
        /// <param name="data">A string to remove.</param>
        void Remove(string data);

        /// <summary>
        /// Checks if value is in the hash table.
        /// </summary>
        /// <param name="data">A string to check if it's in the hash table.</param>
        /// <returns>True if string is in the hash table and false if it is not.</returns>
        bool Exists(string data);

        /// <summary>
        /// Prints hash table.
        /// </summary>
        void Print();

        /// <summary>
        /// Removes all the elements from the hash table.
        /// </summary>
        void Clear();
    }
}
