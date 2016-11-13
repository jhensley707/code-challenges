using Microsoft.VisualStudio.TestTools.UnitTesting;
using Avenue.Payroll.Business.Logic;
using Should;

namespace Avenue.Payroll.Test
{
    [TestClass]
    public class ItalySocialSecurityDeductionTests
    {
        [TestMethod]
        public void DeductionNameShouldBeSocialSecurity()
        {
            const int grossPay = 900;
            const string expectedName = "Social Security";

            var deductionCalculator = new ItalySocialSecurityDeduction();

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Name.ShouldEqual(expectedName);
        }

        [TestMethod]
        public void GivenSocialSecurityInItalyThenDeductionShouldBe9Point19Percent()
        {
            const int grossPay = 900;
            decimal expectedDeduction = (grossPay * 0.0919M);

            var deductionCalculator = new ItalySocialSecurityDeduction();

            var deduction = deductionCalculator.CalculateDeduction(grossPay);

            deduction.Amount.ShouldEqual(expectedDeduction);
        }
    }
}
