using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BubbleSort.Tests
{
    [TestClass]
    public class BubbleSortTests
    {
        BubbleSort<int> intSet;
        IntComparer intComparer;

        BubbleSort<string> stringSet;
        StringComparer stringComparer;

        BubbleSort<List<int>> listSet;
        ListComparer<int> listComparer;

        [TestInitialize]
        public void Initialize()
        {
            intSet = new BubbleSort<int>();
            intComparer = new IntComparer();

            stringSet = new BubbleSort<string>();
            stringComparer = new StringComparer();

            listSet = new BubbleSort<List<int>>();
            listComparer = new ListComparer<int>();
        }

        [TestMethod]
        public void SortIntTest()
        {
            List<int> list = new List<int> { 1, 3, 6, 7, 4, 3, 8 };
            var sortedList = intSet.Sort(list, intComparer);

            for (int i = 1; i < sortedList.Count; ++i)
            {
                if (intComparer.Compare(list.ElementAt(i - 1), list.ElementAt(i)) == 1)
                {
                    Assert.IsTrue(false);
                }
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SortStringTest()
        {
            List<string> list = new List<string> { "i", "abcde", "abcd", "", "abgh" };
            var sortedList = stringSet.Sort(list, stringComparer);

            for (int i = 1; i < sortedList.Count; ++i)
            {
                if (stringComparer.Compare(sortedList.ElementAt(i - 1), sortedList.ElementAt(i)) == 1)
                {
                    Assert.IsTrue(false);
                }
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SortListTest()
        {
            var list1 = new List<int>() { 1, 4, 5 };
            var list2 = new List<int>() { 1, 4, 5, 7, 9 };
            var list3 = new List<int>() { 1 };

            List<List<int>> list = new List<List<int>> { list1, list2, list3 };
            var sortedList = listSet.Sort(list, listComparer);

            for (int i = 1; i < sortedList.Count; ++i)
            {
                if (listComparer.Compare(sortedList.ElementAt(i - 1), sortedList.ElementAt(i)) == 1)
                {
                    Assert.IsTrue(false);
                }
            }

            Assert.IsTrue(true);
        }
    }
}
