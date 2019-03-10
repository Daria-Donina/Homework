using System;

namespace Hash_Table
{
    public class UserInterface
    {
        private static void PrintCommands()
        {
            Console.WriteLine("1 - add value to hash table");
            Console.WriteLine("2 - remove value from hash table");
            Console.WriteLine("3 - check if value in hash table");
            Console.WriteLine("4 - print hash table");
            Console.WriteLine("5 - clear hash table");
            Console.WriteLine("0 - exit");
            Console.WriteLine();
            Console.Write("Input number: ");
        }

        private int ValueEntryRequest()
        {
            int value = 0;
            Console.WriteLine("Enter value");
            return value = int.Parse(Console.ReadLine());
        }

        private void CommandExecution(HashTable hashTable)
        {
            int number = 0;
            number = int.Parse(Console.ReadLine());

            while (number != 0)
            {
                int value = 0;
                switch (number)
                {
                    case 1:
                        value = ValueEntryRequest();
                        hashTable.Add(value);
                        break;
                    case 2:
                        value = ValueEntryRequest();
                        hashTable.Remove(value);
                        break;
                    case 3:
                        value = ValueEntryRequest();
                        if (hashTable.Exists(value))
                        {
                            Console.WriteLine("Value is in the hash table");
                        }
                        else
                        {
                            Console.WriteLine("Value is not in the hash table");
                        }
                        break;
                    case 4:
                        hashTable.Print();
                        break;
                    case 5:
                        hashTable.Clear();
                        break;
                }

                Console.Write("Input number: ");
                number = int.Parse(Console.ReadLine());
            }
        }

        public void FullInteraction()
        {
            PrintCommands();

            var hashTable = new HashTable();

            CommandExecution(hashTable);
        }
    }
}
