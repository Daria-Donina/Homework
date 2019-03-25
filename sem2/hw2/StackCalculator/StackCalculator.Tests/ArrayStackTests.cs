namespace StackCalculator.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StackCalculator;

    [TestClass]
    public class ArrayStackTests
    {
        private ArrayStack stackArray;

        [TestInitialize]
        public void Initialize()
        {
            stackArray = new ArrayStack();
        }

        [TestMethod]
        public void IsPushInCorrectOrderTest()
        {
            for (int i = 0; i < 3; ++i)
            {
                stackArray.Push(i);
            }

            Assert.AreEqual(2, stackArray.Pop());
            Assert.AreEqual(1, stackArray.Pop());
            Assert.AreEqual(0, stackArray.Pop());
        }

        [TestMethod]
        public void PushTest()
        {
            stackArray.Push(5);
            Assert.AreEqual(5, stackArray.Peek());
        }

        [TestMethod]
        public void PushOneAndPopItTest()
        {
            stackArray.Push(-3);
            stackArray.Pop();
            Assert.IsTrue(stackArray.IsEmpty());
        }

        [TestMethod]
        public void PushPositiveNegativeAndZeroTest()
        {
            stackArray.Push(55);
            stackArray.Push(0);
            stackArray.Push(-6);

            Assert.AreEqual(-6, stackArray.Pop());
            Assert.AreEqual(0, stackArray.Pop());
            Assert.AreEqual(55, stackArray.Pop());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromTheEmptyStackTest()
        {
            _ = stackArray.Pop();
        }

        [TestMethod]
        public void DoesPeekShowWhatAtTheTopTest()
        {
            stackArray.Push(3);
            stackArray.Push(7);
            stackArray.Push(100);

            Assert.AreEqual(stackArray.Peek(), 100);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekFromTheEmptyStack()
        {
            _ = stackArray.Peek();
        }
    }
}
