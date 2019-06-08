using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void CalculatorLoad(object sender, EventArgs e)
        {
            currentNumberTextBox.Select();
        }

        private const string divideByZeroErrorText = "You cannot divide by zero";
        private const string tooBigNumberErrorText = "The number is too big";
        private const double maximum = 1000000000;
        private const double minimum = -1000000000;
        private const int maximumLength = 18;

        private void OnDigitButtonClick(object sender, EventArgs e)
        {
            if (expressionLabel.Text == divideByZeroErrorText ||
                expressionLabel.Text == tooBigNumberErrorText)
            {
                expressionLabel.Text = "";
            }

            currentNumberTextBox.Enabled = true;
            var button = (Button)sender;

            if (Calculator.WasCalculated || currentNumberTextBox.Text == "0")
            {
                currentNumberTextBox.Text = button.Text;
                ChangeCalculatorData();
                Calculator.WasCalculated = false;
            }
            else if (Calculator.FirstNumber != 0 && !Calculator.OperationEntered
                || Calculator.SecondNumber != 0 && Calculator.OperationEntered
                || currentNumberTextBox.Text == "0,")
            {
                if (double.Parse(currentNumberTextBox.Text) >= maximum || 
                    double.Parse(currentNumberTextBox.Text) <= minimum ||
                    currentNumberTextBox.Text.Length >= maximumLength)
                {
                    ErrorHandling(sender, e, tooBigNumberErrorText);
                }
                else
                {
                    currentNumberTextBox.Text += button.Text;
                    ChangeCalculatorData();
                }
            }
            else
            {
                currentNumberTextBox.Text = button.Text;
                ChangeCalculatorData();
            }
        }

        private void ChangeCalculatorData()
        {
            if (Calculator.OperationEntered)
            {
                Calculator.SecondNumber = double.Parse(currentNumberTextBox.Text);
            }
            else
            {
                Calculator.FirstNumber = double.Parse(currentNumberTextBox.Text);
            }
        }

        private void OnChangeSignButtonClick(object sender, EventArgs e)
        {
            var number = currentNumberTextBox.Text;

            if (double.Parse(number) > 0)
            {
                number = "-" + number;
            }
            else if (double.Parse(number) < 0)
            {
                number = number.Substring(1, number.Length - 1);
            }

            currentNumberTextBox.Text = number;
            ChangeCalculatorData();
        }

        private void OnDecimalSeparatorButtonClick(object sender, EventArgs e)
        {
            var number = currentNumberTextBox.Text;

            if (!number.Contains(","))
            {
                currentNumberTextBox.Text += ",";
                ChangeCalculatorData();
            }
        }

        private void OnEqualButtonClick(object sender, EventArgs e)
        {
            expressionLabel.Text = "";
            var result = Calculator.Calculate();

            if (result == double.PositiveInfinity || result == double.NegativeInfinity)
            {
                ErrorHandling(sender, e, divideByZeroErrorText);
            }
            else if (result >= maximum || result <= minimum || result.ToString().Length >= maximumLength)
            {
                ErrorHandling(sender, e, tooBigNumberErrorText);
            }
            else
            {
                currentNumberTextBox.Text = result.ToString();
                Calculator.OperationEntered = false;
                ChangeCalculatorData();
                Calculator.SecondNumber = 0;
            }
        }

        private void OnOperationButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (!Calculator.OperationEntered)
            {
                Calculator.Operation = $"{button.Text}";
                Calculator.OperationEntered = true;
                expressionLabel.Text += " " + currentNumberTextBox.Text + " " + $"{button.Text}";
            }
            else if (Calculator.WasCalculated)
            {
                var expression = expressionLabel.Text;
                expression = expression.Substring(0, expression.Length - 1);

                expression += $"{button.Text}";
                expressionLabel.Text = expression;
                Calculator.Operation = $"{button.Text}";
            }
            else
            {
                expressionLabel.Text += " " + currentNumberTextBox.Text + " " + $"{button.Text}";
                Calculator.FirstNumber = Calculator.Calculate();

                if (Calculator.FirstNumber == double.PositiveInfinity ||
                    Calculator.FirstNumber == double.NegativeInfinity)
                {
                    ErrorHandling(sender, e, divideByZeroErrorText);
                }
                else if (Calculator.FirstNumber >= maximum || Calculator.FirstNumber <= minimum ||
                    Calculator.FirstNumber.ToString().Length >= maximumLength)
                {
                    ErrorHandling(sender, e, tooBigNumberErrorText);
                }
                else
                {
                    Calculator.Operation = $"{button.Text}";
                    currentNumberTextBox.Text = $"{Calculator.FirstNumber}";
                }
            }
        }

        private void ErrorHandling(object sender,EventArgs e, string errorText)
        {
            OnClearButtonClick(sender, e);
            expressionLabel.Text = errorText;
            currentNumberTextBox.Enabled = false;
        }

        private void OnRemoveCurrentNumberButtonClick(object sender, EventArgs e)
        {
            currentNumberTextBox.Text = "0";
            ChangeCalculatorData();
        }

        private void OnClearButtonClick(object sender, EventArgs e)
        {
            currentNumberTextBox.Text = "0";
            expressionLabel.Text = "";
            Calculator.FirstNumber = 0;
            Calculator.Operation = "";
            Calculator.SecondNumber = 0;
            Calculator.WasCalculated = false;
            Calculator.OperationEntered = false;
        }

        private void OnBackspaceButtonClick(object sender, EventArgs e)
        {
            var number = currentNumberTextBox.Text;
            number = number.Substring(0, number.Length - 1);

            if (number == "" || number == "-")
            {
                number = "0";
            }

            currentNumberTextBox.Text = number;
            ChangeCalculatorData();
        }

        private void CurrentNumberTextBoxTextChanged(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                switch (e.KeyChar)
                {
                    case '0':
                        OnDigitButtonClick(zeroButton, e);
                        break;
                    case '1':
                        OnDigitButtonClick(oneButton, e);
                        break;
                    case '2':
                        OnDigitButtonClick(twoButton, e);
                        break;
                    case '3':
                        OnDigitButtonClick(threeButton, e);
                        break;
                    case '4':
                        OnDigitButtonClick(fourButton, e);
                        break;
                    case '5':
                        OnDigitButtonClick(fiveButton, e);
                        break;
                    case '6':
                        OnDigitButtonClick(sixButton, e);
                        break;
                    case '7':
                        OnDigitButtonClick(sevenButton, e);
                        break;
                    case '8':
                        OnDigitButtonClick(eightButton, e);
                        break;
                    case '9':
                        OnDigitButtonClick(nineButton, e);
                        break;
                }
            }
            else if (e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || e.KeyChar == '/')
            {
                switch (e.KeyChar)
                {
                    case '+':
                        OnOperationButtonClick(addButton, e);
                        break;
                    case '-':
                        OnOperationButtonClick(subtractButton, e);
                        break;
                    case '*':
                        OnOperationButtonClick(multiplyButton, e);
                        break;
                    case '/':
                        OnOperationButtonClick(divideButton, e);
                        break;
                }
            }
            else if (e.KeyChar == '=' || e.KeyChar == (char)Keys.Enter)
            {
                OnEqualButtonClick(equalButton, e);
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                OnClearButtonClick(clearButton, e);
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                OnBackspaceButtonClick(backspaceButton, e);
            }
            else if (e.KeyChar == ',')
            {
                OnDecimalSeparatorButtonClick(decimalSeparatorButton, e);
            }

            e.Handled = true;
        }
    }
}
