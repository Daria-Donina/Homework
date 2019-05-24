using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
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
