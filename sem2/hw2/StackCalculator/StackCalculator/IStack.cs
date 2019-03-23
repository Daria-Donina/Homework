namespace StackCalculator
{
    public interface IStack
    {
        void Push(int value);
        int Pop();
        bool IsEmpty();
        int Peek();
    }
}
