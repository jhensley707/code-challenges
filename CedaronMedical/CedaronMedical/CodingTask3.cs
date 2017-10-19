using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedaronMedical
{
    /// <summary>
    /// Given two integers, create a new integer by taking alternating digits
    /// from each integer. Thus, 12345 and 67890 becomes 1627384950.
    /// <para>If one of the integers runs out of digits, the remaining digits
    /// of the other integer are appended to the new integer.</para>
    /// <para>If the integer exceeds 100,000,000, return -1</para>
    /// </summary>
    public class CodingTask3
    {
        /// <summary>
        /// Converts two integers to character arrays, loops through longest
        /// array, combining values from each into new array.
        /// </summary>
        /// <param name="integer1">First input integer</param>
        /// <param name="integer2">Second input integer</param>
        /// <returns>New integer value or -1</returns>
        public int Solve(int integer1, int integer2)
        {
            // Convert to arrays
            var array1 = integer1.ToString().ToCharArray();
            var array2 = integer2.ToString().ToCharArray();
            // Determine total length of new integer
            var finalLength = array1.Length + array2.Length;
            // Initialize new array
            var array3 = new Char[finalLength];
            var index = 0;
            // Determine longest array
            var longest = Math.Max(array1.Length, array2.Length);
            // Loop through longest array
            for (var i = 0; i < longest; i ++)
            {
                // Compare current index with length of first array
                if (i < array1.Length)
                {
                    // Array length not exceeded so add current character to new array
                    array3[index++] = array1[i];
                }

                // Compare current index with length of second array
                if (i < array2.Length)
                {
                    // Array length not exceeded so add current character to new array
                    array3[index++] = array2[i];
                }
            }

            // Cast resulting array to a long
            long result = long.Parse(new string(array3));
            // Compare with max size
            if (result > 100000000)
            {
                // Max size exceeded so return -1
                return -1;
            }

            // Return value as an integer
            return (int)result;
        }
    }
}
