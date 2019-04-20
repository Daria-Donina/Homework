using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTree
{
    class Division : Operation
    {
        private string data;
        public override string Data
        {
            get => data;
            set => data = "/";
        }

        public int Calculate()
        {
            return int.Parse(LeftChild.Data) / int.Parse(RightChild.Data);
        }
    }
}
