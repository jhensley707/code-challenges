using Microsoft.VisualStudio.TestTools.UnitTesting;
using Avenue.Payroll.Business.Logic;
using Should;

namespace Avenue.Payroll.Test
{
    [TestClass]
    public class GermanyIncomeTaxDeductionTests
    {
        [TestMethod]
        public void DeductionNameShouldBeIncomeTax()
        {
            const int grossPay = 400;
            const string expectedName = "Income Tax";

            var deductionCalculator = new GermanyIncomeTaxDeduction();

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Name.ShouldEqual(expectedName);
        }

        [TestMethod]
        public void GivenIncomeTaxInGermanyWhenGrossPayIs400DollarsThenDeductionShouldBe25Percent()
        {
            const int grossPay = 400;
            decimal expectedDeduction = grossPay * 0.25M;

            var deductionCalculator = new GermanyIncomeTaxDeduction();

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }

        [TestMethod]
        public void GivenIncomeTaxInGermanyWhenGrossPayIs400DollarsThenDeductionShouldBe32PercentOnAmountOver400()
        {
            const int grossPay = 800;
            decimal expectedDeduction = (400 * 0.25M) + ((grossPay - 400) * 0.32M);

            var deductionCalculator = new GermanyIncomeTaxDeduction();

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }
    }
}
