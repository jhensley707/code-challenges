using Avenue.Payroll.Business.Interfaces;
using System;
using System.Collections.Generic;

namespace Avenue.Payroll.Business.Logic
{
    /// <summary>
    /// Handler to process payroll based on location
    /// </summary>
    public class PayRollHandler : IPayRollHandler
    {
        private Dictionary<string, INetPayCalculator> _netPayCalculators;

        /// <summary>
        /// Constructor validating and assigning repositories
        /// </summary>
        /// <param name="locationName">Location for calculation</param>
        /// <param name="netPayCalculator">Calculator of results</param>
        public PayRollHandler(Dictionary<string, INetPayCalculator> netPayCalculators)
        {
            if (netPayCalculators == null)
            {
                throw new ArgumentNullException("netPayCalculators");
            }

            _netPayCalculators = netPayCalculators;
        }

        /// <summary>
        /// Compares the locationName with NetPayCalculator and calculates the net pay
        /// for matching location or routes to next handler
        /// </summary>
        /// <param name="location">Location of employee</param>
        /// <param name="hoursWorked">Hours worked by employee</param>
        /// <param name="hourlyRate">Rate of pay for employee</param>
        /// <returns></returns>
        public NetPayResponse CalculateNetPay(string locationName, decimal hoursWorked, decimal hourlyRate)
        {
            if (_netPayCalculators.ContainsKey(locationName))
            {
                return _netPayCalculators[locationName].CalculateNetPay(locationName, hoursWorked, hourlyRate);
            }
            else
            {
                return new NetPayResponse { ErrorMessage = string.Format("Location {0} is not supported", locationName) };
            }
        }
    }
}
