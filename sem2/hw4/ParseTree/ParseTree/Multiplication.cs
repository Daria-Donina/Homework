using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTree
{
    class Multiplication : Operation
    {
        private string data;
        public override string Data
        {
            get => data;
            set => data = "*";
        }

        public override int Calculate() => int.Parse(LeftChild.Data) * int.Parse(RightChild.Data);
    }
}
