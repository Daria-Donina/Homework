namespace ParseTree
{
    /// <summary>
    /// Class implementing addition operation.
    /// </summary>
    class Addition : Operation
    {
        /// <summary>
        /// Symbol of the addition operation.
        /// </summary>
        public override string Data => "+";

        /// <summary>
        /// Adds left subtree and right subtree of the node.
        /// </summary>
        /// <returns> An integer resut of the addition of left and right subtrees.</returns>
        public override int Calculate() => LeftChild.Calculate() + RightChild.Calculate();
    }
}
