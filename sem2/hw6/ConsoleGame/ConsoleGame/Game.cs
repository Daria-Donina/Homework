using System;
using System.IO;

namespace ConsoleGame
{
    public class Game
    {
        private static int welcomeMessageHigh = 5;
        private Map map;
        private Character character;

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

        public void OnLeft(object sender, EventArgs args)
        {
            if (!map.IsWall(map.CharacterCoordinates.x, map.CharacterCoordinates.y - 1))
            {
                map.CharacterLeft();

                Console.Write(' ');
                Console.CursorLeft -= 1;

                Console.CursorLeft -= 1;

                character.MoveLeft(map);
                map.CharacterCame();

                character.Print();
                Console.CursorLeft -= 1;
            }
            else
            {
                throw new WallCrushException();
            }
        }

        public void OnRight(object sender, EventArgs args)
        {
            if (!map.IsWall(map.CharacterCoordinates.x, map.CharacterCoordinates.y + 1))
            {
                map.CharacterLeft();

                Console.Write(' ');
                Console.CursorLeft -= 1;

                Console.CursorLeft += 1;

                character.MoveRight(map);
                map.CharacterCame();

                character.Print();
                Console.CursorLeft -= 1;
            }
            else
            {
                throw new WallCrushException();
            }
        }

        public void OnUp(object sender, EventArgs args)
        {
            if (!map.IsWall(map.CharacterCoordinates.x - 1, map.CharacterCoordinates.y))
            {
                map.CharacterLeft();

                Console.Write(' ');
                Console.CursorLeft -= 1;

                Console.CursorTop -= 1;

                character.MoveUp(map);
                map.CharacterCame();

                character.Print();
                Console.CursorLeft -= 1;
            }
            else
            {
                throw new WallCrushException();
            }
        }

        public void OnDown(object sender, EventArgs args)
        {
            if (!map.IsWall(map.CharacterCoordinates.x + 1, map.CharacterCoordinates.y))
            {
                map.CharacterLeft();

                Console.Write(' ');
                Console.CursorLeft -= 1;

                Console.CursorTop += 1;

                character.MoveDown(map);
                map.CharacterCame();

                character.Print();
                Console.CursorLeft -= 1;
            }
            else
            {
                throw new WallCrushException();
            }
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
