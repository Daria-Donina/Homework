namespace SinglyLinkedList
{
    /// <summary>
    /// An interface for a list, container of string values.
    /// </summary>
    interface IList
    {
        /// <summary>
        /// Adds data at the given position of the list.
        /// </summary>
        /// <param name="position">A number of position in the list to add a string.</param>
        /// <param name="data">A string to add.</param>
        void Add(int position, string data);

        /// <summary>
        /// Removes data from the given position of the list.
        /// </summary>
        /// <param name="position">A number of position in the list to remove a string.</param>
        void Remove(int position);

        /// <summary>
        /// Checks if the list is empty.
        /// </summary>
        /// <returns>True if the list is empty and false if it's not.</returns>
        bool IsEmpty();

        /// <summary>
        /// Returns data at the given position of the list.
        /// </summary>
        /// <param name="position">A number of position in the list to get data.</param>
        /// <returns>Data at the given position.</returns>
        string GetData(int position);

        /// <summary>
        /// Sets new data at the given position of the list.
        /// </summary>
        /// <param name="position">A number of position in the list to set new data.</param>
        /// <param name="data">A string to add.</param>
        void SetData(int position, string data);

        /// <summary>
        /// Prints all the elements of the list.
        /// </summary>
        void Print();

        /// <summary>
        /// Finds a serial number of a string in the list and returns that number.
        /// </summary>
        /// <param name="data">A string which position to be returned.</param>
        /// <returns>A serial number of string in the list or -1 if string is not in the list.</returns>
        int FindPositionByData(string data);

        /// <summary>
        /// Removes all the elements from list.
        /// </summary>
        void Clear();
    }
}
