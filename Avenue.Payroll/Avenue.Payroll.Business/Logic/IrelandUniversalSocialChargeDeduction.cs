using Avenue.Payroll.Business.Interfaces;

namespace Avenue.Payroll.Business.Logic
{
    /// <summary>
    /// A universal social charge deduction for Ireland based on gross pay
    /// </summary>
    public class IrelandUniversalSocialChargeDeduction : IDeduction
    {
        private const string _name = "Universal Social Charge";

        /// <summary>
        /// Determines the deduction amount for the grossPay
        /// </summary>
        /// <param name="grossPay">Gross pay amount earned</param>
        /// <returns>Deduction result</returns>
        public Deduction CalculateDeduction(decimal grossPay)
        {
            var grossPayBase = 500M;
            var grossPayBasePercentage = 0.07M;
            var grossPayExcessPercentage = 0.08M;

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
