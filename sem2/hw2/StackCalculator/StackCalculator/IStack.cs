namespace StackCalculator
{
    public interface IStack
    {
        bool Push(char value);
        int Pop();
        bool IsEmpty();
        int Peek();
    }
}
