using System;

namespace UniqueList
{
    /// <summary>
    /// The exception that is thrown when there is an attempt to remove the value from the empty list.
    /// </summary>
    [Serializable]
    public class RemoveElementThatDoesNotExistException : InvalidOperationException
    {
        public RemoveElementThatDoesNotExistException() { }
        public RemoveElementThatDoesNotExistException(string message) : base(message) { }
        public RemoveElementThatDoesNotExistException(string message, Exception inner) : base(message, inner) { }
        protected RemoveElementThatDoesNotExistException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
