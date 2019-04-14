namespace StackCalculator
{
    /// <summary>
    /// Interface for an object that calculate postfix expressions of basic operations and integer numbers.
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// Calculates postfix expression.
        /// </summary>
        /// <param name="expression">An expression to calculate.</param>
        /// <returns>Result of the calculation.</returns>
        int Calculate(string expression);
    }
}
