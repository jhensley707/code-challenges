using Avenue.Payroll.Business.Interfaces;

namespace Avenue.Payroll.Business.Logic
{
    /// <summary>
    /// A pension deduction for Germany based on gross pay
    /// </summary>
    public class GermanyPensionDeduction : IDeductionCalculator
    {
        private const string _name = "Pension";

        /// <summary>
        /// Determines the deduction amount for the grossPay
        /// </summary>
        /// <param name="grossPay">Gross pay amount earned</param>
        /// <returns>Deduction result</returns>
        public Deduction CalculateDeduction(decimal grossPay)
        {
            var result = new Deduction { Name = _name };
            result.Amount = grossPay * 0.02M;

            return result;
        }
    }
}
