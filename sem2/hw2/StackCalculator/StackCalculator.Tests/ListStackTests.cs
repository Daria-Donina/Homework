namespace StackCalculator.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StackCalculator;

    [TestClass]
    public class ListStackTests
    {
        private ListStack stackList;

        [TestInitialize]
        public void Initialize()
        {
            stackList = new ListStack();
        }

        [TestMethod]
        public void IsPushInCorrectOrderTest()
        {
            for (int i = 0; i < 3; ++i)
            {
                stackList.Push(i);
            }

            Assert.AreEqual(2, stackList.Pop());
            Assert.AreEqual(1, stackList.Pop());
            Assert.AreEqual(0, stackList.Pop());
        }

        [TestMethod]
        public void PushTest()
        {
            stackList.Push(5);
            Assert.AreEqual(5, stackList.Peek());
        }

        [TestMethod]
        public void PushOneAndPopItTest()
        {
            stackList.Push(-3);
            stackList.Pop();
            Assert.IsTrue(stackList.IsEmpty());
        }

        [TestMethod]
        public void PushPositiveNegativeAndZeroTest()
        {
            stackList.Push(55);
            stackList.Push(0);
            stackList.Push(-6);

            Assert.AreEqual(-6, stackList.Pop());
            Assert.AreEqual(0, stackList.Pop());
            Assert.AreEqual(55, stackList.Pop());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromTheEmptyStackTest()
        {
            _ = stackList.Pop();
        }

        [TestMethod]
        public void DoesPeekShowWhatAtTheTopTest()
        {
            stackList.Push(3);
            stackList.Push(7);
            stackList.Push(100);

            Assert.AreEqual(stackList.Peek(), 100);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekFromTheEmptyStack()
        {
            _ = stackList.Peek();
        }
    }
}
