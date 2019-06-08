using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        private void Initialize(double firstNumber, double secondNumber, string operation)
        {
            Calculator.FirstNumber = firstNumber;
            Calculator.SecondNumber = secondNumber;
            Calculator.Operation = operation;
        }

        [DataTestMethod]
        [DataRow(8, 5, "+", 13)]
        [DataRow(99999999, 99999999, "+", 199999998)]
        [DataRow(-99999999, -99999999, "+", -199999998)]
        [DataRow(99999999, -56, "+", 99999943)]
        [DataRow(9, 9, "+", 18)]
        [DataRow(0, 0, "+", 0)]
        [DataRow(0, 5, "+", 5)]
        [DataRow(-87, 0, "+", -87)]
        [DataRow(1.25, 8, "+", 9.25)]
        [DataRow(0.00, -45, "+", -45)]
        [DataRow(5, 9.34678, "+", 14.34678)]
        [DataRow(48.82849, 7.8, "+", 56.62849)]
        [DataRow(5, 6, "-", -1)]
        [DataRow(53, 37, "-", 16)]
        [DataRow(99999999, 99999999, "-", 0)]
        [DataRow(-99999999, -99999999, "-", 0)]
        [DataRow(99999999, 39, "-", 99999960)]
        [DataRow(9, -9, "-", 18)]
        [DataRow(0, 0, "-", 0)]
        [DataRow(0, 5, "-", -5)]
        [DataRow(0, -5, "-", 5)]
        [DataRow(-87, 0, "-", -87)]
        [DataRow(1.25, 8, "-", -6.75)]
        [DataRow(0.00, -57, "-", 57)]
        [DataRow(5, 5689.90024, "-", -5684.90024)]
        [DataRow(5.849, 5689.90024, "-", -5684.05124)]
        [DataRow(45, 63, "*", 2835)]
        [DataRow(99999999, 99999999, "*", 9999999800000001)]
        [DataRow(-99999999, -99999999, "*", 9999999800000001)]
        [DataRow(99999999, 39, "*", 3899999961)]
        [DataRow(9, -9, "*", -81)]
        [DataRow(0, 0, "*", 0)]
        [DataRow(0, 5, "*", 0)]
        [DataRow(0, -5, "*", 0)]
        [DataRow(-87, 0, "*", -0)]
        [DataRow(1.25, 8, "*", 10)]
        [DataRow(0.00, -387592, "*", 0)]
        [DataRow(5, 5689.90024, "*", 28449.5012)]
        [DataRow(5.849, 5689.90024, "*", 33280.22650376)]
        [DataRow(6, 5, "/", 1.2)]
        [DataRow(99999999, 99999999, "/", 1)]
        [DataRow(-99999999, -99999999, "/", 1)]
        [DataRow(9, -9, "/", -1)]
        [DataRow(0, 0, "/", double.PositiveInfinity)]
        [DataRow(0, 5, "/", 0)]
        [DataRow(0, -5, "/", 0)]
        [DataRow(-87, 0, "/", double.NegativeInfinity)]
        [DataRow(1.25, 8, "/", 0.15625)]
        [DataRow(0.00, -57, "/", 0)]
        [DataRow(5493.849, 5689.90024, "/", 0.9655439934391539)]
        public void CountingTest(double firstNumber, double secondNumber, string operation, double result)
        {
            Initialize(firstNumber, secondNumber, operation);
            Assert.AreEqual(result, Calculator.Calculate());
        }

        [DataTestMethod]
        [DataRow(4, 7, "^")]
        [DataRow(4, 7, "%")]
        [DataRow(4, 7, "@")]
        [DataRow(4, 7, "#####")]
        [DataRow(4, 7, "$")]
        [DataRow(4, 7, ",")]
        [DataRow(4, 7, "kflga")]
        [DataRow(4, 7, "")]
        [ExpectedException(typeof(FormatException))]
        public void WrongOperationTest(double firstNumber, double secondNumber, string operation)
        {
            Initialize(firstNumber, secondNumber, operation);
            Calculator.Calculate();
        }

        [TestMethod]
        public void WasCalculatedTest()
        {
            Assert.IsFalse(Calculator.WasCalculated);
            Initialize(3, 98, "+");
            Calculator.Calculate();
            Assert.IsTrue(Calculator.WasCalculated);
        }
    }
}
