using Avenue.Payroll.Business.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace Avenue.Payroll.Test
{
    [TestClass]
    public class GrossPayCalculatorTests
    {
        [TestMethod]
        public void Given40HoursAnd10DollarsPerHourThenGrossPayShouldBe400Dollars()
        {
            const decimal hoursWorked = 40M;
            const decimal payRatePerHour = 10M;
            const decimal expectedGrossPay = 400M;

            var grossPayCalculator = new GrossPayCalculator();

            var grossPay = grossPayCalculator.CalculateGrossPay(hoursWorked, payRatePerHour);

            grossPay.ShouldEqual(expectedGrossPay);
        }
    }
}
