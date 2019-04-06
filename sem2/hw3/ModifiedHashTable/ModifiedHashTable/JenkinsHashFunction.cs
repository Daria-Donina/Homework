using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedHashTable
{
    class JenkinsHashFunction : IHashFunction
    {
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
