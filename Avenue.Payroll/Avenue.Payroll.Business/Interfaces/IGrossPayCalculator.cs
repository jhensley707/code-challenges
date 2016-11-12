namespace Avenue.Payroll.Business.Interfaces
{
    /// <summary>
    /// Logic to calculate the gross pay
    /// </summary>
    public interface IGrossPayCalculator
    {
        /// <summary>
        /// Calculates the gross pay for the hoursWorked and hourlyRate
        /// </summary>
        /// <param name="hoursWorked">Number of hours worked</param>
        /// <param name="hourlyRate">Pay rate</param>
        /// <returns>Gross pay</returns>
        decimal CalculateGrossPay(decimal hoursWorked, decimal hourlyRate);
    }
}
