using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretLibrary
{
    public class Secret
    {
        /// <summary>
        /// Reverses the halves of an input string. If input length is odd,
        /// keeps center character as pivot
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Swapped halves</returns>
        public string ReverseByCenter(string input)
        {
            var length = input.Length;
            var half = length / 2;
            // Determine if odd or even using modulus
            // Value is 0 if even, 1 if odd
            var mod = length % 2;

            // This initial attempt works but requires extra code
            /*
            if (mod > 0)
            {
                return string.Format("{0}{1}{2}", input.Substring(half + mod, half),
                    input.Substring(half, 1), input.Substring(0, half));
            }
            else
            {
                return string.Format("{0}{1}", input.Substring(half + mod, half),
                    input.Substring(0, half));
            }
            */

            // This attempt is more elegant since it uses the value of mod to
            // use only one return statement and no conditional logic.
            return string.Format("{0}{1}{2}", input.Substring(half + mod, half),
                input.Substring(half, mod), input.Substring(0, half));
        }
    }
}
