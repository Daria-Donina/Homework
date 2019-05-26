using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleGame.Tests
{
    [TestClass]
    public class MapTests
    {
        [TestMethod]
        [ExpectedException(typeof(WrongMapException))]
        public void WeirdSymbolsTest()
        {
            var data = new StreamReader("..\\..\\WeirdSymbolsTest.txt");
            _ = new Map(data);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongMapException))]
        public void NoMapSizeTest()
        {
            var data = new StreamReader("..\\..\\NoMapSizeTest.txt");
            _ = new Map(data);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongMapException))]
        public void TwoCharactersTest()
        {
            var data = new StreamReader("..\\..\\TwoCharactersTest.txt");
            _ = new Map(data);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongMapException))]
        public void ZeroCharactersTest()
        {
            var data = new StreamReader("..\\..\\ZeroCharactersTest.txt");
            _ = new Map(data);
        }

        [TestMethod]
        [ExpectedException(typeof(WallCrushException))]
        public void MoveToWallTest()
        {
            var data = new StreamReader("..\\..\\MoveToWallTest.txt");
            var map = new Map(data);

            map.MoveCharacter((map.CharacterCoordinates.x, map.CharacterCoordinates.y + 1));

            map.MoveCharacter((map.CharacterCoordinates.x - 1, map.CharacterCoordinates.y));
        }

        [TestMethod]
        [ExpectedException(typeof(OutsideTheMapException))]
        public void GoOutsideTheMapTest()
        {
            var data = new StreamReader("..\\..\\GoOutsideTheMapTest.txt");
            var map = new Map(data);

            for (int i = 0; i < 10; ++i)
            {
                map.MoveCharacter((map.CharacterCoordinates.x, map.CharacterCoordinates.y + 1));
            }
        }
    }
}
