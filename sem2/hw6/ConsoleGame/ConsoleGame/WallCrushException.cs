using System;

namespace ConsoleGame
{
    /// <summary>
    /// Exception that is thrown when character has crushed into the wall.
    /// </summary>
    [Serializable]
    public class WallCrushException : InvalidOperationException
    {
        public WallCrushException() { }
        public WallCrushException(string message) : base(message) { }
        public WallCrushException(string message, Exception inner) : base(message, inner) { }
        protected WallCrushException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
