using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Avenue.Payroll.Business.Logic;
using Should;

namespace Avenue.Payroll.Test
{
    public class UnitTest1
    {
        [TestClass]
        public class CalculateGrossPayMethod
        {
            [TestMethod]
            public void Given40HoursAnd10DollarsPerHourThenGrossPayShouldBe400Dollars()
            {
                const int hoursWorked = 40;
                const int payRatePerHour = 10;
                const int expectedGrossPay = 400;

                Assert.Fail("Not implemented yet");
            }
        }

        [TestClass]
        public class CalculateDeductionMethod
        {
            [TestMethod]
            public void GivenIncomeTaxInIrelandWhenGrossPayIs600DollarsThenDeductionShouldBe25Percent()
            {
                const int grossPay = 600;
                decimal expectedDeduction = grossPay * 0.25M;

                var deduction = new IrelandIncomeTaxDeduction();

                deduction.CalculateDeduction(grossPay);

                deduction.Amount.ShouldEqual(expectedDeduction);
            }

            [TestMethod]
            public void GivenIncomeTaxInIrelandWhenGrossPayIs800DollarsThenDeductionShouldBe40PercentOnAmountOver600()
            {
                const int grossPay = 800;
                decimal expectedDeduction = (600 * 0.25M) + ((grossPay - 600) * 0.40M);

                var deduction = new IrelandIncomeTaxDeduction();

                deduction.CalculateDeduction(grossPay);

                deduction.Amount.ShouldEqual(expectedDeduction);
            }

            [TestMethod]
            public void GivenSocialChargeInIrelandWhenGrossPayIs500DollarsThenDeductionShouldBe7Percent()
            {
                const int grossPay = 500;
                decimal expectedDeduction = (grossPay * 0.07M);

                var deduction = new IrelandUniversalSocialChargeDeduction();

                deduction.CalculateDeduction(grossPay);

                deduction.Amount.ShouldEqual(expectedDeduction);
            }

            [TestMethod]
            public void GivenSocialChargeInIrelandWhenGrossPayIs800DollarsThenDeductionShouldBe8PercentOnAmountOver500()
            {
                const int grossPay = 500;
                decimal expectedDeduction = (500 * 0.07M) + ((grossPay - 500) * 0.08M);

                var deduction = new IrelandUniversalSocialChargeDeduction();

                deduction.CalculateDeduction(grossPay);

                deduction.Amount.ShouldEqual(expectedDeduction);
            }

            [TestMethod]
            public void GivenPensionInIrelandThenDeductionShouldBe4Percent()
            {
                const int grossPay = 900;
                decimal expectedDeduction = (grossPay * 0.04M);

                var deduction = new IrelandPensionDeduction();

                deduction.CalculateDeduction(grossPay);

                deduction.Amount.ShouldEqual(expectedDeduction);
            }

            [TestMethod]
            public void GivenIncomeTaxInItalyWhenGrossPayIs600DollarsThenDeductionShouldBe25Percent()
            {
                const int grossPay = 600;
                decimal expectedDeduction = grossPay * 0.25M;

                var deduction = new ItalyIncomeTaxDeduction();

                deduction.CalculateDeduction(grossPay);

                deduction.Amount.ShouldEqual(expectedDeduction);
            }

            [TestMethod]
            public void GivenSocialSecurityInItalyThenDeductionShouldBe9Point19Percent()
            {
                const int grossPay = 900;
                decimal expectedDeduction = (grossPay * 0.0919M);

                var deduction = new ItalySocialSecurityDeduction();

                deduction.CalculateDeduction(grossPay);

                deduction.Amount.ShouldEqual(expectedDeduction);
            }
            [TestMethod]
            public void GivenIncomeTaxInGermanyWhenGrossPayIs400DollarsThenDeductionShouldBe25Percent()
            {
                const int grossPay = 400;
                decimal expectedDeduction = grossPay * 0.25M;

                var deduction = new GermanyIncomeTaxDeduction();

                deduction.CalculateDeduction(grossPay);

                deduction.Amount.ShouldEqual(expectedDeduction);
            }

            [TestMethod]
            public void GivenIncomeTaxInGermanyWhenGrossPayIs400DollarsThenDeductionShouldBe32PercentOnAmountOver400()
            {
                const int grossPay = 800;
                decimal expectedDeduction = (400 * 0.25M) + ((grossPay - 400) * 0.32M);

                var deduction = new GermanyIncomeTaxDeduction();

                deduction.CalculateDeduction(grossPay);

                deduction.Amount.ShouldEqual(expectedDeduction);
            }

            [TestMethod]
            public void GivenPensionInGermanyThenDeductionShouldBe2Percent()
            {
                const int grossPay = 900;
                decimal expectedDeduction = (grossPay * 0.02M);

                var deduction = new GermanyPensionDeduction();

                deduction.CalculateDeduction(grossPay);

                deduction.Amount.ShouldEqual(expectedDeduction);
            }
        }
    }
}
