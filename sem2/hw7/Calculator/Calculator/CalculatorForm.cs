using System;
using System.Windows.Forms;

namespace Calculator
{
    /// <summary>
    /// Class implementing user interface of the calculator. 
    /// </summary>
    public partial class CalculatorForm : Form
    {
        private Calculator calculator;
        public CalculatorForm()
        {
            calculator = new Calculator();
            InitializeComponent();
        }

        private void CalculatorLoad(object sender, EventArgs e) => currentNumberTextBox.Select();

        private const string divideByZeroErrorText = "You cannot divide by zero";
        private const string tooBigNumberErrorText = "The number is too big";

        private void OnDigitButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (expressionLabel.Text == divideByZeroErrorText ||
                expressionLabel.Text == tooBigNumberErrorText)
                {
                    expressionLabel.Text = "";
                }

                currentNumberTextBox.Enabled = true;

                var button = (Button)sender;

                currentNumberTextBox.Text = calculator.DigitEntered(currentNumberTextBox.Text, button.Text);
            }
            catch (ArgumentException)
            {
                ErrorHandling(tooBigNumberErrorText);
            }
        }

        private void OnChangeSignButtonClick(object sender, EventArgs e) => currentNumberTextBox.Text = calculator.OnChangeSignButtonClick(currentNumberTextBox.Text);

        private void OnDecimalSeparatorButtonClick(object sender, EventArgs e)
        {
            if (currentNumberTextBox.Enabled)
            {
                currentNumberTextBox.Text = calculator.OnDecimalSeparatorButtonClick(currentNumberTextBox.Text);
            }
        }

        private void OnEqualButtonClick(object sender, EventArgs e)
        {
            if (currentNumberTextBox.Enabled)
            {
                expressionLabel.Text = "";

                try
                {
                    currentNumberTextBox.Text = calculator.OnEqualButtonClick(currentNumberTextBox.Text);
                }
                catch (DivideByZeroException)
                {
                    ErrorHandling(divideByZeroErrorText);
                }
                catch (ArgumentException)
                {
                    ErrorHandling(tooBigNumberErrorText);
                }
            }
        }

        private void OnOperationButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (currentNumberTextBox.Enabled)
            {
                try
                {
                    (currentNumberTextBox.Text, expressionLabel.Text) = calculator.OnOperationButtonClick(button.Text, currentNumberTextBox.Text, expressionLabel.Text);
                }
                catch (DivideByZeroException)
                {
                    ErrorHandling(divideByZeroErrorText);
                }
                catch (ArgumentException)
                {
                    ErrorHandling(tooBigNumberErrorText);
                }
            }
        }

        private void ErrorHandling(string errorText)
        {
            calculator.OnClearButtonClick();
            expressionLabel.Text = errorText;
            currentNumberTextBox.Enabled = false;
        }

        private void OnRemoveCurrentNumberButtonClick(object sender, EventArgs e)
        {
            currentNumberTextBox.Text = "0";
            calculator.OnRemoveCurrentNumberButtonClick(currentNumberTextBox.Text);
        }

        private void OnClearButtonClick(object sender, EventArgs e)
        {
            if (currentNumberTextBox.Enabled)
            {
                expressionLabel.Text = "";
                currentNumberTextBox.Text = "0";
                calculator.OnClearButtonClick();
            }
        }

        private void OnBackspaceButtonClick(object sender, EventArgs e)
        {
            currentNumberTextBox.Text = calculator.OnBackspaceButtonClick(currentNumberTextBox.Text);
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
