using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Avenue.Payroll.Business.Logic;
using System.Collections.Generic;

namespace Avenue.Payroll.Test
{
    public class DeductionCalculatorTests
    {
        [TestClass]
        public class Constructor
        {
            [ExpectedException(typeof(ArgumentException))]
            [TestMethod]
            public void ThrowsExceptionWithNullName()
            {
                const string Name = null;
                var deductionRates = new List<DeductionRate>();

                var deductionCalculator = new DeductionCalculator(Name, deductionRates);
            }

            [ExpectedException(typeof(ArgumentException))]
            [TestMethod]
            public void ThrowsExceptionWithEmptyName()
            {
                var name = string.Empty;
                var deductionRates = new List<DeductionRate>();

                var deductionCalculator = new DeductionCalculator(name, deductionRates);
            }

            [ExpectedException(typeof(ArgumentException))]
            [TestMethod]
            public void ThrowsExceptionWithWhitespaceName()
            {
                const string Name = "  ";
                var deductionRates = new List<DeductionRate>();

                var deductionCalculator = new DeductionCalculator(Name, deductionRates);
            }

            [ExpectedException(typeof(InvalidOperationException))]
            [TestMethod]
            public void ThrowsExceptionWithTwoUnlimitedDeductionRates()
            {
                const string Name = "Income Tax";
                var deductionRates = new List<DeductionRate>
                {
                    new DeductionRate { Rate = 0.075M },
                    new DeductionRate { Rate = 0.1M }
                };

                var deductionCalculator = new DeductionCalculator(Name, deductionRates);
            }
        }

    }
}
