using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTree
{
    public class ParseTree
    {
        private Node root;

        public ParseTree(Node root)
        {
            this.root = root;
        }

        public bool IsEmpty() => root == null;

        public int Calculate() => root.Calculate();

        public void Print() => root.Print();
    }
}
