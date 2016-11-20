using Microsoft.VisualStudio.TestTools.UnitTesting;
using Avenue.Payroll.Business.Logic;
using Should;
using System.Collections.Generic;

namespace Avenue.Payroll.Test
{
    [TestClass]
    public class IrelandIncomeTaxDeductionTests
    {
        const string expectedName = "Income Tax";

        [TestMethod]
        public void DeductionNameShouldBeIncomeTax()
        {
            const int grossPay = 600;
            var deductionRate1 = new DeductionRate { Limit = 600M, Rate = 0.25M };
            var deductionRate2 = new DeductionRate { Rate = 0.40M };

            var deductionCalculator = new DeductionCalculator(expectedName, new List<DeductionRate> { deductionRate1, deductionRate2 });

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Name.ShouldEqual(expectedName);
        }

        [TestMethod]
        public void GivenIncomeTaxInIrelandWhenGrossPayIs600DollarsThenDeductionShouldBe25Percent()
        {
            const int grossPay = 600;
            var deductionRate1 = new DeductionRate { Limit = 600M, Rate = 0.25M };
            var deductionRate2 = new DeductionRate { Rate = 0.40M };
            decimal expectedDeduction = grossPay * 0.25M;

            var deductionCalculator = new DeductionCalculator(expectedName, new List<DeductionRate> { deductionRate1, deductionRate2 });

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }

        [TestMethod]
        public void GivenIncomeTaxInIrelandWhenGrossPayIs800DollarsThenDeductionShouldBe40PercentOnAmountOver600()
        {
            const int grossPay = 800;
            var deductionRate1 = new DeductionRate { Limit = 600M, Rate = 0.25M };
            var deductionRate2 = new DeductionRate { Rate = 0.40M };
            decimal expectedDeduction = (600 * 0.25M) + ((grossPay - 600) * 0.40M);

            var deductionCalculator = new DeductionCalculator(expectedName, new List<DeductionRate> { deductionRate1, deductionRate2 });

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }
    }
}
