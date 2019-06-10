using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericSet.Tests
{
    [TestClass]
    public class SetTests
    {
        private Set<int> set;

        [TestInitialize]
        public void Initialize()
        {
            set = new Set<int> { 4, 7, 9, 5, 2, 6, 1, 3, 8 };
        }

        [TestMethod]
        public void CountTest()
        {
            Assert.AreEqual(9, set.Count);
            set.Remove(5);
            set.Remove(4);
            set.Remove(1);
            Assert.AreEqual(6, set.Count);
        }

        [TestMethod]
        public void SuccessfulAddTest()
        {
            for (int i = 1; i < 10; ++i)
            {
                if (!set.Contains(i))
                {
                    Assert.Fail();
                }
            }

            Assert.IsFalse(set.Contains(10));
        }

        [TestMethod]
        public void AddExistingItemTest()
        {
            for (int i = 1; i < 10; ++i)
            {
                Assert.IsFalse(set.Add(i));
            }
        }

        [TestMethod]
        public void ClearTest()
        {
            set.Clear();
            for (int i = 1; i < 10; ++i)
            {
                if (set.Contains(i))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void SuccessfulCopyToTest()
        {
            var array = new int[15];

            set.CopyTo(array, 6);
            for (int i = 0; i < 9; ++i)
            {
                if (array[i + 6] != i + 1)
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

            set.CopyTo(array, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NegativeIndexCopyToTest()
        {
            var array = new int[8];

            set.CopyTo(array, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetBiggerThanArrayTest()
        {
            var array = new int[15];

            set.CopyTo(array, 7);
        }

        [TestMethod]
        public void ExceptWithTest()
        {
            var collection = new List<int> { 1, 3, 7, 15 };
            set.ExceptWith(collection);
            Assert.IsFalse(set.Contains(1));
            Assert.IsFalse(set.Contains(3));
            Assert.IsFalse(set.Contains(7));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptWithNullCollectionTest()
        {
            List<int> collection = null;
            set.ExceptWith(collection);
        }

        [TestMethod]
        public void IntersectWithTest()
        {
            var collection = new List<int> { 1, 3, 7, 15 };
            set.IntersectWith(collection);
            for (int i = 1; i < 10; ++i)
            {
                if (set.Contains(i))
                {
                    if (i != 1 && i != 3 && i != 7)
                    {
                        Assert.Fail();
                    }
                }
                else
                {
                    if (i == 1 || i == 3 || i == 7)
                    {
                        Assert.Fail();
                    }
                }
            }

            Assert.IsFalse(set.Contains(15));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IntersectWithNullCollectionTest()
        {
            List<int> collection = null;
            set.IntersectWith(collection);
        }

        [TestMethod]
        public void IsProperSubsetOfTest()
        {
            var collection1 = new List<int> { 1, 3, 7 };
            var collection2 = new List<int> { -7, 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 };
            var collection3 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.IsFalse(set.IsProperSubsetOf(collection1));
            Assert.IsFalse(set.IsProperSubsetOf(collection3));
            Assert.IsTrue(set.IsProperSubsetOf(collection2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsProperSubsetOfNullCollectionTest()
        {
            List<int> collection = null;
            set.IsProperSubsetOf(collection);
        }

        [TestMethod]
        public void IsProperSupersetOfTest()
        {
            var collection1 = new List<int> { 1, 3, 7 };
            var collection2 = new List<int> { -7, 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 };
            var collection3 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.IsTrue(set.IsProperSupersetOf(collection1));
            Assert.IsFalse(set.IsProperSupersetOf(collection3));
            Assert.IsFalse(set.IsProperSupersetOf(collection2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsProperSupersetOfNullCollectionTest()
        {
            List<int> collection = null;
            set.IsProperSupersetOf(collection);
        }

        [TestMethod]
        public void IsSubsetOfTest()
        {
            var collection1 = new List<int> { 1, 3, 7 };
            var collection2 = new List<int> { -7, 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 };
            var collection3 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.IsFalse(set.IsSubsetOf(collection1));
            Assert.IsTrue(set.IsSubsetOf(collection3));
            Assert.IsTrue(set.IsSubsetOf(collection2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsSubsetOfNullCollectionTest()
        {
            List<int> collection = null;
            set.IsSubsetOf(collection);
        }

        [TestMethod]
        public void IsSupersetOfTest()
        {
            var collection1 = new List<int> { 1, 3, 7 };
            var collection2 = new List<int> { -7, 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 };
            var collection3 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.IsTrue(set.IsSupersetOf(collection1));
            Assert.IsFalse(set.IsSupersetOf(collection2));
            Assert.IsTrue(set.IsSupersetOf(collection3));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsSupersetOfNullCollectionTest()
        {
            List<int> collection = null;
            set.IsSupersetOf(collection);
        }

        [TestMethod]
        public void OverlapsTest()
        {
            var collection1 = new List<int>();
            var collection2 = new List<int> { -8, -7, 4, 11, 15 };
            var collection3 = new List<int> { -20, -19, -14, 30, 100 };

            Assert.IsFalse(set.Overlaps(collection1));
            Assert.IsFalse(set.Overlaps(collection3));
            Assert.IsTrue(set.Overlaps(collection2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OverlapsNullCollectionTest()
        {
            List<int> collection = null;
            set.Overlaps(collection);
        }

        [TestMethod]
        public void SuccessfulRemoveTest()
        {
            Assert.IsTrue(set.Remove(9));
            Assert.IsTrue(set.Remove(4));
            Assert.IsTrue(set.Remove(5));
            Assert.IsTrue(set.Remove(8));

            for (int i = 1; i < 10; ++i)
            {
                if (!set.Contains(i))
                {
                    if (i != 9 && i != 4 && i != 5 && i != 8)
                    {
                        Assert.Fail();
                    }
                }
                else
                {
                    if (i == 9 || i == 4 || i == 5 || i == 8)
                    {
                        Assert.Fail();
                    }
                }
            }
        }

        [TestMethod]
        public void RemoveNotExistingItemTest()
        {
            Assert.IsFalse(set.Remove(15));
            Assert.AreEqual(9, set.Count);
        }

        [TestMethod]
        public void RemoveAllTheItemsViaForeach()
        {
            foreach (var item in set)
            {
                set.Remove(item);
            }

            for (int i = 1; i < 10; ++i)
            {
                if (set.Contains(i))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void SetEqualsTest()
        {
            var collection1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var collection2 = new List<int> { -8, -7, 4, 11, 15 };
            var collection3 = new List<int>();

            Assert.IsFalse(set.SetEquals(collection2));
            Assert.IsFalse(set.SetEquals(collection3));
            Assert.IsTrue(set.SetEquals(collection1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetEqualsNullCollectionTest()
        {
            List<int> collection = null;
            set.SetEquals(collection);
        }

        [TestMethod]
        public void SymmetricExceptWithTest()
        {
            var collection = new List<int> { 1, 3, 7, 15 };
            set.SymmetricExceptWith(collection);

            for (int i = 1; i < 10; ++i)
            {
                if (!set.Contains(i))
                {
                    if (i != 1 && i != 3 && i != 7)
                    {
                        Assert.Fail();
                    }
                }
                else
                {
                    if (i == 3 || i == 1 || i == 7)
                    {
                        Assert.Fail();
                    }
                }
            }

            Assert.IsTrue(set.Contains(15));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SymmetricExceptWithNullCollectionTest()
        {
            List<int> collection = null;
            set.SymmetricExceptWith(collection);
        }

        [TestMethod]
        public void UnionWithTest()
        {
            var collection = new List<int> { 1, 7, 15, -1, 4 };
            set.UnionWith(collection);

            for (int i = 1; i < 10; ++i)
            {
                if(!set.Contains(i))
                {
                    Assert.Fail();
                }
            }

            Assert.IsTrue(set.Contains(15));
            Assert.IsTrue(set.Contains(-1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UnionWithNullCollectionTest()
        {
            List<int> collection = null;
            set.UnionWith(collection);
        }
    }
}
