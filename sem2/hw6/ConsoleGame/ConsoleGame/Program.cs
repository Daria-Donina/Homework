using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleGame
{
    static class Program
    {
        static void Main(string[] args)
        {
            var data = new StreamReader("..\\..\\data.txt");

            var eventLoop = new EventLoop();
            var game = new Game();

            eventLoop.LeftHandler += game.OnLeft;
            eventLoop.RightHandler += game.OnRight;
            eventLoop.UpHandler += game.OnUp;
            eventLoop.DownHandler += game.OnDown;

            eventLoop.Run();
        }
    }
}
