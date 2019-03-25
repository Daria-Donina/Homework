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

            var resultArray = 0;
            var resultList = 0;

            try
            {
                resultArray = calculatorArray.Calculate(expression);
                resultList = calculatorList.Calculate(expression);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Dividing by zero is forbidden");
                return;
            }
            catch
            {
                Console.WriteLine("The expression is incorrect");
                return;
            }

            if (resultArray != resultList)
            {
                return;
            }

            Console.WriteLine($"Result: {resultArray}");
        }
    }
}
