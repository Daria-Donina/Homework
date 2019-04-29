namespace ParseTree
{
    /// <summary>
    /// Class implementing multiplication operation.
    /// </summary>
    class Multiplication : Operation
    {
        /// <summary>
        /// Symbol of the multiplication operation.
        /// </summary>
        public override string Data => "*";

        /// <summary>
        /// Multiplies left subtree and right subtree of the node.
        /// </summary>
        /// <returns> An integer resut of the multiplication of left and right subtrees.</returns>
        public override int Calculate() => LeftChild.Calculate() * RightChild.Calculate();
    }
}
