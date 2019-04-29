namespace ParseTree
{
    /// <summary>
    /// Class implementing parse tree.
    /// </summary>
    class ParseTree
    {
        /// <summary>
        /// The root node of the tree.
        /// </summary>
        public Node Root { get; set; }
        
        /// <summary>
        /// Calculates value of the tree.
        /// </summary>
        /// <returns> An integer value of the tree.</returns>
        public int Calculate() => Root.Calculate();

        /// <summary>
        /// Prints parse tree.
        /// </summary>
        public void Print() => Root.Print();
    }
}
