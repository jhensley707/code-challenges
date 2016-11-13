using Microsoft.VisualStudio.TestTools.UnitTesting;
using Avenue.Payroll.Business.Logic;
using Should;

namespace Avenue.Payroll.Test
{
    [TestClass]
    public class GermanyPensionDeductionTest
    {
        [TestMethod]
        public void DeductionNameShouldBePension()
        {
            const int grossPay = 900;
            const string expectedName = "Pension";

            var deductionCalculator = new GermanyPensionDeduction();

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Name.ShouldEqual(expectedName);
        }

        [TestMethod]
        public void GivenPensionInGermanyThenDeductionShouldBe2Percent()
        {
            const int grossPay = 900;
            decimal expectedDeduction = (grossPay * 0.02M);

            var deductionCalculator = new GermanyPensionDeduction();

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }
    }
}
