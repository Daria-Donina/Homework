namespace ParseTree
{
    class Addition : Operation
    {
        private string data;
        public override string Data
        {
            get => data;
            set => data = "+";
        }

        public override int Calculate() => int.Parse(LeftChild.Data) + int.Parse(RightChild.Data);
    }
}
