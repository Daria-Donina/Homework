namespace SinglyLinkedList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SinglyLinkedList;

    [TestClass]
    public class ListTest
    {
        private List list;

        [TestInitialize]
        public void Initialize()
        {
            list = new List();
        }

        [TestMethod]
        public void AddFirstTest()
        {
            list.Add(1, 3);
            Assert.AreEqual(list.GetValue(1), 3);
            list.Add(1, 5);
            Assert.AreEqual(list.GetValue(1), 5);
        }

        [TestMethod]
        public void AddTest()
        {
            list.Add(1, 5);
            list.Add(2, -9);
            list.Add(3, 10);

            Assert.AreEqual(5, list.GetValue(1));
            Assert.AreEqual(-9, list.GetValue(2));
            Assert.AreEqual(10, list.GetValue(3));
        }

        [TestMethod]
        public void AddAtWrongPositionTest()
        {
            list.Clear();
            list.Add(56, 1);
            list.Add(-5, 1);
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        public void RemoveTest()
        {
            list.Add(1, 8);
            list.Add(2, 70);
            list.Add(3, 0);

            list.Remove(2);
            Assert.AreEqual(0, list.GetValue(2));
        }

        [TestMethod]
        public void RemoveFirstTest()
        {
            list.Add(1, 5);
            list.Add(2, 8);

            list.Remove(1);
            Assert.AreEqual(8, list.GetValue(1));
        }

        [TestMethod]
        public void SetValueTest()
        {
            list.Add(1, 4);
            list.Add(1, 15);

            list.SetValue(2, 7);
            Assert.AreEqual(7, list.GetValue(2));
        }

        [TestMethod]
        public void GetValueFromWrongPositionTest()
        {
            list.Clear();

            Assert.AreEqual(-1, list.GetValue(9));
            Assert.AreEqual(-1, list.GetValue(-6));
        }

        [TestMethod]
        public void ClearTest()
        {
            for (int i = 1; i <= 3; ++i)
            {
                list.Add(1, i);
            }
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        public void LengthTest()
        {
            list.Clear();

            for (int i = 0; i < 5; ++i)
            {
                list.Add(1, i);
            }
            Assert.AreEqual(5, list.Length);

            list.Remove(1);
            Assert.AreEqual(4, list.Length);
        }

        [TestMethod]
        public void EmptyListLengthTest()
        {
            list.Clear();

            Assert.AreEqual(0, list.Length);
        }

        [TestMethod]
        public void FindPositionByValueTest()
        {
            list.Add(1, -8);
            list.Add(2, 0);
            list.Add(3, 63);

            Assert.AreEqual(1, list.FindPositionByValue(-8));
            Assert.AreEqual(2, list.FindPositionByValue(0));
            Assert.AreEqual(3, list.FindPositionByValue(63));
        }

        [TestMethod]
        public void FindPositionByValueThatDoesNotExist()
        {
            list.Clear();

            list.Add(1, 9);

            Assert.AreEqual(-1, list.FindPositionByValue(59));
            Assert.AreEqual(-1, list.FindPositionByValue(30));
        }
    }
}
