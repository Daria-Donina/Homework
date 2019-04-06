namespace StackCalculator.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StackCalculator;

    [TestClass]
    public class CalculatorTests
    {
        private Calculator arrayStackCalculator;
        private Calculator listStackCalculator;

        [TestInitialize]
        public void Initialize()
        {
            arrayStackCalculator = new Calculator(new ArrayStack());
            listStackCalculator = new Calculator(new ListStack());
        }

        public void OnlyAdditionTest(ICalculator calculator)
        {
            Assert.AreEqual(8, calculator.Calculate("3 5 +"));
        }

        [TestMethod]
        public void OnlyAdditionArrayTest()
        {
            OnlyAdditionTest(arrayStackCalculator);
        }

        [TestMethod]
        public void OnlyAdditionListTest()
        {
            OnlyAdditionTest(listStackCalculator);
        }

        public void OnlySubtractionTest(ICalculator calculator)
        {
            Assert.AreEqual(2, calculator.Calculate("5 3 -"));
        }

        [TestMethod]
        public void OnlySubtractionArrayTest()
        {
            OnlySubtractionTest(arrayStackCalculator);
        }

        [TestMethod]
        public void OnlySubtractionListTest()
        {
            OnlySubtractionTest(listStackCalculator);
        }

        public void OnlyMultiplicationTest(ICalculator calculator)
        {
            Assert.AreEqual(64, calculator.Calculate("4 16 *"));
        }

        [TestMethod]
        public void OnlyMultiplicationArrayTest()
        {
            OnlyMultiplicationTest(arrayStackCalculator);
        }

        [TestMethod]
        public void OnlyMultiplicationListTest()
        {
            OnlyMultiplicationTest(listStackCalculator);
        }

        public void OnlyDivisionTest(ICalculator calculator)
        {
            Assert.AreEqual(3, calculator.Calculate("45 15 /"));
        }

        [TestMethod]
        public void OnlyDivisionArrayTest()
        {
            OnlyDivisionTest(arrayStackCalculator);
        }

        [TestMethod]
        public void OnlyDivisionListTest()
        {
            OnlyDivisionTest(listStackCalculator);
        }

        public void DivisionWhenResultIsNotIntegerTest(ICalculator calculator)
        {
            Assert.AreEqual(7, calculator.Calculate("77 10 /"));
        }

        [TestMethod]
        public void DivisionWhenResultIsNotIntegerArrayTest()
        {
            DivisionWhenResultIsNotIntegerTest(arrayStackCalculator);
        }

        [TestMethod]
        public void DivisionWhenResultIsNotIntegerListTest()
        {
            DivisionWhenResultIsNotIntegerTest(listStackCalculator);
        }

        public void NegativeResultTest(ICalculator calculator)
        {
            Assert.AreEqual(-10, calculator.Calculate("1 -10 *"));
        }

        [TestMethod]
        public void NegativeResultArrayTest()
        {
            NegativeResultTest(arrayStackCalculator);
        }

        [TestMethod]
        public void NegativeResultListTest()
        {
            NegativeResultTest(listStackCalculator);
        }

        public void ZeroResultTest(ICalculator calculator)
        {
            Assert.AreEqual(0, calculator.Calculate("9 -9 +"));
        }

        [TestMethod]
        public void ZeroResultArrayTest()
        {
            ZeroResultTest(arrayStackCalculator);
        }

        [TestMethod]
        public void ZeroResultListTest()
        {
            ZeroResultTest(listStackCalculator);
        }

        public void DivideByZeroTest(ICalculator calculator)
        {
            _ = calculator.Calculate("5 0 /");
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroArrayTest()
        {
            DivideByZeroTest(arrayStackCalculator);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroListTest()
        {
            DivideByZeroTest(listStackCalculator);
        }

        public void CorrectComplexExpressionTest(ICalculator calculator)
        {
            Assert.AreEqual(6, calculator.Calculate("8 2 5 * + 1 3 2 * + 4 - /"));
        }

        [TestMethod]
        public void CorrectComplexExpressionArrayTest()
        {
            CorrectComplexExpressionTest(arrayStackCalculator);
        }

        [TestMethod]
        public void CorrectComplexExpressionListTest()
        {
            CorrectComplexExpressionTest(listStackCalculator);
        }

        public void WrongExpressionExtraLastNumbersTest(ICalculator calculator)
        {
            _ = calculator.Calculate("8 6 5 + * 3 5");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void WrongExpressionExtraLastNumbersArrayTest()
        {
            WrongExpressionExtraLastNumbersTest(arrayStackCalculator);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void WrongExpressionExtraLastNumbersListTest()
        {
            WrongExpressionExtraLastNumbersTest(listStackCalculator);
        }

        public void NoSpaceBetweenTwoOperationsTest(ICalculator calculator)
        {
            _ = calculator.Calculate("7 3 6 5 - +*");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void NoSpaceBetweenTwoOperationsArrayTest()
        {
            NoSpaceBetweenTwoOperationsTest(arrayStackCalculator);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void NoSpaceBetweenTwoOperationsListTest()
        {
            NoSpaceBetweenTwoOperationsTest(listStackCalculator);
        }

        public void ExpressionWithWeirdSymbolsTest(ICalculator calculator)
        {
            _ = calculator.Calculate("a a +");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExpressionWithWeirdSymbolsArrayTest()
        {
            ExpressionWithWeirdSymbolsTest(arrayStackCalculator);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExpressionWithWeirdSymbolsListTest()
        {
            ExpressionWithWeirdSymbolsTest(listStackCalculator);
        }

        public void NoOperationsTest(ICalculator calculator)
        {
            Assert.AreEqual(456, arrayStackCalculator.Calculate("456"));
        }

        [TestMethod]
        public void NoOperationsArrayTest()
        {
            NoOperationsTest(arrayStackCalculator);
        }

        [TestMethod]
        public void NoOperationsListTest()
        {
            NoOperationsTest(listStackCalculator);
        }

        public void NoNumbersTest(ICalculator calculator)
        {
            _ = calculator.Calculate("+ - * /");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void NoNumbersArrayTest()
        {
            NoNumbersTest(arrayStackCalculator);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void NoNumbersListTest()
        {
            NoNumbersTest(listStackCalculator);
        }

        public void ExpressionWithZerosOnlyTest(ICalculator calculator)
        {
            Assert.AreEqual(0, calculator.Calculate("0 0 + 0 0 - * 0 0 - +"));
        }

        [TestMethod]
        public void ExpressionWithZerosOnlyArrayTest()
        {
            ExpressionWithZerosOnlyTest(arrayStackCalculator);
        }

        [TestMethod]
        public void ExpressionWithZerosOnlyListTest()
        {
            ExpressionWithZerosOnlyTest(listStackCalculator);
        }

        public void LongNumberAndZeroTest(ICalculator calculator)
        {
            Assert.AreEqual(123456789, calculator.Calculate("123456789 0 +"));
        }

        [TestMethod]
        public void LongNumberAndZeroArrayTest()
        {
            LongNumberAndZeroTest(arrayStackCalculator);
        }

        [TestMethod]
        public void LongNumberAndZeroListTest()
        {
            LongNumberAndZeroTest(listStackCalculator);
        }

        public void ExpressionWithFloatNumbersTest(ICalculator calculator)
        {
            Assert.AreEqual(0, calculator.Calculate("1.23 5 -"));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExpressionWithFloatNumbersArrayTest()
        {
            ExpressionWithFloatNumbersTest(arrayStackCalculator);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExpressionWithFloatNumbersListTest()
        {
            ExpressionWithFloatNumbersTest(listStackCalculator);
        }

        public void InfixExpressionTest(ICalculator calculator)
        {
            Assert.AreEqual(0, calculator.Calculate("1 * 5 - 2"));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InfixExpressionArrayTest()
        {
            InfixExpressionTest(arrayStackCalculator);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InfixExpressionListTest()
        {
            InfixExpressionTest(listStackCalculator);
        }
    }
}
