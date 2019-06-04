using System;

namespace Calculator
{
    class OneOperationCalculator
    {
        private double firstNumber;
        private double secondNumber;
        private string operation;

        public OneOperationCalculator(double firstNumber, string operation, double secondNumber)
        {
            this.firstNumber = firstNumber;
            this.operation = operation;
            this.secondNumber = secondNumber;
        }

        public double Calculate()
        {
            switch (operation)
            {
                case "+":
                    return firstNumber + secondNumber;
                case "-":
                    return firstNumber - secondNumber;
                case "×":
                    return firstNumber * secondNumber;
                case "÷":
                    return firstNumber / secondNumber;
                default:
                    throw new FormatException();
            }
        }
    }
}
