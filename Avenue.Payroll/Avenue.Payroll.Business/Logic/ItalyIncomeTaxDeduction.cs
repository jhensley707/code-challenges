using Avenue.Payroll.Business.Interfaces;

namespace Avenue.Payroll.Business.Logic
{
    /// <summary>
    /// An income tax deduction for Italy based on gross pay
    /// </summary>
    public class ItalyIncomeTaxDeduction : IDeductionCalculator
    {
        private const string _name = "Income Tax";

        /// <summary>
        /// Determines the deduction amount for the grossPay
        /// </summary>
        /// <param name="grossPay">Gross pay amount earned</param>
        /// <returns>Deduction result</returns>
        public Deduction CalculateDeduction(decimal grossPay)
        {
            var result = new Deduction { Name = _name };
            result.Amount = grossPay * 0.25M;

            return result;
        }
    }
}
