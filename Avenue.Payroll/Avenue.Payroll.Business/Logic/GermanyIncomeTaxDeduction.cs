using Avenue.Payroll.Business.Interfaces;

namespace Avenue.Payroll.Business.Logic
{
    /// <summary>
    /// An income tax deduction for Germany based on gross pay
    /// </summary>
    public class GermanyIncomeTaxDeduction : IDeduction
    {
        /// <summary>
        /// The name of the deduction
        /// </summary>
        public string Name { get { return "Income Tax"; } }

        /// <summary>
        /// Amount of the deduction
        /// </summary>
        public decimal Amount { get; private set; }

        /// <summary>
        /// Determines the deduction amount for the grossPay
        /// </summary>
        /// <param name="grossPay">Gross pay amount earned</param>
        public void CalculateDeduction(decimal grossPay)
        {
            var grossPayBase = 400M;
            var grossPayBasePercentage = 0.25M;
            var grossPayExcessPercentage = 0.32M;
            if (grossPay > grossPayBase)
            {
                Amount = (grossPayBase * grossPayBasePercentage) + ((grossPay - grossPayBase) * grossPayExcessPercentage);
            }
            else
            {
                Amount = (grossPayBase * grossPayBasePercentage);
            }
        }
    }
}
