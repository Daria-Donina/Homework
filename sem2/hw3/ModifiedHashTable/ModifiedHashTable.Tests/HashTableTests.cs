namespace Modified_Hash_Table.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ModifiedHashTable;

    [TestClass]
    public class HashTableTest
    {
        private HashTable fNVHashTable;
        private HashTable jenkinsHashTable;
        private HashTable pJWHashTable;

        [TestInitialize]
        public void Initialize()
        {
            fNVHashTable = new HashTable(new FNVHashFunction());
            jenkinsHashTable = new HashTable(new JenkinsHashFunction());
            pJWHashTable = new HashTable(new PJWHashFunction());
        }

        private static void AddOneTest(HashTable hashTable)
        {
            var test = "Test string";
            hashTable.Add(test);

            Assert.IsTrue(hashTable.Exists(test));
        }

        [TestMethod]
        public void FNVAddOneTest() => AddOneTest(fNVHashTable);

        [TestMethod]
        public void JenkinsAddOneTest() => AddOneTest(jenkinsHashTable);

        [TestMethod]
        public void PJWAddOneTest() => AddOneTest(pJWHashTable);

        private static void ExpandTest(HashTable hashTable)
        {
            var size = hashTable.Size;
            if (size > 6)
            {
                Assert.IsFalse(false);
            }

            hashTable.Add("Baby, I'm dancing in the dark with you between my arms");
            hashTable.Add("Barefoot on the grass, listening to our favorite song");
            hashTable.Add("When you said you looked a mess, I whispered underneath my breath");
            hashTable.Add("But you heard it, darling, you look perfect tonight");
            hashTable.Add("Well I found a woman, stronger than anyone I know");
            hashTable.Add("She shares my dreams, I hope that someday I'll share her home");
            hashTable.Add("I found a love, to carry more than just my secrets");

            var newSize = hashTable.Size;

            Assert.IsTrue(newSize == size * 2);
        }

        [TestMethod]
        public void FNVExpandTest() => ExpandTest(fNVHashTable);

        [TestMethod]
        public void JenkinsExpandTest() => ExpandTest(jenkinsHashTable);

        [TestMethod]
        public void PJWExpandTest() => ExpandTest(pJWHashTable);

        private static void RemoveOneTest(HashTable hashTable)
        {
            var test = "No, it's much better to face these kinds of things with a sense of poise and rationality";
            hashTable.Add(test);
            hashTable.Remove(test);
            Assert.IsFalse(hashTable.Exists(test));
        }

        [TestMethod]
        public void FNVRemoveOneTest() => RemoveOneTest(fNVHashTable);

        [TestMethod]
        public void JenkinsRemoveOneTest() => RemoveOneTest(jenkinsHashTable);

        [TestMethod]
        public void PJWRemoveOneTest() => RemoveOneTest(pJWHashTable);

        private static void RemoveFromTheEmptyHashTable(HashTable hashTable) => hashTable.Remove("Something");

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FNVRemoveFromTheEmptyHashTable() => RemoveFromTheEmptyHashTable(fNVHashTable);

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void JenkinsRemoveFromTheEmptyHashTable() => RemoveFromTheEmptyHashTable(jenkinsHashTable);

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PJWRemoveFromTheEmptyHashTable() => RemoveFromTheEmptyHashTable(pJWHashTable);

        private static void ClearTest(HashTable hashTable)
        {
            var test1 = "Lolly, lolly, lolly bomb, lolly, lolly, lolly";
            var test2 = "Lolly, lolly, lolly bomb, lolly, lolly, lolly bomb";
            hashTable.Add(test1);
            hashTable.Add(test2);
            hashTable.Clear();
            Assert.IsFalse(hashTable.Exists(test1));
            Assert.IsFalse(hashTable.Exists(test2));
        }

        [TestMethod]
        public void FNVClearTest() => ClearTest(fNVHashTable);

        [TestMethod]
        public void JenkinsClearTest() => ClearTest(jenkinsHashTable);

        [TestMethod]
        public void PJWClearTest() => ClearTest(pJWHashTable);

        private static void RemoveWhenStringDoesNotExist(HashTable hashTable)
        {
            hashTable.Add("fjksfl");
            hashTable.Add("jshfl");
            hashTable.Add("tioep");

            hashTable.Remove("lksjflk");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FNVRemoveWhenStringDoesNotExist() => RemoveWhenStringDoesNotExist(fNVHashTable);

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void JenkinsRemoveWhenStringDoesNotExist() => RemoveWhenStringDoesNotExist(jenkinsHashTable);

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PJWRemoveWhenStringDoesNotExist() => RemoveWhenStringDoesNotExist(pJWHashTable);

        private static void AddingTheSameElementIsNotPossibleTest(HashTable hashTable)
        {
            var test = "The same";
            hashTable.Add(test);
            hashTable.Add(test);

            hashTable.Remove(test);
            Assert.IsFalse(hashTable.Exists(test));
        }

        [TestMethod]
        public void FNVAddingTheSameElementIsNotPossibleTest() => AddingTheSameElementIsNotPossibleTest(fNVHashTable);

        [TestMethod]
        public void JenkinsAddingTheSameElementIsNotPossibleTest() => AddingTheSameElementIsNotPossibleTest(jenkinsHashTable);

        [TestMethod]
        public void PJWAddingTheSameElementIsNotPossibleTest() => AddingTheSameElementIsNotPossibleTest(pJWHashTable);
    }
}
