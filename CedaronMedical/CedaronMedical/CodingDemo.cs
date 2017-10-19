using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedaronMedical
{
    /// <summary>
    /// Given an random array of integers, find the first whole number
    /// greater than zero which is not included in the list
    /// </summary>
    public class CodingDemo
    {
        /// <summary>
        /// Sorts the list then evaluates each integer looking for
        /// a gap in the numbers
        /// </summary>
        /// <param name="array">Random integer array</param>
        /// <returns>Max value not in list</returns>
        public int Solve(int[] array)
        {
            var max = 0;
            // Sort the integers into a list
            var sorted = array.Select(a => a).OrderBy(a => a).ToList();

            // Loop through the list, comparing the number with the current max value
            for (var i = 0; i < array.Length; i++)
            {
                // Compare the current integer with the max value
                // If greater, we have a candidate for new max value
                if (sorted[i] > max)
                {
                    // Compare if current integer is greater than max + 1
                    if (max + 1 < sorted[i])
                    {
                        // Found a gap in sequence
                        break;
                    }

                    // Update max value to current integer and move to next
                    max = sorted[i];
                }
            }

            // Increment current max value by 1 and return
            return ++max;
        }
    }
}
