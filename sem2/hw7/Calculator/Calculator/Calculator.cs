using System;

namespace Calculator
{
    static class Calculator
    {
        public static double FirstNumber { get; set; }
        public static double SecondNumber { get; set; }
        public static string Operation { private get; set; }
        public static bool WasCalculated { get; set; }
        public static bool OperationEntered { get; set; }

        public static double Calculate()
        {
            WasCalculated = true;

            switch (Operation)
            {
                case "+":
                    return FirstNumber + SecondNumber;
                case "-":
                    return FirstNumber - SecondNumber;
                case "×":
                    return FirstNumber * SecondNumber;
                case "÷":
                    return FirstNumber / SecondNumber;
                default:
                    throw new FormatException();
            }
        }
    }
}
