using Avenue.Payroll.Business.Logic;

namespace Avenue.Payroll.Business.Interfaces
{
    /// <summary>
    /// A deduction based on gross pay
    /// </summary>
    public interface IDeductionCalculator
    {
        /// <summary>
        /// Determines the deduction amount for the grossPay
        /// </summary>
        /// <param name="grossPay">Gross pay amount earned</param>
        /// <returns>Deduction result</returns>
        Deduction CalculateDeduction(decimal grossPay);
    }
}
