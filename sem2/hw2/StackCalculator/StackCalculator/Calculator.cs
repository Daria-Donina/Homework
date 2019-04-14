using System;

namespace StackCalculator
{
    /// <summary>
    /// An object that calculate postfix expressions of basic operations and integer numbers.
    /// </summary>
    public class Calculator : ICalculator
    {
        private IStack stack;

        public Calculator(IStack stack)
        {
            this.stack = stack;
        }

        /// <summary>
        /// Calculates postfix expression.
        /// </summary>
        /// <param name="expression">An expression to calculate.</param>
        /// <returns>Result of the calculation.</returns>
        public int Calculate(string expression)
        {
            var splitedExpression = expression.Split(' ');

            foreach (var symbol in splitedExpression)
            {
                if (int.TryParse(symbol, out int operand))
                {
                    stack.Push(operand);
                }
                else
                {
                    Operations(symbol);
                }
            }

            var answer = stack.Pop();
            if (!stack.IsEmpty())
            {
                throw new FormatException("The expression is incorrect");
            }

            return answer;
        }

        private void Operations(string symbol)
        {
            if (!char.TryParse(symbol, out char operation))
            {
                throw new FormatException("The expression is incorrect");
            }

            var firstOperand = 0;
            var secondOperand = 0;

            if (!stack.IsEmpty())
            {
                firstOperand = stack.Pop();

                if (!stack.IsEmpty())
                {
                    secondOperand = stack.Pop();
                }
                else
                {
                    throw new FormatException("The expression is incorrect");
                }
            }
            else
            {
                throw new FormatException("The expression is incorrect");
            }

            switch (operation)
            {
                case '+':
                    stack.Push(firstOperand + secondOperand);
                    break;
                case '-':
                    stack.Push(secondOperand - firstOperand);
                    break;
                case '*':
                    stack.Push(firstOperand * secondOperand);
                    break;
                case '/':
                    stack.Push(secondOperand / firstOperand);
                    break;
                default:
                    throw new FormatException("The expression is incorrect");
            }
        }
    }
}
