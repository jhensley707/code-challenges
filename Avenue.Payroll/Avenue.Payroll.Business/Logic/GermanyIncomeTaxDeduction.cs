using Avenue.Payroll.Business.Interfaces;

namespace Avenue.Payroll.Business.Logic
{
    /// <summary>
    /// An income tax deduction for Germany based on gross pay
    /// </summary>
    public class GermanyIncomeTaxDeduction : IDeductionCalculator
    {
        private const string _name = "Income Tax";

        /// <summary>
        /// Determines the deduction amount for the grossPay
        /// </summary>
        /// <param name="grossPay">Gross pay amount earned</param>
        /// <returns>Deduction result</returns>
        public Deduction CalculateDeduction(decimal grossPay)
        {
            var grossPayBase = 400M;
            var grossPayBasePercentage = 0.25M;
            var grossPayExcessPercentage = 0.32M;

            var result = new Deduction { Name = _name };
            if (grossPay > grossPayBase)
            {
                result.Amount = (grossPayBase * grossPayBasePercentage) + ((grossPay - grossPayBase) * grossPayExcessPercentage);
            }
            else
            {
                result.Amount = (grossPayBase * grossPayBasePercentage);
            }

            return result;
        }
    }
}
