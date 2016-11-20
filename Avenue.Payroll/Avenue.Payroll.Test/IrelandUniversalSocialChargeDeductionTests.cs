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

        [TestMethod]
        public void DeductionNameShouldBePension()
        {
            const int grossPay = 500;
            var deductionRate1 = new DeductionRate { Limit = 500, Rate = 0.07M };
            var deductionRate2 = new DeductionRate { Rate = 0.08M };

            var deductionCalculator = new DeductionCalculator(expectedName, new List<DeductionRate> { deductionRate1, deductionRate2 });

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Name.ShouldEqual(expectedName);
        }

        [TestMethod]
        public void GivenSocialChargeInIrelandWhenGrossPayIs500DollarsThenDeductionShouldBe7Percent()
        {
            const int grossPay = 500;
            var deductionRate1 = new DeductionRate { Limit = 500, Rate = 0.07M };
            var deductionRate2 = new DeductionRate { Rate = 0.08M };
            decimal expectedDeduction = (grossPay * 0.07M);

            var deductionCalculator = new DeductionCalculator(expectedName, new List<DeductionRate> { deductionRate1, deductionRate2 });

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }

        [TestMethod]
        public void GivenSocialChargeInIrelandWhenGrossPayIs800DollarsThenDeductionShouldBe8PercentOnAmountOver500()
        {
            const int grossPay = 500;
            var deductionRate1 = new DeductionRate { Limit = 500M, Rate = 0.07M };
            var deductionRate2 = new DeductionRate { Rate = 0.08M };
            decimal expectedDeduction = (500 * 0.07M) + ((grossPay - 500) * 0.08M);

            var deductionCalculator = new DeductionCalculator(expectedName, new List<DeductionRate> { deductionRate1, deductionRate2 });

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }
    }
}
