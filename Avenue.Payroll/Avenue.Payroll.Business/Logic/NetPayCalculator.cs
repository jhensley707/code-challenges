﻿using Avenue.Payroll.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenue.Payroll.Business.Logic
{
    /// <summary>
    /// Applies location-specific rules of calculation
    /// </summary>
    public class NetPayCalculator : INetPayCalculator
    {
        private IGrossPayCalculator _grossPayCalculator;
        private List<IDeduction> _deductions;

        /// <summary>
        /// Constructor validating and assigning repositories
        /// </summary>
        /// <param name="grossPayCalculator">Determines gross pay</param>
        /// <param name="deductions">Determines deduction amounts</param>
        public NetPayCalculator(IGrossPayCalculator grossPayCalculator, List<IDeduction> deductions)
        {
            if (grossPayCalculator == null)
            {
                throw new ArgumentNullException("grossPayCalculator");
            }

            if (deductions == null)
            {
                throw new ArgumentNullException("deductions");
            }

            _grossPayCalculator = grossPayCalculator;
            _deductions = deductions;
        }

        /// <summary>
        /// Calculates the net pay based on location-specific rules
        /// </summary>
        /// <param name="location">Location of employee</param>
        /// <param name="hoursWorked">Hours worked by employee</param>
        /// <param name="hourlyRate">Rate of pay for employee</param>
        /// <returns>Net pay calculation results</returns>
        public NetPayResponse CalculateNetPay(string locationName, decimal hoursWorked, decimal hourlyRate)
        {
            var netPayResponse = new NetPayResponse { LocationName = locationName } ;

            netPayResponse.GrossPay = _grossPayCalculator.CalculateGrossPay(hoursWorked, hourlyRate);
            netPayResponse.NetPay = netPayResponse.GrossPay;

            foreach(var deduction in _deductions)
            {
                deduction.CalculateDeduction(netPayResponse.GrossPay);
                netPayResponse.NetPay -= deduction.Amount;
            }

            netPayResponse.Deductions = _deductions;

            return netPayResponse;
        }
    }
}
