using System;

namespace ConsoleGame
{

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
