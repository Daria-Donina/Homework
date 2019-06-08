using System;

namespace Calculator
{
    public static class Calculator
    {
        public static double FirstNumber { get; set; }
        public static double SecondNumber { get; set; }
        public static string Operation { private get; set; }
        public static bool WasCalculated { get; set; }
        public static bool OperationEntered { get; set; }

        public static double Calculate()
        {
            if (FirstNumber == 0 && SecondNumber == 0 && Operation == "/")
            {
                return double.PositiveInfinity;
            }

            WasCalculated = true;

            if (Operation == "+")
            {
                return FirstNumber + SecondNumber;
            }
            else if (Operation == "-")
            {
                return FirstNumber - SecondNumber;
            }
            else if (Operation == "*" || Operation == "×")
            {
                return FirstNumber * SecondNumber;
            }
            else if (Operation == "/" || Operation == "÷")
            {
                return FirstNumber / SecondNumber;
            }
            else
            {
                throw new FormatException();
            }
        }
    }
}
