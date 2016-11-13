using Microsoft.VisualStudio.TestTools.UnitTesting;
using Avenue.Payroll.Business.Logic;
using Should;

namespace Avenue.Payroll.Test
{
    [TestClass]
    public class IrelandUniversalSocialChargeDeductionTests
    {
        [TestMethod]
        public void DeductionNameShouldBePension()
        {
            const int grossPay = 500;
            const string expectedName = "Universal Social Charge";

            var deductionCalculator = new IrelandUniversalSocialChargeDeduction();

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Name.ShouldEqual(expectedName);
        }

        [TestMethod]
        public void GivenSocialChargeInIrelandWhenGrossPayIs500DollarsThenDeductionShouldBe7Percent()
        {
            const int grossPay = 500;
            decimal expectedDeduction = (grossPay * 0.07M);

            var deductionCalculation = new IrelandUniversalSocialChargeDeduction();

            var deduction = deductionCalculation.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }

        [TestMethod]
        public void GivenSocialChargeInIrelandWhenGrossPayIs800DollarsThenDeductionShouldBe8PercentOnAmountOver500()
        {
            const int grossPay = 500;
            decimal expectedDeduction = (500 * 0.07M) + ((grossPay - 500) * 0.08M);

            var deductionCalculation = new IrelandUniversalSocialChargeDeduction();

            var deduction = deductionCalculation.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }
    }
}
