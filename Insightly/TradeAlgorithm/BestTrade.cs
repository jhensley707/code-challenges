using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class BestTrade
    {
        /// <summary>
        /// Given an array of integer amounts, returns the greatest
        /// difference between a minimum and a subsequent maximum value
        /// </summary>
        /// <param name="trades">Integer array of trade amounts</param>
        /// <returns>Maximum daily trade amount</returns>
        public int Calculate(int[] trades)
        {
            // Check array length
            if (trades.Length < 1)
            {
                return 0;
            }

            // Initialize variables
            var min = trades[0];
            var max = trades[0];
            var maxProfit = 0;

            for (var i = 1; i < trades.Length; i++)
            {
                if (min > trades[i])
                {
                    min = trades[i];
                    // A lower minimum value requires reset of any earlier max
                    max = trades[i];
                    maxProfit = CalculateCurrentProfit(min, max, maxProfit);
                    continue;
                }

                if (max < trades[i])
                {
                    max = trades[i];
                    maxProfit = CalculateCurrentProfit(min, max, maxProfit);
                 }
            }

            return maxProfit;
        }

        /// <summary>
        /// Given a min and a max value and the max profit value,
        /// determines the current profit and returns the greater
        /// of current profit or max profit
        /// </summary>
        /// <param name="min">Current minimum amount</param>
        /// <param name="max">Current maximum amount</param>
        /// <param name="maxProfit">Maximum profit amount</param>
        /// <returns></returns>
        public int CalculateCurrentProfit(int min, int max, int maxProfit)
        {
            var currentProfit = max - min;
            return Math.Max(currentProfit, maxProfit);
        }
    }
}
