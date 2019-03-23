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

            var arrayStack = new StackArray();
            var listStack = new StackList();

            var calculatorArray = new Calculator(arrayStack);
            var calculatorList = new Calculator(listStack);

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
