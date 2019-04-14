using System;

namespace SinglyLinkedList
{
    /// <summary>
    /// An interaction between the program and the user.
    /// </summary>
    class UserInterface
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
            Console.WriteLine("8 - clear the list");
            Console.WriteLine("0 - exit");
            Console.WriteLine();
            Console.Write("Input number: ");
        }

        private static int PositionEntryRequest()
        {
            Console.WriteLine("Enter position");
            return int.Parse(Console.ReadLine());
        }

        private static int ValueEntryRequest()
        {
            Console.WriteLine("Enter value");
            return int.Parse(Console.ReadLine());
        }

        private static void CommandExecution(List list)
        {
            int number = int.Parse(Console.ReadLine());

            while (number != 0)
            {
                switch (number)
                {
                    case 1:
                        {
                            int position = PositionEntryRequest();
                            int data = ValueEntryRequest();

                            list.Add(position, data);
                        }
                        break;
                    case 2:
                        {
                            int position = PositionEntryRequest();

                            list.Remove(position);
                        }
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
                        {
                            int position = PositionEntryRequest();
                            Console.WriteLine($"Value in this position: {list.GetValue(position)}");
                        }
                        break;
                    case 6:
                        {
                            int position = PositionEntryRequest();
                            int data = ValueEntryRequest();

                            list.SetValue(position, data);
                        }
                        break;
                    case 7:
                        list.Print();
                        break;
                    case 8:
                        list.Clear();
                        break;
                    default:
                        Console.WriteLine("Enter correct number");
                        break;
                }

                Console.Write("Input number: ");
                number = int.Parse(Console.ReadLine());
            }
        }

        /// <summary>
        /// Combines all the methods to provide interaction with the user.
        /// </summary>
        public void FullInteraction()
        {
            PrintCommands();

            var list = new List();

            CommandExecution(list);
        }
    }
}
