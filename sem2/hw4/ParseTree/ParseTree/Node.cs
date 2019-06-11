namespace ParseTree
{
    /// <summary>
    /// An element of the tree.
    /// </summary>
    public abstract class Node
    {
        /// <summary>
        /// String data of the node.
        /// </summary>
        public virtual string Data { get; protected set; }

        /// <summary>
        /// Prints data of the node and its left and right subtrees.
        /// </summary>
        public abstract void Print();

        /// <summary>
        /// Calculates value of the node.
        /// </summary>
        /// <returns> A value of the node.</returns>
        public abstract int Calculate();
    }
}
