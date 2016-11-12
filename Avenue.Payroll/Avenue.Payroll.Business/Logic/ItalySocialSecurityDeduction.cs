using Avenue.Payroll.Business.Interfaces;

namespace Avenue.Payroll.Business.Logic
{
    /// <summary>
    /// A universal social charge deduction for Ireland based on gross pay
    /// </summary>
    public class ItalySocialSecurityDeduction : IDeduction
    {
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
        }
    }
}
