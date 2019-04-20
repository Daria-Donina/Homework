using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTree
{
    class Operand : Node
    {
        private int number;

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = TransferToNumber();
            }
        }

        private int TransferToNumber()
        {
            if (int.TryParse(Data, out int result))
            {
                return result;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public override void Print() => Console.WriteLine(Data);

        public override int Calculate() => Number;
    }
}
