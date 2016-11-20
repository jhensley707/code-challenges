using Microsoft.VisualStudio.TestTools.UnitTesting;
using Avenue.Payroll.Business.Logic;
using Should;
using System.Collections.Generic;

namespace Avenue.Payroll.Test
{
    [TestClass]
    public class IrelandIncomeTaxDeductionTests
    {
        const string expectedName = "Income Tax";
        private DeductionRate deductionRate1 = new DeductionRate(0.25M, 600M);
        private DeductionRate deductionRate2 = new DeductionRate(0.40M);

        [TestMethod]
        public void DeductionNameShouldBeIncomeTax()
        {
            const int grossPay = 600;

            var deductionCalculator = new DeductionCalculator(expectedName, new List<DeductionRate> { deductionRate1, deductionRate2 });

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Name.ShouldEqual(expectedName);
        }

        [TestMethod]
        public void GivenIncomeTaxInIrelandWhenGrossPayIs400DollarsThenDeductionShouldBe25Percent()
        {
            const int grossPay = 400;
            decimal expectedDeduction = grossPay * 0.25M;

            var deductionCalculator = new DeductionCalculator(expectedName, new List<DeductionRate> { deductionRate1, deductionRate2 });

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }

        [TestMethod]
        public void GivenIncomeTaxInIrelandWhenGrossPayIs800DollarsThenDeductionShouldBe40PercentOnAmountOver600()
        {
            const int grossPay = 800;
            decimal expectedDeduction = (600 * 0.25M) + ((grossPay - 600) * 0.40M);

            var deductionCalculator = new DeductionCalculator(expectedName, new List<DeductionRate> { deductionRate1, deductionRate2 });

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }
    }
}
