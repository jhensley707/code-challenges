using Microsoft.VisualStudio.TestTools.UnitTesting;
using Avenue.Payroll.Business.Logic;
using Should;
using System.Collections.Generic;

namespace Avenue.Payroll.Test
{
    [TestClass]
    public class GermanyIncomeTaxDeductionTests
    {
        const string expectedName = "Income Tax";

        [TestMethod]
        public void DeductionNameShouldBeIncomeTax()
        {
            const int grossPay = 400;
            var deductionRate1 = new DeductionRate { Limit = 400M, Rate = 0.25M };
            var deductionRate2 = new DeductionRate { Rate = 0.32M };

            var deductionCalculator = new DeductionCalculator(expectedName, new List<DeductionRate> { deductionRate1, deductionRate2 });

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Name.ShouldEqual(expectedName);
        }

        [TestMethod]
        public void GivenIncomeTaxInGermanyWhenGrossPayIs400DollarsThenDeductionShouldBe25Percent()
        {
            const int grossPay = 400;
            var deductionRate1 = new DeductionRate { Limit = 400M, Rate = 0.25M };
            var deductionRate2 = new DeductionRate { Rate = 0.32M };
            decimal expectedDeduction = grossPay * 0.25M;

            var deductionCalculator = new DeductionCalculator(expectedName, new List<DeductionRate> { deductionRate1, deductionRate2 });

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }

        [TestMethod]
        public void GivenIncomeTaxInGermanyWhenGrossPayIs400DollarsThenDeductionShouldBe32PercentOnAmountOver400()
        {
            const int grossPay = 800;
            var deductionRate1 = new DeductionRate { Limit = 400M, Rate = 0.25M };
            var deductionRate2 = new DeductionRate { Rate = 0.32M };
            decimal expectedDeduction = (400 * 0.25M) + ((grossPay - 400) * 0.32M);

            var deductionCalculator = new DeductionCalculator(expectedName, new List<DeductionRate> { deductionRate1, deductionRate2 });

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }
    }
}
