using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculator
{
    class StackArray : IStack
    {
        private const int size = 100;
        private int[] stack = new int[size];
        private int topIndex = 0;

        public bool Push(char value)
        {
            if (!char.IsDigit(value))
            {
                return false;
            }

            if (topIndex >= size)
            {
                Array.Resize(ref stack, size * 2);
            }

            stack[topIndex] = value;
            ++topIndex;
            return true;
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Removing from the empty stack");
            }

            var temp = Peek();
            --topIndex;
            return temp;
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Peek from the empty stack");
            }

            return stack[topIndex];
        }

        public bool IsEmpty() => topIndex == 0;
    }
}
