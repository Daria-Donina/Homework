using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTree
{
    abstract class Operation : Node
    {
        public Node LeftChild { get; private set; }
        public Node RightChild { get; private set; }

        public override void Print()
        {
            Console.WriteLine('(');
            LeftChild.Print();
            Console.WriteLine(Data);
            RightChild.Print();
            Console.WriteLine(')');
        }
    }
}
