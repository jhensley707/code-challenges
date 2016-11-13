using Avenue.Payroll.Business.Interfaces;
using System;

namespace Avenue.Payroll.Business.Logic
{
    /// <summary>
    /// Singleton class to handle unrecognized locationName
    /// </summary>
    public class EndOfChainPayRollHandler : IPayRollHandler
    {
        private static EndOfChainPayRollHandler _instance = new EndOfChainPayRollHandler();

        /// <summary>
        /// Singleton instance of handler
        /// </summary>
        public static EndOfChainPayRollHandler Instance { get { return _instance; } }

        /// <summary>
        /// Returns error response for unrecognized location
        /// </summary>
        /// <param name="location">Location of employee</param>
        /// <param name="hoursWorked">Hours worked by employee</param>
        /// <param name="hourlyRate">Rate of pay for employee</param>
        /// <returns>Error message response</returns>
        public NetPayResponse CalculateNetPay(string locationName, decimal hoursWorked, decimal hourlyRate)
        {
            return new NetPayResponse { ErrorMessage = string.Format("Location {0} is not supported", locationName) };
        }

        /// <summary>
        /// Throws error when invoked. Must be last handler in chain.
        /// </summary>
        /// <param name="nextHandler"></param>
        public void RegisterNext(IPayRollHandler nextHandler)
        {
            throw new InvalidOperationException("EndOfChainPayRollHandler must be last");
        }
    }
}
