namespace kr1.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using kr1;

    [TestClass]
    public class PriorityQueueTests
    {
        private PriorityQueue queue;

        [TestInitialize]
        public void Initialize()
        {
            queue = new PriorityQueue();
        }

        [TestMethod]
        [ExpectedException(typeof(DequeueWhenQueueIsEmptyException))]
        public void DequeueFromEmptyQueue() => queue.Dequeue();

        [TestMethod]
        public void DequeueOneElementTest()
        {
            var test = "ksfx.zmc";
            queue.Enqueue(3, test);
            Assert.AreEqual(test, queue.Dequeue());
        }

        [TestMethod]
        public void DequeueInTheRightOrderTest()
        {
            var test1 = "skfhks";
            var test2 = "jkhfsei;s";
            var test3 = "ka;fiwt";

            queue.Enqueue(16, test1);
            queue.Enqueue(13, test2);
            queue.Enqueue(17, test3);

            Assert.AreEqual(test3, queue.Dequeue());
            Assert.AreEqual(test1, queue.Dequeue());
            Assert.AreEqual(test2, queue.Dequeue());
        }

        [TestMethod]
        public void DequeueWhenPrioritiesAreEqual()
        {
            var test1 = "jruyoa";
            var test2 = "sjlf";

            queue.Enqueue(6, test1);
            queue.Enqueue(6, test2);

            Assert.AreEqual(test1, queue.Dequeue());
        }

        [TestMethod]
        public void DequeueWhenPrioritiesAreNegative()
        {
            var test1 = "suiru;z";
            var test2 = "kwfijl";
            var test3 = "skfjlz";

            queue.Enqueue(-9, test1);
            queue.Enqueue(-8, test2);
            queue.Enqueue(-10, test3);

            Assert.AreEqual(test2, queue.Dequeue());
            Assert.AreEqual(test1, queue.Dequeue());
            Assert.AreEqual(test3, queue.Dequeue());
        }

        [TestMethod]
        public void DequeueWhenPrioritiesAreZeros()
        {
            var test1 = "apaok;d";
            var test2 = "padkc";
            var test3 = "lafjcxl";

            queue.Enqueue(0, test1);
            queue.Enqueue(0, test2);
            queue.Enqueue(0, test3);

            Assert.AreEqual(test1, queue.Dequeue());
            Assert.AreEqual(test2, queue.Dequeue());
            Assert.AreEqual(test3, queue.Dequeue());
        }
    }
}
