using Avenue.Payroll.Business.Logic;

namespace Avenue.Payroll.Business.Interfaces
{
    /// <summary>
    /// Handler to process payroll based on location
    /// </summary>
    public interface IPayRollHandler
    {
        /// <summary>
        /// Calculates the net pay based on location-specific rules
        /// </summary>
        /// <param name="location">Location of employee</param>
        /// <param name="hoursWorked">Hours worked by employee</param>
        /// <param name="hourlyRate">Rate of pay for employee</param>
        /// <returns>Net pay calculation results</returns>
        NetPayResponse CalculateNetPay(string locationName, decimal hoursWorked, decimal hourlyRate);

        /// <summary>
        /// Assigns next location-specific payroll handler
        /// </summary>
        /// <param name="nextHandler"></param>
        void RegisterNext(IPayRollHandler nextHandler);
    }
}
