using System;

namespace kr1
{
    /// <summary>
    /// Exception thrown when empty queue is trying to be dequeued.
    /// </summary>
    [Serializable]
    public class DequeueWhenQueueIsEmptyException : InvalidOperationException
    {
        public DequeueWhenQueueIsEmptyException() { }
        public DequeueWhenQueueIsEmptyException(string message) : base(message) { }
        public DequeueWhenQueueIsEmptyException(string message, Exception inner) : base(message, inner) { }
        protected DequeueWhenQueueIsEmptyException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
