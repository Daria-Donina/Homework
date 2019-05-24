using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleGame
{
    class Map
    {
        private List<List<char>> gameMap;
        public Map(StreamReader data)
        {
			int characterCounter = 0;
            gameMap = new List<List<char>>();
            for (int x = 0; data.EndOfStream != true; ++x)
            {
                var innerList = new List<char>();
                var line = data.ReadLine();

                for (int y = 0; y < line.Length; ++y)
                {
                    if (line[y] == '@')
                    {
                        CharacterCoordinates = (x, y);
						++characterCounter;
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

        public void Print()
        {
            foreach (var line in gameMap)
            {
                foreach(var symbol in line)
                {
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
        }


        public (int x, int y) CharacterCoordinates { get; set; }

        public void CharacterCame()
        {
            int x = CharacterCoordinates.x;
            int y = CharacterCoordinates.y;
            gameMap[x][y] = '@';
        }

        public void CharacterLeft()
		{
            int x = CharacterCoordinates.x;
            int y = CharacterCoordinates.y;
            gameMap[x][y] = ' ';
        }

        public bool IsWall(int x, int y)
		{
			if (x >= gameMap.Count || y >= gameMap[x].Count)
			{
				throw new OutsideTheMapException();
			}
			return gameMap[x][y] == '#';
		}
    }
}
