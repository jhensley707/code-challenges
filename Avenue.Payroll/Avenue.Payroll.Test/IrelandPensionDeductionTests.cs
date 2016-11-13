using Microsoft.VisualStudio.TestTools.UnitTesting;
using Avenue.Payroll.Business.Logic;
using Should;

namespace Avenue.Payroll.Test
{
    [TestClass]
    public class IrelandPensionDeductionTests
    {
        [TestMethod]
        public void DeductionNameShouldBePension()
        {
            const int grossPay = 900;
            const string expectedName = "Pension";

            var deductionCalculator = new IrelandPensionDeduction();

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Name.ShouldEqual(expectedName);
        }

        [TestMethod]
        public void GivenPensionInIrelandThenDeductionShouldBe4Percent()
        {
            const int grossPay = 900;
            decimal expectedDeduction = (grossPay * 0.04M);

            var deductionCalculator = new IrelandPensionDeduction();

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }
    }
}
