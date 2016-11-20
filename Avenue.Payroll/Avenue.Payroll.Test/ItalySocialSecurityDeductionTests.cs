using Microsoft.VisualStudio.TestTools.UnitTesting;
using Avenue.Payroll.Business.Logic;
using Should;
using System.Collections.Generic;

namespace Avenue.Payroll.Test
{
    [TestClass]
    public class ItalySocialSecurityDeductionTests
    {
        const string expectedName = "Social Security";

        [TestMethod]
        public void DeductionNameShouldBeSocialSecurity()
        {
            const int grossPay = 900;
            var deductionRate1 = new DeductionRate { Rate = 0.0919M };

            var deductionCalculator = new DeductionCalculator(expectedName, new List<DeductionRate> { deductionRate1 });

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Name.ShouldEqual(expectedName);
        }

        [TestMethod]
        public void GivenSocialSecurityInItalyThenDeductionShouldBe9Point19Percent()
        {
            const int grossPay = 900;
            var deductionRate1 = new DeductionRate { Rate = 0.0919M };
            decimal expectedDeduction = (grossPay * 0.0919M);

            var deductionCalculator = new DeductionCalculator(expectedName, new List<DeductionRate> { deductionRate1 });

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }
    }
}
