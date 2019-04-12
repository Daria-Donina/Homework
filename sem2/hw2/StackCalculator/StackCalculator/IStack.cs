namespace StackCalculator
{
    /// <summary>
    /// Interface for last-in-fisrt-out container of integer values.
    /// </summary>
    public interface IStack
    {
        /// <summary>
        /// Adds value to the top of the stack.
        /// </summary>
        /// <param name="value">Value to push into stack.</param>
        void Push(int value);

        /// <summary>
        /// Removes value from the top of the stack.
        /// </summary>
        /// <returns>The value that has been deleted.</returns>
        int Pop();

        /// <summary>
        /// Checks if the stack is empty.
        /// </summary>
        /// <returns>True if the stack is empty, false if it is not.</returns>
        bool IsEmpty();

        /// <summary>
        /// Shows the value at the top of the stack.
        /// </summary>
        /// <returns>The value at the top of the stack.</returns>
        int Peek();
    }
}
