﻿using Avenue.Payroll.Business.Interfaces;

namespace Avenue.Payroll.Business.Logic
{
    /// <summary>
    /// A universal social charge deduction for Ireland based on gross pay
    /// </summary>
    public class IrelandUniversalSocialChargeDeduction : IDeduction
    {
        /// <summary>
        /// The name of the deduction
        /// </summary>
        public string Name { get { return "Universal Social Charge"; } }

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
            var grossPayBase = 500M;
            var grossPayBasePercentage = 0.07M;
            var grossPayExcessPercentage = 0.08M;
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
