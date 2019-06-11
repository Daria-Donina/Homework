using System;

namespace ParseTree
{
    /// <summary>
    /// Class implementing operand and containing an integer number.
    /// </summary>
    class Operand : Node
    {
        public Operand(string data) => Data = data;

        /// <summary>
        /// Prints an integer number of the operand.
        /// </summary>
        public override void Print() => Console.Write(Data);

        /// <summary>
        /// Transfers string data of the operand into an integer number.
        /// </summary>
        /// <returns> An integer number of the operand.</returns>
        public override int Calculate() => int.Parse(Data);
    }
}
