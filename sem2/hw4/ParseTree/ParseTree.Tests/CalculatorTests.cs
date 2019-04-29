namespace ParseTree.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class CalculatorTests
    {
        Calculator calculator;

        [TestMethod]
        public void AdditionTest()
        {
            calculator = new Calculator("(+ 4 3)");
            Assert.AreEqual(7, calculator.Calculate());
        }

        [TestMethod]
        public void SubtractionTest()
        {
            calculator = new Calculator("(- 9 5)");
            Assert.AreEqual(4, calculator.Calculate());
        }

        [TestMethod]
        public void MultiplicationTest()
        {
            calculator = new Calculator("(* 5 7)");
            Assert.AreEqual(35, calculator.Calculate());
        }

        [TestMethod]
        public void DivisionTest()
        {
            calculator = new Calculator("(/ 8 4)");
            Assert.AreEqual(2, calculator.Calculate());
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroTest()
        {
            calculator = new Calculator("(/ 5 0)");
            calculator.Calculate();
        }

        [TestMethod]
        public void OperationsWithZerosTest()
        {
            calculator = new Calculator("(- (* (+ 0 0) 0) 0)");
            Assert.AreEqual(0, calculator.Calculate());
        }

        [TestMethod]
        public void ComplexExpressionTest()
        {
            calculator = new Calculator("(- (* (+ 25 (- 76 32)) (/ 96 8)) (+ 34 (* 8 6))))");
            Assert.AreEqual(746, calculator.Calculate());
        }

        [TestMethod]
        public void BigNumbersTest()
        {
            calculator = new Calculator("(+ (* 10101 82994) (- 24902 9379))");
            Assert.AreEqual(838337917, calculator.Calculate());
        }

        [TestMethod]
        public void NegativeNumbersTest()
        {
            calculator = new Calculator("(+ (- -4 -7) (* -9 6))");
            Assert.AreEqual(-51, calculator.Calculate());
        }

        [TestMethod]
        public void OneNumberTest()
        {
            calculator = new Calculator("3");
            Assert.AreEqual(3, calculator.Calculate());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void NoSecondOperandTest()
        {
            calculator = new Calculator("(- 3 (/ 6 ))");
            calculator.Calculate();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void NoOperationTest()
        {
            calculator = new Calculator("(+ 3 ( 6 2))");
            calculator.Calculate();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void EmptyStringTest()
        {
            calculator = new Calculator("");
            calculator.Calculate();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void StringWithWeirdSymbolsTest()
        {
            calculator = new Calculator("(- 1 a)random words");
            calculator.Calculate();
        }

        [TestMethod]
        public void ExtraSpacesTest()
        {
            calculator = new Calculator("(- 6    (  + 3  7))");
            Assert.AreEqual(-4, calculator.Calculate());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InfixExpressionTest()
        {
            calculator = new Calculator("(5 - (3 + 6))");
            calculator.Calculate();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void NotIntegerNumbersTest()
        {
            calculator = new Calculator("(+ 7.4 (- 9.3 6))");
            calculator.Calculate();
        }
    }
}
