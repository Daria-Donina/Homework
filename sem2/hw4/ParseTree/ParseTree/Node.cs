using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTree
{
    abstract class Node
    {
        public abstract string Data { get; set; }

        public abstract void Print();
    }
}
