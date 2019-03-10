namespace SinglyLinkedList
{
    interface IList
    {
        void Add(int position, int data);
        void Remove(int position);
        bool IsEmpty();
        int GetValue(int position);
        void SetValue(int position, int value);
        void Print();
        int FindPositionByValue(int value);
        void Clear();
    }
}
