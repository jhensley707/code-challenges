using System;
using System.Collections.Generic;
using System.Linq;

namespace Avenue.Payroll.Business.Logic
{
    public class DeductionCalculator
    {
        private string _name;

        private List<DeductionRate> _deductionRates;

        /// <summary>
        /// Constructor validating and assigning repositories
        /// </summary>
        public DeductionCalculator(string name, List<DeductionRate> deductionRates)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name is required", "name");
            }

            if (deductionRates.Count(dr => !dr.Limit.HasValue) > 1)
            {
                throw new InvalidOperationException("No more than one unlimited rate is allowed");
            }

            _name = name;

            _deductionRates = deductionRates
                .Where(dr => dr.Limit.HasValue)
                .OrderBy(dr => dr.Limit.Value)
                .ToList();

            _deductionRates.AddRange(deductionRates.Where(dr => !dr.Limit.HasValue));
        }

        /// <summary>
        /// Calculates the deductions of the grossPay based on the specified
        /// DeductionRates
        /// </summary>
        /// <param name="grossPay"></param>
        /// <returns></returns>
        public Deduction CalculateDeduction(decimal grossPay)
        {
            return new Deduction { Name = _name, Amount = grossPay };
        }
    }
}
