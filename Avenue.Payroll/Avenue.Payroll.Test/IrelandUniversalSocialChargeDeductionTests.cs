using Microsoft.VisualStudio.TestTools.UnitTesting;
using Avenue.Payroll.Business.Logic;
using Should;
using System.Collections.Generic;

namespace Avenue.Payroll.Test
{
    [TestClass]
    public class IrelandUniversalSocialChargeDeductionTests
    {
        const string expectedName = "Universal Social Charge";
        private DeductionRate deductionRate1 = new DeductionRate(0.07M, 500M);
        private DeductionRate deductionRate2 = new DeductionRate(0.08M);

        [TestMethod]
        public void DeductionNameShouldBePension()
        {
            const int grossPay = 500;

            var deductionCalculator = new DeductionCalculator(expectedName, new List<DeductionRate> { deductionRate1, deductionRate2 });

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Name.ShouldEqual(expectedName);
        }

        [TestMethod]
        public void GivenSocialChargeInIrelandWhenGrossPayIs200DollarsThenDeductionShouldBe7Percent()
        {
            const int grossPay = 200;
            decimal expectedDeduction = (grossPay * 0.07M);

            var deductionCalculator = new DeductionCalculator(expectedName, new List<DeductionRate> { deductionRate1, deductionRate2 });

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }

        [TestMethod]
        public void GivenSocialChargeInIrelandWhenGrossPayIs800DollarsThenDeductionShouldBe8PercentOnAmountOver500()
        {
            const int grossPay = 800;
            decimal expectedDeduction = (500 * 0.07M) + ((grossPay - 500) * 0.08M);

            var deductionCalculator = new DeductionCalculator(expectedName, new List<DeductionRate> { deductionRate1, deductionRate2 });

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }
    }
}
