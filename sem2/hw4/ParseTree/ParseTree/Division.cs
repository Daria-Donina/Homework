namespace ParseTree
{
    /// <summary>
    /// Class implementing division operation.
    /// </summary>
    class Division : Operation
    {
        /// <summary>
        /// Symbol of the division operation.
        /// </summary>
        public override string Data => "/";

        /// <summary>
        /// Divides left subtree and right subtree of the node.
        /// </summary>
        /// <returns> An integer resut of the division of left and right subtrees.</returns>
        public override int Calculate() => LeftChild.Calculate() / RightChild.Calculate();
    }
}
