using System;

namespace UniqueList
{
    /// <summary>
    /// The exception that is thrown when there is an attempt to add the value that is already in the list.
    /// </summary>
    [Serializable]
    public class ValueIsInTheListException : InvalidOperationException
    {
        public ValueIsInTheListException() { }
        public ValueIsInTheListException(string message) : base(message) { }
        public ValueIsInTheListException(string message, Exception inner) : base(message, inner) { }
        protected ValueIsInTheListException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
