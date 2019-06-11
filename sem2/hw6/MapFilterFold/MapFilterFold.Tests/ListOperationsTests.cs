using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace MapFilterFold.Tests
{
    [TestClass]
    public class ListOperationsTests
    {
        private List<int> digitList;
        private List<int> zeroList;
        private List<int> negativeList;

        [TestInitialize]
        public void Initialize()
        {
            digitList = InitializeListOfDigits();
            zeroList = InitializeZeroList();
            negativeList = InitializeListOfNegativeNumbers();
        }

        private static List<int> InitializeListOfDigits()
        {
            var list = new List<int>();
            for (int i = 0; i < 10; ++i)
            {
                list.Add(i);
            }
            return list;
        }

        private static List<int> InitializeZeroList()
        {
            var list = new List<int>();
            for (int i = 0; i < 10; ++i)
            {
                list.Add(0);
            }

            return list;
        }

        private static List<int> InitializeListOfNegativeNumbers()
        {
            var list = new List<int>();
            for (int i = 0; i < 10; ++i)
            {
                list.Add(-i-1);
            }

            return list;
        }

        private static void MapTest(List<int> list)
        {
            var transformedList = ListOperations<int, int>.Map(list, x => x * 3);
            for (int i = 0; i < transformedList.Count; ++i)
            {
                if (transformedList[i] != list[i] * 3)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void MapDigitTest() => MapTest(digitList);

        [TestMethod]
        public void MapZeroTest() => MapTest(zeroList);

        [TestMethod]
        public void MapNegativeTest() => MapTest(negativeList);

        private static void FilterEvenNumbersTest(List<int> list)
        {
            var transformedList = ListOperations<int, int>.Filter(list, x => x % 2 == 0);
            for (int i = 0; i < transformedList.Count; ++i)
            {
                if (transformedList[i] % 2 != 0)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void FilterEvenNumbersDigitTest() => FilterEvenNumbersTest(digitList);

        [TestMethod]
        public void FilterEvenNumbersZeroTest() => FilterEvenNumbersTest(zeroList);

        [TestMethod]
        public void FilterEvenNumbersNegativeTest() => FilterEvenNumbersTest(negativeList);

        private static int FoldMultiplicationTest(List<int> list) => ListOperations<int, int>.Fold(list, 1, (result, x) => x * result);

        [TestMethod]
        public void FoldMultiplicationDigitTest() => Assert.AreEqual(0, FoldMultiplicationTest(digitList));

        [TestMethod]
        public void FoldMultiplicationZeroTest() => Assert.AreEqual(0, FoldMultiplicationTest(zeroList));

        [TestMethod]
        public void FoldMultiplicationNegativeTest() => Assert.AreEqual(3628800, FoldMultiplicationTest(negativeList));

        private static int FoldAdditionTest(List<int> list) => ListOperations<int, int>.Fold(list, 5, (result, x) => x + result);

        [TestMethod]
        public void FoldAdditionDigitTest() => Assert.AreEqual(50, FoldAdditionTest(digitList));

        [TestMethod]
        public void FoldAdditionZeroTest() => Assert.AreEqual(5, FoldAdditionTest(zeroList));

        [TestMethod]
        public void FoldAdditionNegativeTest() => Assert.AreEqual(-50, FoldAdditionTest(negativeList));

        private static void FilterNoAppropriateElementsTest(List<int> list)
        {
            var transformedList = ListOperations<int, int>.Filter(list, x => x == 1000);
            Assert.AreEqual(0, transformedList.Count);
        }

        [TestMethod]
        public void FilterNoAppropriateElementsDigitTest() => FilterNoAppropriateElementsTest(digitList);

        [TestMethod]
        public void FilterNoAppropriateElementsZeroTest() => FilterNoAppropriateElementsTest(zeroList);

        [TestMethod]
        public void FilterNoAppropriateElementsNegativeTest() => FilterNoAppropriateElementsTest(negativeList);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapNullList()
        {
            List<int> list = null;

            ListOperations<int, int>.Map(list, x => x * 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterNullList()
        {
            List<int> list = null;

            ListOperations<int, int>.Filter(list, x => x % 3 == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FoldNullList()
        {
            List<int> list = null;

            ListOperations<int, int>.Fold(list, 5, (result, value) => result + value);
        }

        [TestMethod]
        public void ListOfStringsMapTest()
        {
            var list = new List<string> { "5", "4", "3" };

            var result = ListOperations<string, string>.Map(list, data => data + "aaa");

            Assert.AreEqual("5aaa", result[0]);
            Assert.AreEqual("4aaa", result[1]);
            Assert.AreEqual("3aaa", result[2]);
        }

        [TestMethod]
        public void ListOfStringsFilterTest()
        {
            var list = new List<string> { "aaaa", "bbbbbb", "cc", "6666" };

            var result = ListOperations<string, string>.Filter(list, data => data.Length == 4);

            Assert.AreEqual("aaaa", result[0]);
            Assert.AreEqual("6666", result[1]);
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void ListOfStringsFoldTest()
        {
            var list = new List<string> { "aaaa", "bbbbbb", "cc" };

            var result = ListOperations<string, string>.Fold(list, "k", (value, element) => value + element);

            Assert.AreEqual("kaaaabbbbbbcc", result);
        }
    }
}
