namespace Modified_Hash_Table
{
    public class FNVHashFunction : IHashFunction
    {
        private const ulong fnvOffsetBasis = 14695981039346656037;
        private const ulong fnvPrime = 1099511628211;

        public ulong Hash(string data)
        {
            var hash = fnvOffsetBasis;

            foreach(ulong symbol in data)
            {
                hash *= fnvPrime;
                hash ^= symbol;
            }

            return hash;
        }
    }
}
