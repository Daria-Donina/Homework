using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void OnDigitButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (Calculator.WasCalculated || currentNumberTextBox.Text == "0")
            {
                currentNumberTextBox.Text = button.Text;
                ChangeCalculatorData();
                Calculator.WasCalculated = false;
            }
            else if (Calculator.FirstNumber != 0 && !Calculator.OperationEntered 
                || Calculator.SecondNumber != 0 && Calculator.OperationEntered)
            {
                currentNumberTextBox.Text += button.Text;

                ChangeCalculatorData();
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
            currentNumberTextBox.Text = Calculator.Calculate().ToString();
            Calculator.OperationEntered = false;
            ChangeCalculatorData();
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

            if (number == "")
            {
                number = "0";
            }

            currentNumberTextBox.Text = number;
            ChangeCalculatorData();
        }

        private void OnOperationButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (!Calculator.OperationEntered)
            {
                Calculator.Operation = $"{button.Text}";
                Calculator.OperationEntered = true;
                expressionLabel.Text += currentNumberTextBox.Text + $"{button.Text}";
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
                expressionLabel.Text += currentNumberTextBox.Text + $"{button.Text}";
                Calculator.FirstNumber = Calculator.Calculate();
                Calculator.Operation = $"{button.Text}";
            }
        }
    }
}
