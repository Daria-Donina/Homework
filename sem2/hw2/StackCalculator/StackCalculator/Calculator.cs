using System;

namespace StackCalculator
{
    class Calculator : ICalculator
    {
        private IStack stack;

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
                    stack.Push(firstOperand - secondOperand);
                    break;
                case '*':
                    stack.Push(firstOperand * secondOperand);
                    break;
                case '/':
                    stack.Push(firstOperand / secondOperand);
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
