using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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

        private void MapTest(List<int> list)
        {
            var transformedList = ListOperations.Map(list, x => x * 3);
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

        private void FilterEvenNumbersTest(List<int> list)
        {
            var transformedList = ListOperations.Filter(list, x => x % 2 == 0);
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

        private int FoldMultiplicationTest(List<int> list) => ListOperations.Fold(list, 1, (result, x) => x * result);

        [TestMethod]
        public void FoldMultiplicationDigitTest() => Assert.AreEqual(0, FoldMultiplicationTest(digitList));

        [TestMethod]
        public void FoldMultiplicationZeroTest() => Assert.AreEqual(0, FoldMultiplicationTest(zeroList));

        [TestMethod]
        public void FoldMultiplicationNegativeTest() => Assert.AreEqual(3628800, FoldMultiplicationTest(negativeList));

        private int FoldAdditionTest(List<int> list) => ListOperations.Fold(list, 5, (result, x) => x + result);

        [TestMethod]
        public void FoldAdditionDigitTest() => Assert.AreEqual(50, FoldAdditionTest(digitList));

        [TestMethod]
        public void FoldAdditionZeroTest() => Assert.AreEqual(5, FoldAdditionTest(zeroList));

        [TestMethod]
        public void FoldAdditionNegativeTest() => Assert.AreEqual(-50, FoldAdditionTest(negativeList));

        private void FilterNoAppropriateElementsTest(List<int> list)
        {
            var transformedList = ListOperations.Filter(list, x => x == 1000);
            Assert.AreEqual(0, transformedList.Count);
        }

        [TestMethod]
        public void FilterNoAppropriateElementsDigitTest() => FilterNoAppropriateElementsTest(digitList);

        [TestMethod]
        public void FilterNoAppropriateElementsZeroTest() => FilterNoAppropriateElementsTest(zeroList);

        [TestMethod]
        public void FilterNoAppropriateElementsNegativeTest() => FilterNoAppropriateElementsTest(negativeList);
    }
}
