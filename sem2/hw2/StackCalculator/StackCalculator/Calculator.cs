using System;

namespace StackCalculator
{
    /// <summary>
    /// An object that calculate postfix expressions of basic operations and integer numbers.
    /// </summary>
    class Calculator : ICalculator
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
        /// <returns>The result of calculation.</returns>
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
                ThrowingFormatException();
            }

            return answer;
        }

        private void Operations(string symbol)
        {
            if (!char.TryParse(symbol, out char operation))
            {
                ThrowingFormatException();
            }

            var firstOperand = stack.Pop();
            var secondOperand = stack.Pop();

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
                    ThrowingFormatException();
                    break;
            }
        }

        private void ThrowingFormatException()
        {
            throw new FormatException("The expression is incorrect");
        }
    }
}
