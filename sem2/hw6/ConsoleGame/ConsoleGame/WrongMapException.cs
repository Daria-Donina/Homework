using System;

namespace ConsoleGame
{
    /// <summary>
    /// Exception that is thrown when the map is wrong.
    /// </summary>
	[Serializable]
	public class WrongMapException : FormatException
	{
		public WrongMapException() { }
		public WrongMapException(string message) : base(message) { }
		public WrongMapException(string message, Exception inner) : base(message, inner) { }
		protected WrongMapException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
