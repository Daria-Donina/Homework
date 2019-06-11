using System;

namespace Calculator
{
    /// <summary>
    /// Class implementing object that calculates one operation expressions.
    /// </summary>
    public class Calculator
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public string Operation { private get; set; }
        public bool WasCalculated { get; set; }
        public bool OperationEntered { get; set; }

        public double Calculate()
        {
            if (FirstNumber == 0 && SecondNumber == 0 && Operation == "/")
            {
                return double.PositiveInfinity;
            }

            WasCalculated = true;

            if (Operation == "+")
            {
                return FirstNumber + SecondNumber;
            }
            else if (Operation == "-")
            {
                return FirstNumber - SecondNumber;
            }
            else if (Operation == "*" || Operation == "×")
            {
                return FirstNumber * SecondNumber;
            }
            else if (Operation == "/" || Operation == "÷")
            {
                return FirstNumber / SecondNumber;
            }
            else
            {
                throw new FormatException();
            }
        }

        private const double maximum = 1000000000;
        private const double minimum = -1000000000;
        private const int maximumLength = 18;

        public string DigitEntered(string currentNumberTextBoxText, string buttonText)
        {
            if (WasCalculated || currentNumberTextBoxText == "0")
            {
                currentNumberTextBoxText = buttonText;
                ChangeCalculatorData(currentNumberTextBoxText);
                WasCalculated = false;
            }
            else if (FirstNumber != 0 && !OperationEntered
                || SecondNumber != 0 && OperationEntered
                || currentNumberTextBoxText == "0,")
            {
                if (double.Parse(currentNumberTextBoxText) >= maximum ||
                    double.Parse(currentNumberTextBoxText) <= minimum ||
                    currentNumberTextBoxText.Length >= maximumLength)
                {
                    OnClearButtonClick();
                    throw new ArgumentException();
                }
                else
                {
                    currentNumberTextBoxText += buttonText;
                    ChangeCalculatorData(currentNumberTextBoxText);
                }
            }
            else
            {
                currentNumberTextBoxText = buttonText;
                ChangeCalculatorData(currentNumberTextBoxText);
            }

            return currentNumberTextBoxText;
        }

        public void OnClearButtonClick()
        {
            FirstNumber = 0;
            Operation = "";
            SecondNumber = 0;
            WasCalculated = false;
            OperationEntered = false;
        }

        private void ChangeCalculatorData(string currentNumberTextBoxText)
        {
            if (OperationEntered)
            {
                SecondNumber = double.Parse(currentNumberTextBoxText);
            }
            else
            {
                FirstNumber = double.Parse(currentNumberTextBoxText);
            }
        }

        public string OnChangeSignButtonClick(string currentNumberTextBoxText)
        {
            var number = currentNumberTextBoxText;

            if (double.Parse(number) > 0)
            {
                number = "-" + number;
            }
            else if (double.Parse(number) < 0)
            {
                number = number.Substring(1, number.Length - 1);
            }

            currentNumberTextBoxText = number;
            ChangeCalculatorData(currentNumberTextBoxText);

            return currentNumberTextBoxText;
        }

        public string OnDecimalSeparatorButtonClick(string currentNumberTextBoxText)
        {
            var number = currentNumberTextBoxText;

            if (!number.Contains(","))
            {
                currentNumberTextBoxText += ",";
                ChangeCalculatorData(currentNumberTextBoxText);
            }

            return currentNumberTextBoxText;
        }

        public string OnEqualButtonClick(string currentNumberTextBoxText)
        {
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
                currentNumberTextBoxText = result.ToString();
                OperationEntered = false;
                ChangeCalculatorData(currentNumberTextBoxText);
                SecondNumber = 0;
                return currentNumberTextBoxText;
            }
        }

        public (string, string) OnOperationButtonClick(string buttonText, string currentNumberTextBoxText, string expressionLabelText)
        {
            if (!OperationEntered)
            {
                Operation = $"{buttonText}";
                OperationEntered = true;
                expressionLabelText += " " + currentNumberTextBoxText + " " + $"{buttonText}";
            }
            else if (WasCalculated)
            {
                expressionLabelText = expressionLabelText.Substring(0, expressionLabelText.Length - 1);

                expressionLabelText += $"{buttonText}";

                Operation = $"{buttonText}";
            }
            else
            {
                expressionLabelText += " " + currentNumberTextBoxText + " " + $"{buttonText}";
                FirstNumber = Calculate();

                if (FirstNumber == double.PositiveInfinity ||
                    FirstNumber == double.NegativeInfinity)
                {
                    throw new DivideByZeroException();
                }
                else if (FirstNumber >= maximum || FirstNumber <= minimum ||
                    FirstNumber.ToString().Length >= maximumLength)
                {
                    throw new ArgumentException();
                }
                else
                {
                    Operation = $"{buttonText}";
                    currentNumberTextBoxText = $"{FirstNumber}";
                }
            }

            return (currentNumberTextBoxText, expressionLabelText);
        }

        public string OnBackspaceButtonClick(string currentNumberTextBoxText)
        {
            currentNumberTextBoxText = currentNumberTextBoxText.Substring(0, currentNumberTextBoxText.Length - 1);

            if (currentNumberTextBoxText == "" || currentNumberTextBoxText == "-")
            {
                currentNumberTextBoxText = "0";
            }

            ChangeCalculatorData(currentNumberTextBoxText);

            return currentNumberTextBoxText;
        }

        public void OnRemoveCurrentNumberButtonClick(string currentNumberTextBoxText) => ChangeCalculatorData(currentNumberTextBoxText);
    }
}
