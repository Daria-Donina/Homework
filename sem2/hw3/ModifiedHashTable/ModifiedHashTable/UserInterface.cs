using System;

namespace ModifiedHashTable
{
    public class UserInterface
    {
        private static void PrintChoiceOfHashFunction()
        {
            Console.WriteLine("Select hash function:");
            Console.WriteLine("1 - FNV hash function");
            Console.WriteLine("2 - Jenkins hash function");
            Console.WriteLine("3 - PJW hash function");
            Console.Write("Input number: ");
        }

        private static IHashFunction ChoiceOfHashFunction()
        {
            int number = int.Parse(Console.ReadLine());

            switch (number)
            {
                case 1:
                    return new FNVHashFunction();
                case 2:
                    return new JenkinsHashFunction();
                case 3:
                    return new PJWHashFunction();
                default:
                    throw new FormatException();
            }
        }

        private static void PrintCommands()
        {
            Console.WriteLine("1 - add data to hash table");
            Console.WriteLine("2 - remove data from hash table");
            Console.WriteLine("3 - check if data is in hash table");
            Console.WriteLine("4 - print hash table");
            Console.WriteLine("5 - clear hash table");
            Console.WriteLine("0 - exit");
            Console.WriteLine();
            Console.Write("Input number: ");
        }

        private string DataEntryRequest()
        {
            Console.WriteLine("Enter data");
            string data = Console.ReadLine();
            return data;
        }

        private void CommandExecution(IHashTable hashTable)
        {
            int number = int.Parse(Console.ReadLine());

            while (number != 0)
            {
                switch (number)
                {
                    case 1:
                        {
                            var data = DataEntryRequest();
                            hashTable.Add(data);
                        }
                        break;
                    case 2:
                        {
                            var data = DataEntryRequest();
                            hashTable.Remove(data);
                        }
                        break;
                    case 3:
                        {
                            var data = DataEntryRequest();
                            if (hashTable.Exists(data))
                            {
                                Console.WriteLine("Data is in the hash table");
                            }
                            else
                            {
                                Console.WriteLine("Data is not in the hash table");
                            }
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
            PrintChoiceOfHashFunction();

            var hashTable = new HashTable(ChoiceOfHashFunction());

            PrintCommands();

            CommandExecution(hashTable);
        }
    }
}
