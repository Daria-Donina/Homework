using System;

namespace StackCalculator
{
    /// <summary>
    /// Last-in-first-out container of integer values based on a list.
    /// </summary>
    class StackList : IStack
    {
        private class StackElement
        {
            public int Value { get; set; }
            public StackElement Next { get; set; }

            public StackElement(int newValue, StackElement newNext)
            {
                Value = newValue;
                Next = newNext;
            }
        }

        private StackElement head;

        /// <summary>
        /// Adds value to the top of the stack.
        /// </summary>
        /// <param name="value">Value to push into stack.</param>
        public void Push(int value)
        {
            head = new StackElement(value, head);
        }

        /// <summary>
        /// Checks if the stack is empty.
        /// </summary>
        /// <returns>True if the stack is empty, false if it is not.</returns>
        public bool IsEmpty() => head == null;

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
            head = head.Next;
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

            return head.Value;
        }
    }
}
