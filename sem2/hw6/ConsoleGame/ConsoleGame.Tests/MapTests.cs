using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleGame.Tests
{
    [TestClass]
    public class MapTests
    {
        StreamReader data;
        Map map;

        [TestMethod]
        [ExpectedException(typeof(WrongMapException))]
        public void WeirdSymbolsTest()
        {
            data = new StreamReader("..\\..\\WeirdSymbolsTest.txt");
            map = new Map(data);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongMapException))]
        public void NoMapSizeTest()
        {
            data = new StreamReader("..\\..\\NoMapSizeTest.txt");
            map = new Map(data);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongMapException))]
        public void TwoCharactersTest()
        {
            data = new StreamReader("..\\..\\TwoCharactersTest.txt");
            map = new Map(data);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongMapException))]
        public void ZeroCharactersTest()
        {
            data = new StreamReader("..\\..\\ZeroCharactersTest.txt");
            map = new Map(data);
        }

        [TestMethod]
        [ExpectedException(typeof(WallCrushException))]
        public void MoveToWallTest()
        {
            data = new StreamReader("..\\..\\MoveToWallTest.txt");
            map = new Map(data);

            map.MoveCharacter((map.CharacterCoordinates.x, map.CharacterCoordinates.y + 1));

            map.MoveCharacter((map.CharacterCoordinates.x - 1, map.CharacterCoordinates.y));
        }

        [TestMethod]
        [ExpectedException(typeof(OutsideTheMapException))]
        public void GoOutsideTheMapTest()
        {
            data = new StreamReader("..\\..\\GoOutsideTheMapTest.txt");
            map = new Map(data);

            for (int i = 0; i < 10; ++i)
            {
                map.MoveCharacter((map.CharacterCoordinates.x, map.CharacterCoordinates.y + 1));
            }
        }
    }
}
