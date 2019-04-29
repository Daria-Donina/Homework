using System;

namespace ParseTree
{
    /// <summary>
    /// Class that calculates value of the parse tree and prints the expression.
    /// </summary>
    public class Calculator
    {
        private readonly string[] expression;
        private ParseTree tree;

        public Calculator(string expression)
        {
            char[] separator = { ' ', '(', ')' };
            this.expression = expression.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            tree = new ParseTree();
            tree.Root = CreateParseTree();

            if (index != this.expression.Length - 1)
            {
                throw new FormatException();
            }
        }

        /// <summary>
        /// Calculates value of the parse tree.
        /// </summary>
        /// <returns> An integer result of the calculation. </returns>
        public int Calculate()
        {
            return tree.Calculate();
        }

        /// <summary>
        /// Prints the expression of the parse tree in the infix form.
        /// </summary>
        public void PrintParseTree()
        {
            tree.Print();
            Console.WriteLine();
        }

        private int index = -1;

        private Node CreateParseTree()
        {
            ++index;

            if (index >= expression.Length)
            {
                throw new FormatException();
            }

            if (int.TryParse(expression[index], out int number))
            {
                return new Operand(expression[index]);
            }

            Operation operation;
            switch (expression[index])
            {
                case "+":
                    operation = new Addition();
                    break;
                case "-":
                    operation = new Subtraction();
                    break;
                case "*":
                    operation = new Multiplication();
                    break;
                case "/":
                    operation = new Division();
                    break;
                default:
                    throw new FormatException();
            }
            
            operation.LeftChild = CreateParseTree();
            operation.RightChild = CreateParseTree();

            return operation;
        }
    }
}
