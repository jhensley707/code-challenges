using System;
using GameLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrismUnitTests
{
    [TestClass]
    public class BoardTests
    {
        private bool?[][] _sevenBySevenArray;

        [TestInitialize]
        public void Initialize()
        {
            _sevenBySevenArray = new bool?[][]
            {
                new bool?[] { new bool?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?() },
                new bool?[] { new bool?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?() },
                new bool?[] { new bool?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?() },
                new bool?[] { new bool?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?() },
                new bool?[] { new bool?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?() },
                new bool?[] { new bool?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?() },
                new bool?[] { new bool?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?() },
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BoardWithNullStateShouldThrowException()
        {
            bool?[][] boardState = null;

            var board = new Board(boardState);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BoardWithInvalidMDimensionShouldThrowException()
        {
            var m = 0;
            var n = 3;
            var board = new Board(m, n);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BoardWithInvalidNDimensionShouldThrowException()
        {
            var m = 3;
            var n = 0;
            var board = new Board(m, n);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MoveShouldThrowExceptionWith0X()
        {
            var x = 0;
            var y = 1;
            var isPlayer1 = true;
            var board = new Board(7, 7);

            board.Move(x, y, isPlayer1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MoveShouldThrowExceptionWith0Y()
        {
            var x = 1;
            var y = 0;
            var isPlayer1 = true;
            var board = new Board(7, 7);

            board.Move(x, y, isPlayer1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MoveShouldThrowExceptionWith8X()
        {
            var x = 8;
            var y = 1;
            var isPlayer1 = true;
            var board = new Board(7, 7);

            board.Move(x, y, isPlayer1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MoveShouldThrowExceptionWith8Y()
        {
            var x = 1;
            var y = 8;
            var isPlayer1 = true;
            var board = new Board(7, 7);

            board.Move(x, y, isPlayer1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MoveShouldThrowExceptionWithPlayedLocation()
        {
            var x = 7;
            var y = 7;
            var isPlayer1 = true;
            _sevenBySevenArray[6][6] = false;

            var board = new Board(_sevenBySevenArray);

            board.Move(x, y, isPlayer1);
        }

        [TestMethod]
        public void MoveShouldReturnTrueForWin()
        {
            var x = 2;
            var y = 2;
            var isPlayer1 = true;
            _sevenBySevenArray[1][5] = true;
            _sevenBySevenArray[1][4] = true;
            _sevenBySevenArray[1][3] = true;
            _sevenBySevenArray[1][2] = true;
            _sevenBySevenArray[2][5] = false;
            _sevenBySevenArray[3][4] = false;
            _sevenBySevenArray[4][3] = false;
            _sevenBySevenArray[5][2] = false;

            var board = new Board(_sevenBySevenArray);

            var isWin = board.Move(x, y, isPlayer1);

            Assert.IsTrue(isWin);
        }

        [TestMethod]
        public void MoveShouldReturnFalseWhenXBound()
        {
            var x = 4;
            var y = 2;
            var isPlayer1 = false;
            _sevenBySevenArray[1][5] = true;
            _sevenBySevenArray[1][4] = true;
            _sevenBySevenArray[1][3] = true;
            _sevenBySevenArray[1][2] = true;
            _sevenBySevenArray[4][1] = false;
            _sevenBySevenArray[5][1] = false;
            _sevenBySevenArray[6][1] = false;

            var board = new Board(_sevenBySevenArray);

            var isWin = board.Move(x, y, isPlayer1);

            Assert.IsFalse(isWin);
        }
    }
}
