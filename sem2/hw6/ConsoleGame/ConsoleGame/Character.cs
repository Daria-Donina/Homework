using System;

namespace ConsoleGame
{
    /// <summary>
    /// Class representing the character of the game.
    /// </summary>
    public class Character
    {
        private (int x, int y) coordinates;

        public Character((int x, int y) initialCoordinates) => coordinates = initialCoordinates;

        /// <summary>
        /// Coordinates of the character on the map.
        /// </summary>
        public (int x, int y) Coordinates { get => coordinates; }

        /// <summary>
        /// Moves the character one step to the left.
        /// </summary>
        public void MoveLeft() => --coordinates.y;

        /// <summary>
        /// Moves the character one step to the right.
        /// </summary>
        public void MoveRight() => ++coordinates.y;

        /// <summary>
        /// Moves the character one step up.
        /// </summary>
        public void MoveUp() => --coordinates.x;

        /// <summary>
        /// Moves the character one step down.
        /// </summary>
        public void MoveDown() => ++coordinates.x;

        /// <summary>
        /// Prints character.
        /// </summary>
        public void Print() => Console.Write('@');
    }
}
