using Microsoft.VisualStudio.TestTools.UnitTesting;
using Avenue.Payroll.Business.Logic;
using Should;
using System.Collections.Generic;

namespace Avenue.Payroll.Test
{
    [TestClass]
    public class ItalyIncomeTaxDeductionTests
    {
        const string expectedName = "Income Tax";
        private DeductionRate deductionRate1 = new DeductionRate(0.25M);

        [TestMethod]
        public void DeductionNameShouldBeIncomeTax()
        {
            const int grossPay = 600;

            var deductionCalculator = new DeductionCalculator(expectedName, new List<DeductionRate> { deductionRate1 });

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Name.ShouldEqual(expectedName);
        }

        [TestMethod]
        public void GivenIncomeTaxInItalyWhenGrossPayIs600DollarsThenDeductionShouldBe25Percent()
        {
            const int grossPay = 600;
            decimal expectedDeduction = grossPay * 0.25M;

            var deductionCalculator = new DeductionCalculator(expectedName, new List<DeductionRate> { deductionRate1 });

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }
    }
}
