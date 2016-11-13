using System;

namespace Avenue.Payroll.Console
{
    /// <summary>
    /// Console input helper class
    /// </summary>
    public static class ConsoleInput
    {
        // https://dotnetcodr.com/2013/05/23/design-patterns-and-practices-in-net-the-chain-of-responsibility-pattern/

        /// <summary>
        /// Displays prompt and reads console input, attempting conversion to decimal
        /// </summary>
        /// <param name="prompt">Message to display</param>
        /// <param name="value">Value read from console</param>
        /// <returns>True if converted to decimal</returns>
        public static bool TryReadDecimal(string prompt, out decimal value)
        {
            value = default(decimal);

            while (true)
            {
                System.Console.WriteLine(prompt);
                string input = System.Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    return false;
                }

                try
                {
                    value = Convert.ToDecimal(input);
                    return true;
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("The input is not a valid decimal.");
                }
                catch (OverflowException)
                {
                    System.Console.WriteLine("The input is not a valid decimal.");
                }
            }
        }
    }
}
