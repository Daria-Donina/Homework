using System;
using System.IO;

namespace ConsoleGame
{
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
            character.MoveLeft();
            map.MoveCharacter(character.Coordinates);
        }
        private void MoveRight()
        {
            character.MoveRight();
            map.MoveCharacter(character.Coordinates);
        }

        private void MoveUp()
        {
            character.MoveUp();
            map.MoveCharacter(character.Coordinates);
        }

        private void MoveDown()
        {
            character.MoveDown();
            map.MoveCharacter(character.Coordinates);
        }

        public void OnLeft(object sender, EventArgs args)
        {
            Console.Write(' ');
            Console.CursorLeft -= 1;

            Console.CursorLeft -= 1;

            MoveLeft();

            character.Print();
            Console.CursorLeft -= 1;
        }

        public void OnRight(object sender, EventArgs args)
        {
            Console.Write(' ');
            Console.CursorLeft -= 1;

            Console.CursorLeft += 1;

            MoveRight();

            character.Print();
            Console.CursorLeft -= 1;
        }

        public void OnUp(object sender, EventArgs args)
        {
            Console.Write(' ');
            Console.CursorLeft -= 1;

            Console.CursorTop -= 1;

            MoveUp();

            character.Print();
            Console.CursorLeft -= 1;
        }

        public void OnDown(object sender, EventArgs args)
        {
            Console.Write(' ');
            Console.CursorLeft -= 1;

            Console.CursorTop += 1;

            MoveDown();

            character.Print();
            Console.CursorLeft -= 1;
        }

        private void WelcomeMessage()
        {
            Console.WriteLine("You are '@'");
            Console.WriteLine("Сontrol your character with the arrow keys");
            Console.WriteLine("Try not to crush into the wall");
            Console.WriteLine("Press 'Esc' to finish the game");
            Console.WriteLine();
        }
    }
}
