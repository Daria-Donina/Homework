namespace ParseTree
{
    /// <summary>
    /// Class implementing subtraction operation.
    /// </summary>
    class Subtraction : Operation
    {
        /// <summary>
        /// Symbol of the subtraction operation.
        /// </summary>
        public override string Data => "-";

        /// <summary>
        /// Subtracts left subtree and right subtree of the node.
        /// </summary>
        /// <returns> An integer resut of the subtraction of left and right subtrees.</returns>
        public override int Calculate() => LeftChild.Calculate() - RightChild.Calculate();
    }
}
