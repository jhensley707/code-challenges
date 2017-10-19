using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedaronMedical
{
    /// <summary>
    /// Given an array of coins, what is the minimum number of coins
    /// that must be flipped so that all coins show the same face?
    /// <para>
    /// A 0 represents Heads; a 1 represents Tails</para>
    /// </summary>
    public class CodingTask1
    {
        /// <summary>
        /// Loops through array once, counting only Heads. At the end,
        /// determines the smaller number.
        /// </summary>
        /// <param name="array">Random integer array of 0 and 1</param>
        /// <returns>Smallest count</returns>
        public int Solve(int[] array)
        {
            var countHeads = 0;
            // Loop through array of integers
            for (var i = 0; i < array.Length; i++)
            {
                // Compare with known heads value
                if (array[i] == 0)
                {
                    // Increment the count of heads
                    countHeads++;
                }
            }

            // Return the smaller of the count of heads or tails
            return Math.Min(countHeads, array.Length - countHeads);
        }
    }
}
