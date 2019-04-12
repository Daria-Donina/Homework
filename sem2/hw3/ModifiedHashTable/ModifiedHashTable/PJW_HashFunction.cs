namespace ModifiedHashTable
{
    /// <summary>
    /// A non-cryptografic hash function.
    /// </summary>
    public class PJWHashFunction : IHashFunction
    {
        private const int bitsInULong = sizeof(ulong) * 8;
        private const ulong highBits = (ulong)(0xFFFFFFFF) << (bitsInULong - bitsInULong / 8);

        /// <summary>
        /// Returns hash code of a string.
        /// </summary>
        /// <param name="data">A string to get the hash code.</param>
        /// <returns>An unsigned integer hash code.</returns>
        public ulong Hash(string data)
        {
            ulong hash = 0;
            ulong test;

            foreach(ulong symbol in data)
            {
                hash = (hash << bitsInULong / 8) + symbol;
                test = hash & highBits;

                if (test != 0)
                {
                    hash = (hash ^ (test >> bitsInULong * 3 / 4)) & (~highBits);
                }
            }

            return hash;
        }
    }
}
