using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleGame.Tests
{
    [TestClass]
    public class CharacterTests
    {
        private Character character;

        [TestInitialize]
        public void Initialize()
        {
            character = new Character((0, 0));
        }

        [TestMethod]
        public void MoveLeftTest()
        {
            character.MoveLeft();
            Assert.AreEqual((0, - 1), character.Coordinates);
        }

        [TestMethod]
        public void MoveRightTest()
        {
            character.MoveRight();
            Assert.AreEqual((0, 1), character.Coordinates);
        }

        [TestMethod]
        public void MoveUpTest()
        {
            character.MoveUp();
            Assert.AreEqual((- 1, 0), character.Coordinates);
        }

        [TestMethod]
        public void MoveDownTest()
        {
            character.MoveDown();
            Assert.AreEqual((1, 0), character.Coordinates);
        }
    }
}
