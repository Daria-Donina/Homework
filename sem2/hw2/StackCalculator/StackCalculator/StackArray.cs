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

        /// <summary>
        /// Adds value to the top of the stack.
        /// </summary>
        /// <param name="value">Value to push into stack.</param>
        public void Push(int value)
        {
            if (topIndex >= size)
            {
                Array.Resize(ref stack, size * 2);
            }

            stack[topIndex] = value;
            ++topIndex;
        }

        /// <summary>
        /// Removes value from the top of the stack.
        /// </summary>
        /// <returns>The value that has been deleted.</returns>
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

        /// <summary>
        /// Shows the value at the top of the stack.
        /// </summary>
        /// <returns>The value at the top of the stack.</returns>
        public int Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Peek from the empty stack");
            }

            return stack[topIndex - 1];
        }

        /// <summary>
        /// Checks if the stack is empty.
        /// </summary>
        /// <returns>True if the stack is empty, false if it is not.</returns>
        public bool IsEmpty() => topIndex == 0;
    }
}
