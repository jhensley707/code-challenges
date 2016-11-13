using Avenue.Payroll.Business.Interfaces;

namespace Avenue.Payroll.Business.Logic
{
    /// <summary>
    /// A pension deduction for Ireland based on gross pay
    /// </summary>
    public class IrelandPensionDeduction : IDeduction
    {
        /// <summary>
        /// The name of the deduction
        /// </summary>
        public string Name { get { return "Pension"; } }

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
            Amount = grossPay * 0.04M;
        }
    }
}
