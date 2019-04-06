namespace Modified_Hash_Table
{
    /// <summary>
    /// Interface for hash table, a data structure that is used to store (key, value) pairs.
    /// </summary>
    interface IHashTable
    {
        /// <summary>
        /// Adds value to the hash table.
        /// </summary>
        /// <param name="value">An integer number to add.</param>
        void Add(int value);

        /// <summary>
        /// Removes value from the hash table.
        /// </summary>
        /// <param name="value">An integer number to remove.</param>
        void Remove(int value);

        /// <summary>
        /// Checks if value is in the hash table.
        /// </summary>
        /// <param name="value">An integer number to check if it's in the hash table.</param>
        /// <returns>True if value is in the hash table and false if it is not.</returns>
        bool Exists(int value);

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
