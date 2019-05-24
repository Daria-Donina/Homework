﻿using System;

namespace ConsoleGame
{
    class Character
    {
        public Character((int x, int y) initialCoordinates)
        {
            coordinates = initialCoordinates;
        }

        private (int x, int y) coordinates;

        public void MoveLeft(Map map)
        {
            --coordinates.y;
            map.CharacterCoordinates = coordinates;
        }

        public void MoveRight(Map map)
        {
            ++coordinates.y;
            map.CharacterCoordinates = coordinates;
        }

        public void MoveUp(Map map)
        {
            --coordinates.x;
            map.CharacterCoordinates = coordinates;
        }

        public void MoveDown(Map map)
        {
            ++coordinates.x;
            map.CharacterCoordinates = coordinates;
        }

        public void Print()
        {
            Console.Write('@');
        }
    }
}
