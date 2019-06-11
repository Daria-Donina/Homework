using System;

namespace ParseTree
{
    /// <summary>
    /// Class implementing operation.
    /// </summary>
    abstract class Operation : Node
    {
        /// <summary>
        /// First operand of the operation.
        /// </summary>
        public Node LeftChild { get; set; }

        /// <summary>
        /// Second operand of the operation.
        /// </summary>
        public Node RightChild { get; set; }

        /// <summary>
        /// Prints left operand, operation itself and right operand.
        /// </summary>
        public override void Print()
        {
            Console.Write("(");
            LeftChild.Print();
            Console.Write($" {Data} ");
            RightChild.Print();
            Console.Write(")");
        }
    }
}
