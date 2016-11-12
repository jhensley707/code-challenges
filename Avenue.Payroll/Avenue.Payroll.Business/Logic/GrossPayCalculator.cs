using Avenue.Payroll.Business.Interfaces;
using System;

namespace Avenue.Payroll.Business.Logic
{
    /// <summary>
    /// Logic to calculate gross pay
    /// </summary>
    public class GrossPayCalculator : IGrossPayCalculator
    {
        /// <summary>
        /// Calculates the gross pay for the hoursWorked and hourlyRate
        /// </summary>
        /// <param name="hoursWorked">Number of hours worked</param>
        /// <param name="hourlyRate">Pay rate</param>
        /// <returns>Gross pay</returns>
        public decimal CalculateGrossPay(decimal hoursWorked, decimal hourlyRate)
        {
            return hoursWorked * hourlyRate;
        }
    }
}
