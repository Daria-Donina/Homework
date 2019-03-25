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

        [TestMethod]
        public void OnlyAdditionArrayTest()
        {
            Assert.AreEqual(8, arrayStackCalculator.Calculate("3 5 +"));
        }

        [TestMethod]
        public void OnlyAdditionListTest()
        {
            Assert.AreEqual(8, listStackCalculator.Calculate("3 5 +"));
        }

        [TestMethod]
        public void OnlySubtractionArrayTest()
        {
            Assert.AreEqual(2, arrayStackCalculator.Calculate("5 3 -"));
        }

        [TestMethod]
        public void OnlySubtractionListTest()
        {
            Assert.AreEqual(2, listStackCalculator.Calculate("5 3 -"));
        }

        [TestMethod]
        public void OnlyMultiplicationArrayTest()
        {
            Assert.AreEqual(64, arrayStackCalculator.Calculate("4 16 *"));
        }

        [TestMethod]
        public void OnlyMultiplicationListTest()
        {
            Assert.AreEqual(64, listStackCalculator.Calculate("4 16 *"));
        }

        [TestMethod]
        public void OnlyDivisionArrayTest()
        {
            Assert.AreEqual(3, arrayStackCalculator.Calculate("45 15 /"));
        }

        [TestMethod]
        public void OnlyDivisionListTest()
        {
            Assert.AreEqual(3, listStackCalculator.Calculate("45 15 /"));
        }

        [TestMethod]
        public void DivisionWhenResultIsNotIntegerArrayTest()
        {
            Assert.AreEqual(7, arrayStackCalculator.Calculate("77 10 /"));
        }

        [TestMethod]
        public void DivisionWhenResultIsNotIntegerListTest()
        {
            Assert.AreEqual(7, listStackCalculator.Calculate("77 10 /"));
        }

        [TestMethod]
        public void NegativeResultArrayTest()
        {
            Assert.AreEqual(-10, listStackCalculator.Calculate("1 -10 *"));
        }

        [TestMethod]
        public void NegativeResultListTest()
        {
            Assert.AreEqual(-10, listStackCalculator.Calculate("1 -10 *"));
        }

        [TestMethod]
        public void ZeroResultArrayTest()
        {
            Assert.AreEqual(0, arrayStackCalculator.Calculate("9 -9 +"));
        }

        [TestMethod]
        public void ZeroResultListTest()
        {
            Assert.AreEqual(0, arrayStackCalculator.Calculate("9 -9 +"));
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DiviByZeroArrayTest()
        {
            _ = arrayStackCalculator.Calculate("5 0 /");
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DiviByZeroListTest()
        {
            _ = listStackCalculator.Calculate("5 0 /");
        }

        [TestMethod]
        public void CorrectComplexExpressionArrayTest()
        {
            Assert.AreEqual(6, arrayStackCalculator.Calculate("8 2 5 * + 1 3 2 * + 4 - /"));
        }

        [TestMethod]
        public void CorrectComplexExpressionListTest()
        {
            Assert.AreEqual(6, listStackCalculator.Calculate("8 2 5 * + 1 3 2 * + 4 - /"));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void WrongExpressionExtraLastNumbersArrayTest()
        {
            _ = arrayStackCalculator.Calculate("8 6 5 + * 3 5");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void WrongExpressionExtraLastNumbersListTest()
        {
            _ = listStackCalculator.Calculate("8 6 5 + * 3 5");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void NoSpaceBetweenTwoOperationsArrayTest()
        {
            _ = arrayStackCalculator.Calculate("7 3 6 5 - +*");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void NoSpaceBetweenTwoOperationsListTest()
        {
            _ = listStackCalculator.Calculate("7 3 6 5 - +*");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExpressionWithWeirdSymbolsArrayTest()
        {
            _ = arrayStackCalculator.Calculate("a a +");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExpressionWithWeirdSymbolsListTest()
        {
            _ = listStackCalculator.Calculate("a a +");
        }

        [TestMethod]
        public void NoOperationsArrayTest()
        {
            Assert.AreEqual(456, arrayStackCalculator.Calculate("456"));
        }

        [TestMethod]
        public void NoOperationsListTest()
        {
            Assert.AreEqual(456, listStackCalculator.Calculate("456"));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void NoNumbersArrayTest()
        {
            _ = arrayStackCalculator.Calculate("+ - * /");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void NoNumbersListTest()
        {
            _ = listStackCalculator.Calculate("+ - * /");
        }

        [TestMethod]
        public void ExpressionWithZerosOnlyArrayTest()
        {
            Assert.AreEqual(0, arrayStackCalculator.Calculate("0 0 + 0 0 - * 0 0 - +"));
        }

        [TestMethod]
        public void ExpressionWithZerosOnlyListTest()
        {
            Assert.AreEqual(0, listStackCalculator.Calculate("0 0 + 0 0 - * 0 0 - +"));
        }

        [TestMethod]
        public void LongNumberAndZeroArrayTest()
        {
            Assert.AreEqual(123456789, arrayStackCalculator.Calculate("123456789 0 +"));
        }

        [TestMethod]
        public void LongNumberAndZeroListTest()
        {
            Assert.AreEqual(123456789, listStackCalculator.Calculate("123456789 0 +"));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExpressionWithFloatNumbersArrayTest()
        {
            Assert.AreEqual(0, arrayStackCalculator.Calculate("1.23 5 -"));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExpressionWithFloatNumbersListTest()
        {
            Assert.AreEqual(0, listStackCalculator.Calculate("1.23 5 -"));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InfixExpressionArrayTest()
        {
            Assert.AreEqual(0, arrayStackCalculator.Calculate("1 * 5 - 2"));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InfixExpressionListTest()
        {
            Assert.AreEqual(0, listStackCalculator.Calculate("1 * 5 - 2"));
        }
    }
}
