using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTree
{
    public abstract class Node
    {
        public virtual string Data { get; set; }

        public abstract void Print();

        public abstract int Calculate();
    }
}
