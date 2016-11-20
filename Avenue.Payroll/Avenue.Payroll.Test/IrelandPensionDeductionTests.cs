using Microsoft.VisualStudio.TestTools.UnitTesting;
using Avenue.Payroll.Business.Logic;
using Should;
using System.Collections.Generic;

namespace Avenue.Payroll.Test
{
    [TestClass]
    public class IrelandPensionDeductionTests
    {
        const string expectedName = "Pension";

        [TestMethod]
        public void DeductionNameShouldBePension()
        {
            const int grossPay = 900;
            var deductionRate1 = new DeductionRate { Rate = 0.04M };

            var deductionCalculator = new DeductionCalculator(expectedName, new List<DeductionRate> { deductionRate1 });

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Name.ShouldEqual(expectedName);
        }

        [TestMethod]
        public void GivenPensionInIrelandThenDeductionShouldBe4Percent()
        {
            const int grossPay = 900;
            var deductionRate1 = new DeductionRate { Rate = 0.04M };
            decimal expectedDeduction = (grossPay * 0.04M);

            var deductionCalculator = new DeductionCalculator(expectedName, new List<DeductionRate> { deductionRate1 });

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }
    }
}
