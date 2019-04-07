namespace Modified_Hash_Table
{
    class PJWHashFunction : IHashFunction
    {
        private const int bitsInULong = sizeof(ulong) * 8;
        private const ulong highBits = (ulong)(0xFFFFFFFF) << (bitsInULong - bitsInULong / 8);

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
