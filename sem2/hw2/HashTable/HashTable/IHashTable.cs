namespace Hash_Table
{
    interface IHashTable
    {
        void Add(int value);
        void Remove(int value);
        bool Exists(int value);
        void Print();
        void Clear();
    }
}
