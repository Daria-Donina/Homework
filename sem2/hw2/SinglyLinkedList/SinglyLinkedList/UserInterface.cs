using System;

namespace SinglyLinkedList
{
    public class UserInterface
    {
        private static void PrintCommands()
        {
            Console.WriteLine("1 - add element by position");
            Console.WriteLine("2 - remove element by position");
            Console.WriteLine("3 - get size of the list");
            Console.WriteLine("4 - check if the list is empty");
            Console.WriteLine("5 - get value by position");
            Console.WriteLine("6 - set value by position");
            Console.WriteLine("7 - print list");
            Console.WriteLine("0 - exit");
            Console.WriteLine();
            Console.Write("Input number: ");
        }

        private int PositionEntryRequest()
        {
            int position = 0;
            Console.WriteLine("Enter position");
            return position = int.Parse(Console.ReadLine());
        }

        private int ValueEntryRequest()
        {
            int value = 0;
            Console.WriteLine("Enter value");
            return value = int.Parse(Console.ReadLine());
        }

        private void CommandExecution(List list)
        {
            int number = 0;
            number = int.Parse(Console.ReadLine());

            while (number != 0)
            {
                int position = 0;
                int data = 0;
                switch (number)
                {
                    case 1:
                        position = PositionEntryRequest();
                        data = ValueEntryRequest();

                        list.Add(position, data);
                        break;
                    case 2:
                        position = PositionEntryRequest();

                        list.Remove(position);
                        break;
                    case 3:
                        Console.WriteLine($"Size of the list: {list.Length}");
                        break;
                    case 4:
                        if (list.IsEmpty())
                        {
                            Console.WriteLine("List is empty");
                        }
                        else
                        {
                            Console.WriteLine("List is not empty");
                        }
                        break;
                    case 5:
                        position = PositionEntryRequest();
                        Console.WriteLine($"Value in this position: {list.GetValue(position)}");
                        break;
                    case 6:
                        position = PositionEntryRequest();
                        data = ValueEntryRequest();

                        list.SetValue(position, data);
                        break;
                    case 7:
                        list.Print();
                        break;
                }

                Console.Write("Input number: ");
                number = int.Parse(Console.ReadLine());
            }
        }

        public void FullInteraction()
        {
            PrintCommands();

            var list = new List();

            CommandExecution(list);
        }
    }
}
