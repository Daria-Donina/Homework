namespace UniqueList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class ListTests
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
            var test1 = "Here's my intention. (Haha!)";
            var test2 = "It's just what I'm used to.";
            list.Add(1, test1);
            list.Add(1, test2);

            Assert.AreEqual(test2, list.GetData(1));
        }

        [TestMethod]
        public void AddAtRightOrderTest()
        {
            var test1 = "If we don’t stop leaving";
            list.Add(1, test1);

            var test2 = "If we don’t stop leaving accidents";
            list.Add(2, test2);

            var test3 = "We’ll never get that far";
            list.Add(3, test3);

            Assert.AreEqual(test1, list.GetData(1));
            Assert.AreEqual(test2, list.GetData(2));
            Assert.AreEqual(test3, list.GetData(3));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddAtWrongPositionTest()
        {
            list.Add(56, "first try");
            list.Add(-5, "second try");
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        public void RemoveTest()
        {
            var test1 = "I, I must confess";
            list.Add(1, test1);

            var test2 = "How hard I tried to breathe";
            list.Add(2, test2);

            var test3 = "Through the trees of loneliness.";
            list.Add(3, test3);

            list.Remove(2);
            Assert.AreEqual(test3, list.GetData(2));
        }

        [TestMethod]
        public void RemoveFirstTest()
        {
            var test1 = "And you, you must confess";
            list.Add(1, test1);

            var test2 = "How hard you need to see";
            list.Add(2, test2);

            list.Remove(1);
            Assert.AreEqual(test2, list.GetData(1));
        }

        [TestMethod]
        public void SetDataTest()
        {
            var test1 = "Through the heart beating out my chest.";
            list.Add(1, test1);

            var test2 = "Feel like we've been falling down";
            list.Add(1, test2);

            list.SetData(2, "new line");
            Assert.AreEqual("new line", list.GetData(2));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetDataFromWrongPositionTest()
        {
            Assert.AreEqual("", list.GetData(9));
            Assert.AreEqual("", list.GetData(-6));
        }

        [TestMethod]
        public void ClearTest()
        {
            list.Add(1, "Like these autumn leaves.");
            list.Add(1, "But baby don't let winter come,");
            list.Add(1, "Don't let our hearts freeze.");

            list.Clear();
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        public void LengthTest()
        {
            list.Add(1, "If the morning light don't fill our soul,");
            list.Add(1, "We will walk away from empty gold.");
            list.Add(1, "Dark as midnight sun,");
            list.Add(1, "Smoke as black as charcoal");
            list.Add(1, "Fills into our fragile lungs.");

            Assert.AreEqual(5, list.Length);

            list.Remove(1);
            Assert.AreEqual(4, list.Length);
        }

        [TestMethod]
        public void EmptyListLengthTest()
        {
            Assert.AreEqual(0, list.Length);
        }

        [TestMethod]
        public void FindPositionByDataTest()
        {
            var test1 = "Cause when our demons come,";
            list.Add(1, test1);

            var test2 = "Dancing in the shadows,";
            list.Add(2, test2);

            var test3 = "To a game that can't be won.";
            list.Add(3, test3);

            Assert.AreEqual(2, list.FindPositionByData(test2));
        }

        [TestMethod]
        public void FindPositionByDataThatDoesNotExistTest()
        {
            list.Add(1, "some data");

            Assert.AreEqual(-1, list.FindPositionByData("different data"));
        }

        [TestMethod]
        [ExpectedException(typeof(RemoveElementThatDoesNotExistException))]
        public void RemoveFromEmptyListTest()
        {
            list.Remove(1);
        }

        [TestMethod]
        [ExpectedException(typeof(RemoveElementThatDoesNotExistException))]
        public void RemoveFromWrongPositionTest()
        {
            list.Add(1, "Feel like we've been falling down");
            list.Add(2, "Like these autumn leaves.");
            list.Add(3, "But baby don't let winter come,");

            list.Remove(-10);
        }

        [TestMethod]
        public void SetDataThatIsAlreadyInTheList()
        {
            list.Add(1, "some data");
            list.Add(2, "other data");

            list.SetData(1, "other data");
            Assert.AreEqual("other data", list.GetData(1));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SetDataWrongPositionTest()
        {
            list.Add(1, "some data");
            list.Add(2, "other data");

            list.SetData(3, "more data");
        }
    }
}
