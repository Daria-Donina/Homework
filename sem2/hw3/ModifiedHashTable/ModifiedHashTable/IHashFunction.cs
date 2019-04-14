namespace ModifiedHashTable
{
    /// <summary>
    /// An interface for hash function working with string values.
    /// </summary>
    public interface IHashFunction
    {
        /// <summary>
        /// Returns hash code of a string.
        /// </summary>
        /// <param name="data">A string to get the hash code.</param>
        /// <returns>An unsigned integer hash code.</returns>
        ulong Hash(string data);
    }
}
