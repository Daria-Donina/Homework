namespace UniqueList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class UniqueListTests
    {
        private UniqueList list;

        [TestInitialize]
        public void Initialize()
        {
            list = new UniqueList();
        }

        [TestMethod]
        public void AddTest()
        {
            list.Add(1, "some data");
            Assert.AreEqual("some data", list.GetData(1));
        }

        [TestMethod]
        public void SetDataTest()
        {
            list.Add(1, "some data");
            list.SetData(1, "other data");
            Assert.AreEqual("other data", list.GetData(1));
        }

        [TestMethod]
        [ExpectedException(typeof(ValueIsInTheListException))]
        public void AddDataThatIsInTheList()
        {
            list.Add(1, "some data");
            list.Add(2, "other data");
            list.Add(3, "some data");
            Assert.AreEqual(2, list.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ValueIsInTheListException))]
        public void SetDataThatIsInTheList()
        {
            list.Add(1, "some data");
            list.Add(2, "other data");
            list.SetData(1, "some data");
        }
    }
}
