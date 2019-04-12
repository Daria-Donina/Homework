namespace ModifiedHashTable
{
    /// <summary>
    /// A non-cryptografic hash function.
    /// </summary>
    public class FNVHashFunction : IHashFunction
    {
        private const ulong fnvOffsetBasis = 14695981039346656037;
        private const ulong fnvPrime = 1099511628211;

        /// <summary>
        /// Returns hash code of a string.
        /// </summary>
        /// <param name="data">A string to get the hash code.</param>
        /// <returns>An unsigned integer hash code.</returns>
        public ulong Hash(string data)
        {
            var hash = fnvOffsetBasis;

            foreach (ulong symbol in data)
            {
                hash *= fnvPrime;
                hash ^= symbol;
            }

            return hash;
        }
    }
}
