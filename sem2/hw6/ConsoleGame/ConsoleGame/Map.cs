using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleGame
{
    /// <summary>
    /// Class representing the map of the game.
    /// </summary>
    public class Map
    {
        /// <summary>
        /// Size of the map.
        /// </summary>
        public (int x, int y) Size { get; private set; }
        private readonly List<List<char>> gameMap;

        public Map(StreamReader data)
        {
            SizeReading(data);

            int characterCounter = 0;
            gameMap = new List<List<char>>();
            for (int x = 0; data.EndOfStream != true; ++x)
            {
                if (x >= Size.x)
                {
                    throw new WrongMapException();
                }

                var innerList = new List<char>();
                var line = data.ReadLine();

                if (line.Length != Size.y)
                {
                    throw new WrongMapException();
                }

                for (int y = 0; y < line.Length; ++y)
                {
	                if (line[y] == '@')
                    {
                        CharacterCoordinates = (x, y);
                        ++characterCounter;
                    }
                    else if (line[y] != '#' && line[y] != ' ')
                    {
                        throw new WrongMapException();
                    }

                    innerList.Add(line[y]);
                }

                gameMap.Add(innerList);
            }

            if (characterCounter != 1)
            {
                throw new WrongMapException();
            }
		}

        /// <summary>
        /// Prints the map.
        /// </summary>
        public void Print()
        {
            foreach (var line in gameMap)
            {
                foreach (var symbol in line)
                {
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
        }

        private void SizeReading(StreamReader data)
        {
            if (!int.TryParse(data.ReadLine(), out int resultX))
            {
                throw new WrongMapException();
            }

            if (!int.TryParse(data.ReadLine(), out int resultY))
            {
                throw new WrongMapException();
            }

            Size = (resultX, resultY);
        }

        /// <summary>
        /// Coordinates of the character of the game.
        /// </summary>
        public (int x, int y) CharacterCoordinates { get; set; }

        private void CharacterLeft() => gameMap[CharacterCoordinates.x][CharacterCoordinates.y] = ' ';

        private void CharacterCame() => gameMap[CharacterCoordinates.x][CharacterCoordinates.y] = '@';

        /// <summary>
        /// Moves character.
        /// </summary>
        /// <param name="newCoordinates">Coordinates to move character.</param>
        public void MoveCharacter((int x, int y) newCoordinates)
	    {
            CharacterLeft();

            if (newCoordinates.x >= Size.x || newCoordinates.y >= Size.y)
            {
                throw new OutsideTheMapException();
            }

            if (gameMap[newCoordinates.x][newCoordinates.y] == '#')
            {
                throw new WallCrushException();
            }

            CharacterCoordinates = newCoordinates;

            CharacterCame();
        }
    }
}
