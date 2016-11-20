using Microsoft.VisualStudio.TestTools.UnitTesting;
using Avenue.Payroll.Business.Logic;
using Should;
using System.Collections.Generic;

namespace Avenue.Payroll.Test
{
    [TestClass]
    public class IrelandPensionDeductionTests
    {
        const int grossPay = 900;
        const string expectedName = "Pension";
        private DeductionRate deductionRate1 = new DeductionRate(0.04M);

        [TestMethod]
        public void DeductionNameShouldBePension()
        {

            var deductionCalculator = new DeductionCalculator(expectedName, new List<DeductionRate> { deductionRate1 });

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Name.ShouldEqual(expectedName);
        }

        [TestMethod]
        public void GivenPensionInIrelandThenDeductionShouldBe4Percent()
        {
            decimal expectedDeduction = (grossPay * 0.04M);

            var deductionCalculator = new DeductionCalculator(expectedName, new List<DeductionRate> { deductionRate1 });

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }
    }
}
