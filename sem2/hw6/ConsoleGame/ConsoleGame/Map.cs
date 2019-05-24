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
                    }

                    innerList.Add(line[y]);
                }

                gameMap.Add(innerList);
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

        public bool IsWall(int x, int y) => gameMap[x][y] == '#';
    }
}
