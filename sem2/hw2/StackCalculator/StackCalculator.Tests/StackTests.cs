namespace StackCalculator.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StackCalculator;

    [TestClass]
    public class StackTests
    {
        private ArrayStack arrayStack;
        private ListStack listStack;

        [TestInitialize]
        public void Initialize()
        {
            arrayStack = new ArrayStack();
            listStack = new ListStack();
        }

        public void IsPushInCorrectOrderTest(IStack stack)
        {
            for (int i = 0; i < 3; ++i)
            {
                stack.Push(i);
            }

            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Pop());
            Assert.AreEqual(0, stack.Pop());
        }

        [TestMethod]
        public void IsPushInCorrectOrderArrayTest()
        {
            IsPushInCorrectOrderTest(arrayStack);
        }

        [TestMethod]
        public void IsPushInCorrectOrderListTest()
        {
            IsPushInCorrectOrderTest(listStack);
        }

        public void PushTest(IStack stack)
        {
            stack.Push(5);
            Assert.AreEqual(5, stack.Peek());
        }

        [TestMethod]
        public void PushArrayTest()
        {
            PushTest(arrayStack);
        }

        [TestMethod]
        public void PushListTest()
        {
            PushTest(listStack);
        }

        public void PushOneAndPopItTest(IStack stack)
        {
            stack.Push(-3);
            stack.Pop();
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void PushOneAndPopItArrayTest()
        {
            PushOneAndPopItTest(arrayStack);
        }

        [TestMethod]
        public void PushOneAndPopItListTest()
        {
            PushOneAndPopItTest(listStack);
        }

        public void PushPositiveNegativeAndZeroTest(IStack stack)
        {
            stack.Push(55);
            stack.Push(0);
            stack.Push(-6);

            Assert.AreEqual(-6, stack.Pop());
            Assert.AreEqual(0, stack.Pop());
            Assert.AreEqual(55, stack.Pop());
        }

        [TestMethod]
        public void PushPositiveNegativeAndZeroArrayTest()
        {
            PushPositiveNegativeAndZeroTest(arrayStack);
        }

        [TestMethod]
        public void PushPositiveNegativeAndZeroListTest()
        {
            PushPositiveNegativeAndZeroTest(listStack);
        }

        public void PopFromTheEmptyStackTest(IStack stack)
        {
            _ = stack.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromTheEmptyStackArrayTest()
        {
            PopFromTheEmptyStackTest(arrayStack);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromTheEmptyStackListTest()
        {
            PopFromTheEmptyStackTest(listStack);
        }

        public void DoesPeekShowWhatAtTheTopTest(IStack stack)
        {
            stack.Push(3);
            stack.Push(7);
            stack.Push(100);

            Assert.AreEqual(100, stack.Peek());
        }

        [TestMethod]
        public void DoesPeekShowWhatAtTheTopArrayTest()
        {
            DoesPeekShowWhatAtTheTopTest(arrayStack);
        }

        [TestMethod]
        public void DoesPeekShowWhatAtTheTopListTest()
        {
            DoesPeekShowWhatAtTheTopTest(listStack);
        }

        public void PeekFromTheEmptyStack(IStack stack)
        {
            _ = stack.Peek();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekFromTheEmptyArrayStack()
        {
            PeekFromTheEmptyStack(arrayStack);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekFromTheEmptyListStack()
        {
            PeekFromTheEmptyStack(listStack);
        }
    }
}