using System;

namespace ModifiedHashTable
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
            catch (InvalidOperationException)
            {
                Console.WriteLine("The action is incorrect");
            }
        }
    }
}