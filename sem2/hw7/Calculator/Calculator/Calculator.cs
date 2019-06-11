using System;

namespace Calculator
{
    /// <summary>
    /// Class implementing object that calculates one operation expressions.
    /// </summary>
    public class Calculator
    {
        private double firstNumber;
        private double secondNumber;
        private string operation;
        private bool wasCalculated;
        private bool operationEntered;

        public double Calculate()
        {
            if (firstNumber == 0 && secondNumber == 0 && operation == "/")
            {
                return double.PositiveInfinity;
            }

            wasCalculated = true;

            if (operation == "+")
            {
                return firstNumber + secondNumber;
            }
            else if (operation == "-")
            {
                return firstNumber - secondNumber;
            }
            else if (operation == "*" || operation == "×")
            {
                return firstNumber * secondNumber;
            }
            else if (operation == "/" || operation == "÷")
            {
                return firstNumber / secondNumber;
            }
            else
            {
                throw new FormatException();
            }
        }

        private const double maximum = 1000000000;
        private const double minimum = -1000000000;
        private const int maximumLength = 18;

        public string CurrentNumberTextBoxText { get; private set; }
        public bool CurrentNumberTextBoxEnabled { get; private set; }

        private const string divideByZeroErrorText = "You cannot divide by zero";
        private const string tooBigNumberErrorText = "The number is too big";

        public void DigitEntered(string buttonText)
        {
            if (ExpressionLabelText == divideByZeroErrorText ||
                ExpressionLabelText == tooBigNumberErrorText)
            {
                ExpressionLabelText = "";
            }

            CurrentNumberTextBoxEnabled = true;

            if (wasCalculated || CurrentNumberTextBoxText == "0")
            {
                CurrentNumberTextBoxText = buttonText;
                ChangeCalculatorData();
                wasCalculated = false;
            }
            else if (firstNumber != 0 && !operationEntered
                || secondNumber != 0 && operationEntered
                || CurrentNumberTextBoxText == "0,")
            {
                if (double.Parse(CurrentNumberTextBoxText) >= maximum ||
                    double.Parse(CurrentNumberTextBoxText) <= minimum ||
                    CurrentNumberTextBoxText.Length >= maximumLength)
                {
                    Clear();
                    throw new ArgumentException();
                }
                else
                {
                    CurrentNumberTextBoxText += buttonText;
                    ChangeCalculatorData();
                }
            }
            else
            {
                CurrentNumberTextBoxText = buttonText;
                ChangeCalculatorData();
            }
        }

        public void Clear()
        {
            firstNumber = 0;
            operation = "";
            secondNumber = 0;
            wasCalculated = false;
            operationEntered = false;
            CurrentNumberTextBoxText = "0";
            ExpressionLabelText = "";
        }

        private void ChangeCalculatorData()
        {
            if (operationEntered)
            {
                secondNumber = double.Parse(CurrentNumberTextBoxText);
            }
            else
            {
                firstNumber = double.Parse(CurrentNumberTextBoxText);
            }
        }

        public void SignChanged()
        {
            if (double.Parse(CurrentNumberTextBoxText) > 0)
            {
                CurrentNumberTextBoxText = "-" + CurrentNumberTextBoxText;
            }
            else if (double.Parse(CurrentNumberTextBoxText) < 0)
            {
                CurrentNumberTextBoxText = CurrentNumberTextBoxText.Substring(1, CurrentNumberTextBoxText.Length - 1);
            }

            ChangeCalculatorData();
        }

        public void DecimalSeparatorEntered()
        {
            if (!CurrentNumberTextBoxText.Contains(","))
            {
                CurrentNumberTextBoxText += ",";
                ChangeCalculatorData();
            }
        }

        public void EqualPressed()
        {
            ExpressionLabelText = "";
            var result = Calculate();

            if (result == double.PositiveInfinity || result == double.NegativeInfinity)
            {
                throw new DivideByZeroException();
            }
            else if (result >= maximum || result <= minimum || result.ToString().Length >= maximumLength)
            {
                throw new ArgumentException();
            }
            else
            {
                CurrentNumberTextBoxText = result.ToString();
                operationEntered = false;
                ChangeCalculatorData();
                secondNumber = 0;
            }
        }

        public string ExpressionLabelText { get; private set; }

        public void OperationPressed(string buttonText)
        {
            if (!operationEntered)
            {
                operation = $"{buttonText}";
                operationEntered = true;
                ExpressionLabelText += " " + CurrentNumberTextBoxText + " " + $"{buttonText}";
            }
            else if (wasCalculated)
            {
                ExpressionLabelText = ExpressionLabelText.Substring(0, ExpressionLabelText.Length - 1);

                ExpressionLabelText += $"{buttonText}";

                operation = $"{buttonText}";
            }
            else
            {
                ExpressionLabelText += " " + CurrentNumberTextBoxText + " " + $"{buttonText}";
                firstNumber = Calculate();

                if (firstNumber == double.PositiveInfinity ||
                    firstNumber == double.NegativeInfinity)
                {
                    throw new DivideByZeroException();
                }
                else if (firstNumber >= maximum || firstNumber <= minimum ||
                    firstNumber.ToString().Length >= maximumLength)
                {
                    throw new ArgumentException();
                }
                else
                {
                    operation = $"{buttonText}";
                    CurrentNumberTextBoxText = $"{firstNumber}";
                }
            }
        }

        public void RemoveLastDigit()
        {
            CurrentNumberTextBoxText = CurrentNumberTextBoxText.Substring(0, CurrentNumberTextBoxText.Length - 1);

            if (CurrentNumberTextBoxText == "" || CurrentNumberTextBoxText == "-")
            {
                CurrentNumberTextBoxText = "0";
            }

            ChangeCalculatorData();
        }

        public void RemoveCurrentNumber()
        {
            CurrentNumberTextBoxText = "0";
            ChangeCalculatorData();
        }
    }
}
