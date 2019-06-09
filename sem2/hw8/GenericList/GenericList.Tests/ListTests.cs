using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericList.Tests
{
    [TestClass]
    public class ListTests
    {
        List<int> list;

        [TestInitialize]
        public void Initialize()
        {
            list = new List<int>();

            for (int i = 0; i < 5; ++i)
            {
                list.Add(i);
            }
        }

        [TestMethod]
        public void CountTest()
        {
            list.Remove(3);
            list.RemoveAt(0);

            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void GettingOrSettingElementTest()
        {
            Assert.AreEqual(3, list[3]);

            list[3] = 13;
            Assert.AreEqual(13, list[3]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SettingNegativeIndexTest() => list[-2] = 7;

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GettingNegativeIndexTest() => _ = list[-2];

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SettingBigIndexTest() => list[5] = 5;

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GettingBigIndexTest() => _ = list[7];

        [TestMethod]
        public void AddTest()
        {
            for (int i = 0; i < 5; ++i)
            {
                if (!list.Contains(i))
                {
                    Assert.Fail();
                }
            }

            Assert.IsFalse(list.Contains(5));
        }

        [TestMethod]
        public void ClearTest()
        {
            list.Clear();
            Assert.IsFalse(list.Contains(0));
        }

        [TestMethod]
        public void SuccessfulCopyToTest()
        {
            var array = new int[8];

            list.CopyTo(array, 3);

            for (int i = 0; i < 5; ++i)
            {
                if (array[i + 3] != i)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CopyToNullArrayTest()
        {
            int[] array = null;

            list.CopyTo(array, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NegativeIndexCopyToTest()
        {
            var array = new int[8];

            list.CopyTo(array, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ListBiggerThanArrayTest()
        {
            var array = new int[8];

            list.CopyTo(array, 4);
        }

        [TestMethod]
        public void IndexOfTest()
        {
            list[3] = 7;
            for (int i = 0; i < 5; ++i)
            {
                if (i != 3 && list.IndexOf(i) != i || i == 3 && list.IndexOf(i) != -1)
                {
                    Assert.Fail();
                }
            }

            Assert.AreEqual(3, list.IndexOf(7));
        }

        [TestMethod]
        public void InsertTest()
        {
            list.Insert(2, 8);
            list.Insert(5, 5);

            Assert.AreEqual(8, list[2]);
            Assert.AreEqual(5, list[5]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNegativeIndexTest() => list.Insert(-1, 8);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertBigIndexTest() => list.Insert(6, 8);

        [TestMethod]
        public void RemoveTest()
        {
            Assert.IsTrue(list.Remove(4));
            Assert.IsFalse(list.Contains(4));
            Assert.AreEqual(4, list.Count);
        }

        [TestMethod]
        public void RemoveNotExistingElementTest()
        {
            Assert.IsFalse(list.Remove(5));
            Assert.AreEqual(5, list.Count);
        }

        [TestMethod]
        public void RemoveAtTest()
        {
            list.RemoveAt(4);
            list.RemoveAt(0);
            Assert.IsFalse(list.Contains(4));
            Assert.IsFalse(list.Contains(0));
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAtNegativeIndexTest() => list.RemoveAt(-1);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAtBigIndexTest() => list.RemoveAt(5);

        [TestMethod]
        public void RemoveAllTheElementsWithForeachTest()
        {
            foreach (var element in list)
            {
                list.Remove(element);
            }

            Assert.AreEqual(0, list.Count);
        }
    }
}
