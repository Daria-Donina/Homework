using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Task1.Tests
{
    [TestClass]
    public class SortedSetTests
    {
        SortedSet set;
        ListComparer<List<string>> comparer;
        [TestInitialize]
        public void Initialize()
        {
            set = new SortedSet();
            comparer = new ListComparer<List<string>>();
        }


        [TestMethod]
        public void OrderTest()
        {
            List<string> list1 = new List<string>();
            list1.Add("ksfj");
            list1.Add("slfk;sf");
            list1.Add(";sfk,vc/.v");
            set.Add(list1);

            List<string> list2 = new List<string>();
            list2.Add("sf;,c");
            list2.Add("lsf");
            set.Add(list2);

            List<string> list3 = new List<string>();
            list3.Add("lsfcms");
            set.Add(list3);

            Assert.IsTrue(comparer.Compare(list1, list2) > 0);
            Assert.IsTrue(comparer.Compare(list2, list3) > 0);
        }

        [TestMethod]
        public void SameListsTest()
        {
            List<string> list1 = new List<string>();
            list1.Add("sf;,c");
            list1.Add("lsf");
            set.Add(list1);

            List<string> list2 = new List<string>();
            list2.Add("sf;,c");
            list2.Add("lsf");
            set.Add(list2);

            Assert.IsTrue(comparer.Compare(list1, list2) == 0);
        }
    }
}
