using System;
using System.IO;

namespace ParseTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = new StreamReader("input.txt");
            var expression = file.ReadToEnd();
            file.Close();

            var calculator = new Calculator(expression);
            calculator.PrintParseTree();

            Console.WriteLine($"Result of the calculation: {calculator.Calculate()}");
        }
    }
}
