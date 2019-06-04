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


        private double firstNumber;
        private double secondNumber;
        private bool wasCalculated;
        private void OnDigitButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;

            currentNumberTextBox.Text = button.Text;

            if (wasCalculated)
            {
                firstNumber = double.Parse(button.Text);
            }
            else
            {
                secondNumber = double.Parse(button.Text);
            }
        }

        private void ChangeOperation(Button operation)
        {
            var charExpression = expressionLabel.Text.ToCharArray();
            charExpression[expressionLabel.Text.Length - 1] = operation.Text.ToCharArray()[0];
            var changedExpression = charExpression.ToString();
            expressionLabel.Text = changedExpression;
        }

        private string operation;
        private void OnOperationButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (expressionLabel.Text == "")
            {
                expressionLabel.Text = currentNumberTextBox.Text + " " + button.Text;
                firstNumber = double.Parse(currentNumberTextBox.Text);
                operation = button.Text;
            }
            else if (wasCalculated)
            {
                ChangeOperation(button);
                operation = button.Text;
                wasCalculated = false;
            }
            else
            {
                var calculator = new OneOperationCalculator(firstNumber, operation, secondNumber);
                firstNumber = calculator.Calculate();
                
                expressionLabel.Text += " " + currentNumberTextBox.Text + " " + button.Text;
                currentNumberTextBox.Text = $"{firstNumber}";
                operation = button.Text;
                wasCalculated = true;
            }
        }

        private void OnEqualButtonClick(object sender, EventArgs e)
        {
            expressionLabel.Text = "";
            var calcualtor = new OneOperationCalculator(firstNumber, operation, secondNumber);
            firstNumber = calcualtor.Calculate();
            wasCalculated = true;
            currentNumberTextBox.Text = $"{firstNumber}";
        }
    }
}
