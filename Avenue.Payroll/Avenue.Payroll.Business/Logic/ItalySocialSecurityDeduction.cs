using Avenue.Payroll.Business.Interfaces;

namespace Avenue.Payroll.Business.Logic
{
    /// <summary>
    /// A universal social charge deduction for Ireland based on gross pay
    /// </summary>
    public class ItalySocialSecurityDeduction : IDeduction
    {
        private const string _name = "Social Security";

        /// <summary>
        /// Determines the deduction amount for the grossPay
        /// </summary>
        /// <param name="grossPay">Gross pay amount earned</param>
        /// <returns>Deduction result</returns>
        public Deduction CalculateDeduction(decimal grossPay)
        {
            var result = new Deduction { Name = _name };
            result.Amount = grossPay * 0.0919M;

            return result;
        }
    }
}
