using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    public class Game
    {
        public void OnLeft(object sender, EventArgs args)
        {
            Console.CursorLeft -= 1;
        }

        public void OnRight(object sender, EventArgs args)
        {
            Console.CursorLeft += 1;
        }

        public void OnUp(object sender, EventArgs args)
        {
            Console.CursorTop -= 1;
        }

        public void OnDown(object sender, EventArgs args)
        {
            Console.CursorTop += 1;
        }
    }
}
