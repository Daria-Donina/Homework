using System;

namespace Modified_Hash_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            var interaction = new UserInterface();

            try
            {
                interaction.FullInteraction();
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect input");
            }
        }
    }
}