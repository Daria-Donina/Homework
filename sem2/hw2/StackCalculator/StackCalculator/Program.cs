using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter postfix expression");

            var expression = Console.ReadLine();

            var calculatorArray = new Calculator(new ArrayStack());
            var calculatorList = new Calculator(new ListStack());

            var resultArray = calculatorArray.Calculate(expression);
            var resultList = calculatorList.Calculate(expression);

            if (resultArray != resultList)
            {
                return;
            }

            Console.WriteLine($"Result: {resultArray}");
        }
    }
}
