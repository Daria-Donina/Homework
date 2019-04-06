namespace ModifiedHashTable.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Modified_Hash_Table;

    [TestClass]
    public class HashTableTest
    {
        private HashTable hashTable;

        [TestInitialize]
        public void Initialize()
        {
            hashTable = new HashTable();
        }

        [TestMethod]
        public void AddTest()
        {
            for (int i = -2; i < 4; ++i)
            {
                hashTable.Add(i);
            }

            for (int i = -2; i < 4; ++i)
            {
                Assert.IsTrue(hashTable.Exists(i));
            }

            Assert.IsFalse(hashTable.Exists(9));
            Assert.IsFalse(hashTable.Exists(-15));
        }

        [TestMethod]
        public void RemoveTest()
        {
            hashTable.Add(9);
            hashTable.Add(7);
            hashTable.Add(-6);

            hashTable.Remove(7);
            Assert.IsFalse(hashTable.Exists(7));

            hashTable.Remove(9);
            Assert.IsFalse(hashTable.Exists(9));

            hashTable.Remove(-6);
            Assert.IsFalse(hashTable.Exists(-6));
        }

        [TestMethod]
        public void ClearTest()
        {
            hashTable.Add(10);
            hashTable.Add(15);
            hashTable.Add(23);

            hashTable.Clear();

            Assert.IsFalse(hashTable.Exists(10));
            Assert.IsFalse(hashTable.Exists(15));
            Assert.IsFalse(hashTable.Exists(23));
        }

        [TestMethod]
        public void RemoveFromEmptyHashTable()
        {
            hashTable.Remove(7);
        }

        [TestMethod]
        public void RemoveElementThatIsNotInTheHashTableTest()
        {
            hashTable.Add(65);
            hashTable.Add(74);
            hashTable.Add(38);

            hashTable.Remove(5);
        }

        [TestMethod]
        public void AddingTheSameElementIsNotPossibleTest()
        {
            hashTable.Add(10);
            hashTable.Add(10);

            hashTable.Remove(10);
            Assert.IsFalse(hashTable.Exists(10));
        }
    }
}
