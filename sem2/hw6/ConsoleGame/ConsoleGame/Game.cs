using System;
using System.IO;

namespace ConsoleGame
{
    /// <summary>
    /// Class representing console game.
    /// </summary>
    public class Game
    {
        private static readonly int welcomeMessageHigh = 5;
        private readonly Map map;
        private readonly Character character;

        public Game(StreamReader data)
        {
            WelcomeMessage();
            map = new Map(data);
            map.Print();
            Console.CursorTop = welcomeMessageHigh + map.CharacterCoordinates.x;
            Console.CursorLeft = map.CharacterCoordinates.y;
            Console.CursorVisible = false;

            var initialCoordinates = map.CharacterCoordinates;

            character = new Character(initialCoordinates);
        }

        private void MoveLeft()
        {
			Console.CursorLeft -= 1;
			character.MoveLeft();
            map.MoveCharacter(character.Coordinates);
        }

        private void MoveRight()
        {
			Console.CursorLeft += 1;
			character.MoveRight();
            map.MoveCharacter(character.Coordinates);
        }

        private void MoveUp()
        {
			Console.CursorTop -= 1;
			character.MoveUp();
            map.MoveCharacter(character.Coordinates);
        }

        private void MoveDown()
        {
			Console.CursorTop += 1;
			character.MoveDown();
            map.MoveCharacter(character.Coordinates);
        }

        private void RemovingOldCharacter()
        {
            Console.Write(' ');
            Console.CursorLeft -= 1;
        }

        private void PrintingNewCharacter()
        {
            Character.Print();
            Console.CursorLeft -= 1;
        }

        /// <summary>
        /// Invoking method when left arrow button is pressed.
        /// </summary>
        /// <param name="sender">Left arrow button.</param>
        /// <param name="args">Extra information for handler.</param>
        public void OnLeft(object sender, EventArgs args)
        {
            RemovingOldCharacter();
            MoveLeft();
            PrintingNewCharacter();
        }

        /// <summary>
        /// Invoking method when right arrow button is pressed.
        /// </summary>
        /// <param name="sender">Right arrow button.</param>
        /// <param name="args">Extra information for handler.</param>
        public void OnRight(object sender, EventArgs args)
        {
            RemovingOldCharacter();
            MoveRight();
            PrintingNewCharacter();
        }

        /// <summary>
        /// Invoking method when up arrow button is pressed.
        /// </summary>
        /// <param name="sender">Up arrow button.</param>
        /// <param name="args">Extra information for handler.</param>
        public void OnUp(object sender, EventArgs args)
        {
			RemovingOldCharacter();
			MoveUp();
			PrintingNewCharacter();
		}

        /// <summary>
        /// Invoking method when down arrow button is pressed.
        /// </summary>
        /// <param name="sender">Down arrow button.</param>
        /// <param name="args">Extra information for handler.</param>
        public void OnDown(object sender, EventArgs args)
        {
			RemovingOldCharacter();
			MoveDown();
			PrintingNewCharacter();
		}

        private static void WelcomeMessage()
        {
            Console.WriteLine("You are '@'");
            Console.WriteLine("Сontrol your character with the arrow keys");
            Console.WriteLine("Try not to crush into the wall");
            Console.WriteLine("Press 'Esc' to finish the game");
            Console.WriteLine();
        }
    }
}
