﻿using System;

namespace ConsoleGame
{

	[Serializable]
	public class OutsideTheMapException : ArgumentOutOfRangeException
	{
		public OutsideTheMapException() { }
		public OutsideTheMapException(string message) : base(message) { }
		public OutsideTheMapException(string message, Exception inner) : base(message, inner) { }
		protected OutsideTheMapException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
