using System;

namespace ConsoleGame
{
    public class Character
    {
        private (int x, int y) coordinates;

        public Character((int x, int y) initialCoordinates)
        {
            coordinates = initialCoordinates;
        }

        public (int x, int y) Coordinates { get => coordinates; }

        public void MoveLeft()
        {
            --coordinates.y;
        }

        public void MoveRight()
        {
            ++coordinates.y;
        }

        public void MoveUp()
        {
            --coordinates.x;
        }

        public void MoveDown()
        {
            ++coordinates.x;
        }

        public void Print()
        {
            Console.Write('@');
        }
    }
}
