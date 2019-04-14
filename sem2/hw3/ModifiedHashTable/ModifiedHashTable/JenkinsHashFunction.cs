namespace ModifiedHashTable
{
    /// <summary>
    /// A non-cryptografic hash function.
    /// </summary>
    public class JenkinsHashFunction : IHashFunction
    {
        /// <summary>
        /// Returns hash code of a string.
        /// </summary>
        /// <param name="data">A string to get the hash code.</param>
        /// <returns>An unsigned integer hash code.</returns>
        public ulong Hash(string data)
        {
            ulong hash = 0;

            foreach(ulong symbol in data)
            {
                hash += symbol;
                hash += hash << 10;
                hash ^= hash >> 6;
            }

            hash += hash << 3;
            hash ^= hash >> 11;
            hash += hash << 15;
            return hash;
        }
    }
}
