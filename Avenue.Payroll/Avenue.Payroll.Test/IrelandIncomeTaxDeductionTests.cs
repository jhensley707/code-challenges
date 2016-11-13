using Microsoft.VisualStudio.TestTools.UnitTesting;
using Avenue.Payroll.Business.Logic;
using Should;

namespace Avenue.Payroll.Test
{
    [TestClass]
    public class IrelandIncomeTaxDeductionTests
    {
        [TestMethod]
        public void DeductionNameShouldBeIncomeTax()
        {
            const int grossPay = 600;
            const string expectedName = "Income Tax";

            var deductionCalculator = new IrelandIncomeTaxDeduction();

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Name.ShouldEqual(expectedName);
        }

        [TestMethod]
        public void GivenIncomeTaxInIrelandWhenGrossPayIs600DollarsThenDeductionShouldBe25Percent()
        {
            const int grossPay = 600;
            decimal expectedDeduction = grossPay * 0.25M;

            var deductionCalculator = new IrelandIncomeTaxDeduction();

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }

        [TestMethod]
        public void GivenIncomeTaxInIrelandWhenGrossPayIs800DollarsThenDeductionShouldBe40PercentOnAmountOver600()
        {
            const int grossPay = 800;
            decimal expectedDeduction = (600 * 0.25M) + ((grossPay - 600) * 0.40M);

            var deductionCalculator = new IrelandIncomeTaxDeduction();

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }
    }
}
