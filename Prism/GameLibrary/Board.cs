using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class Board
    {
        private bool?[][] _state;

        #region Constructors

        public Board(bool?[][] state)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state");
            }

            _state = state;
        }

        public Board(int m = 5, int n = 5)
        {
            if (m < 1)
            {
                throw new ArgumentException("value must be positive", "m");
            }

            if (n < 1)
            {
                throw new ArgumentException("value must be positive", "n");
            }

            _state = new bool?[m][];
            for (var i = 0; i < m; i++)
            {
                _state[i] = new bool?[n];
            }
        }

        #endregion

        /// <summary>
        /// Plays a move on the board by the specified player
        /// </summary>
        /// <param name="x">X coordinate of board</param>
        /// <param name="y">Y coordinate of board</param>
        /// <param name="isPlayer1">True if player one</param>
        /// <returns>True if the move wins the game</returns>
        public bool Move(int x, int y, bool isPlayer1)
        {
            if (x < 1)
            {
                throw new ArgumentException("Value must be positive", "x");
            }

            if (y < 1)
            {
                throw new ArgumentException("Value must be positive", "y");
            }

            var xLength = _state.GetLength(0);

            if (x > xLength)
            {
                throw new ArgumentException(string.Format("Value cannot be more than max dimension {0}", xLength), "x");
            }

            var yLength = _state[x - 1].GetLength(0);

            if (y > yLength)
            {
                throw new ArgumentException(string.Format("Value cannot be more than max dimension {0}", yLength), "y");
            }

            // Given a position in the array, determine if it has not been previously set
            if (_state[x - 1][y - 1].HasValue)
            {
                throw new InvalidOperationException(string.Format("Position x {0}, y {1} has already been played", x, y));
            }

            // Set the new value
            _state[x - 1][y - 1] = isPlayer1;

            // Calculate all combinations, looking for a winning condition
            // There are 8 total directions from location x, y
            // The calculation in one direction has a corresponding equivalent in the other
            // This means a total of 4 calculations, combining the result forwards and backwards
            // This would be a recursive pattern with 3 termination conditions
            // 1) Value is null
            // 2) Value is the other player
            // 3) Reached the boundary

            // Specify the 4 unique directions
            int[][] direction = { new int[] {0, 1}, new int[] { 1, 1}, new int[] { 1, 0}, new int[] { -1, 1}};

            for (var i = 0; i < direction.Length; i++)
            {
                var deltaX = direction[i][0];
                var deltaY = direction[i][1];
                var count = EvaluateMove(x, y, deltaX, deltaY, isPlayer1);
                if (count >= 5) { return true; }
            }

            return false;
        }

        /// <summary>
        /// Evaluates the unique direction specified by deltaX and deltaY
        /// </summary>
        /// <param name="x">X coordinate of board</param>
        /// <param name="y">Y coordinate of board</param>
        /// <param name="deltaX">X increment</param>
        /// <param name="deltaY">Y increment</param>
        /// <param name="isPlayer1">True if player one</param>
        /// <returns>Total count for player in the specified direction</returns>
        private int EvaluateMove(int x, int y, int deltaX, int deltaY, bool isPlayer1)
        {
            return 1 + Evaluate(x, y, deltaX, deltaY, isPlayer1) + Evaluate(x, y, -deltaX, -deltaY, isPlayer1);
        }

        /// <summary>
        /// Evaluates the state coordinates in a recursive method
        /// </summary>
        /// <param name="x">X coordinate of board</param>
        /// <param name="y">Y coordinate of board</param>
        /// <param name="deltaX">X increment</param>
        /// <param name="deltaY">Y increment</param>
        /// <param name="isPlayer1">True if player one</param>
        /// <returns>1 if current player or 0 if not</returns>
        private int Evaluate(int x, int y, int deltaX, int deltaY, bool isPlayer1)
        {
            // Adjust the coordinates
            x += deltaX;
            y += deltaY;

            // Convert coordinates to array indices
            var i = (x - 1);
            var j = (y - 1);

            // Hit the boundary?
            if (i < 0 || i >= _state.Length)
            {
                return 0;
            }

            // Hit the boundary
            if (j < 0 || j >= _state[i].Length)
            {
                return 0;
            }

            // No value set or other player
            if (!_state[i][j].HasValue || _state[i][j].Value != isPlayer1)
            {
                return 0;
            }

            return 1 + Evaluate(x, y, deltaX, deltaY, isPlayer1);
        }
    }
}
