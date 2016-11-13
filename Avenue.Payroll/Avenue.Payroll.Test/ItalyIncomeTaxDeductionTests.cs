using Microsoft.VisualStudio.TestTools.UnitTesting;
using Avenue.Payroll.Business.Logic;
using Should;

namespace Avenue.Payroll.Test
{
    [TestClass]
    public class ItalyIncomeTaxDeductionTests
    {
        [TestMethod]
        public void DeductionNameShouldBeIncomeTax()
        {
            const int grossPay = 600;
            const string expectedName = "Income Tax";

            var deductionCalculator = new ItalyIncomeTaxDeduction();

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Name.ShouldEqual(expectedName);
        }

        [TestMethod]
        public void GivenIncomeTaxInItalyWhenGrossPayIs600DollarsThenDeductionShouldBe25Percent()
        {
            const int grossPay = 600;
            decimal expectedDeduction = grossPay * 0.25M;

            var deductionCalculator = new ItalyIncomeTaxDeduction();

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }
    }
}
