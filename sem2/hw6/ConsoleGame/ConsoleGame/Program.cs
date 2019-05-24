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
            try
            {
                var data = new StreamReader("..\\..\\data.txt");

                var eventLoop = new EventLoop();
                var game = new Game(data);

                eventLoop.LeftHandler += game.OnLeft;
                eventLoop.RightHandler += game.OnRight;
                eventLoop.UpHandler += game.OnUp;
                eventLoop.DownHandler += game.OnDown;

                eventLoop.Run();
            }
            catch (WallCrushException)
            {
                Console.Clear();
                Console.WriteLine("You lost :(");
                Console.WriteLine("Try again next time!");
            }
			catch (WrongMapException)
			{
				Console.Clear();
				Console.WriteLine("The map is wrong");
			}
			catch (OutsideTheMapException)
			{
				Console.Clear();
				Console.WriteLine("You've gone outside the map :(");
				Console.WriteLine("Try again next time!");
			}
        }
    }
}
