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

        public void Push(int value)
        {
            if (topIndex >= size)
            {
                Array.Resize(ref stack, size * 2);
            }

            stack[topIndex] = value;
            ++topIndex;
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Removing from the empty stack");
            }

            var temp = Peek();
            stack[topIndex] = 0;
            --topIndex;
            return temp;
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Peek from the empty stack");
            }

            return stack[topIndex - 1];
        }

        public bool IsEmpty() => topIndex == 0;
    }
}
