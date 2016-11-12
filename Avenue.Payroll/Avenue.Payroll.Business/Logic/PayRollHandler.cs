using Avenue.Payroll.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Payroll.Business.Logic
{
    /// <summary>
    /// Handler to process payroll based on location
    /// </summary>
    public class PayRollHandler
    {
        private string _locationName;
        private INetPayCalculator _netPayCalculator;
        private IPayRollHandler _next;

        /// <summary>
        /// Constructor validating and assigning repositories
        /// </summary>
        /// <param name="locationName">Location for calculation</param>
        /// <param name="netPayCalculator">Calculator of results</param>
        public PayRollHandler(string locationName, INetPayCalculator netPayCalculator)
        {
            if (string.IsNullOrWhiteSpace(locationName))
            {
                throw new ArgumentException("Invalid location name", "locationName");
            }

            if (netPayCalculator == null)
            {
                throw new ArgumentNullException("netPayCalculator");
            }

            _locationName = locationName;
            _netPayCalculator = netPayCalculator;
            _next = new EndOfChainPayRollHandler();
        }

        /// <summary>
        /// Assigns next location-specific payroll handler
        /// </summary>
        /// <param name="nextHandler"></param>
        public void RegisterNext(IPayRollHandler nextHandler)
        {
            if (nextHandler == null)
            {
                throw new ArgumentNullException("nextHandler");
            }

            _next = nextHandler;
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
            if (_locationName.Equals(locationName, StringComparison.CurrentCultureIgnoreCase))
            {
                return _netPayCalculator.CalculateNetPay(_locationName, hoursWorked, hourlyRate);
            }
            else
            {
                return _next.CalculateNetPay(locationName, hoursWorked, hourlyRate);
            }
        }
    }
}
