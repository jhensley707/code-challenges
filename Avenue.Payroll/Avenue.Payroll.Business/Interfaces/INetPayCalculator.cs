using Avenue.Payroll.Business.Logic;

namespace Avenue.Payroll.Business.Interfaces
{
    /// <summary>
    /// Applies location-specific rules of calculation
    /// </summary>
    public interface INetPayCalculator
    {
        /// <summary>
        /// Calculates the net pay based on location-specific rules
        /// </summary>
        /// <param name="location">Location of employee</param>
        /// <param name="hoursWorked">Hours worked by employee</param>
        /// <param name="hourlyRate">Rate of pay for employee</param>
        /// <returns>Net pay calculation results</returns>
        NetPayResponse CalculateNetPay(string location, decimal hoursWorked, decimal hourlyRate);
    }
}
