using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Avenue.Payroll.Business.Logic;
using Avenue.Payroll.Business.Interfaces;
using Moq;
using Should;

namespace Avenue.Payroll.Test
{
    public class NetPayCalculatorTests
    {
        public class NetPayCalculatorBase
        {
            public const string IrelandLocationName = "Ireland";
            public const string Deduction1Name = "First Deduction";
            public const string Deduction2Name = "Second Deduction";
            public const decimal HoursWorked = 40M;
            public const decimal HourlyRate = 50M;
            public const decimal CalculatedGrossPay = 2000M;
            public const decimal Deduction1Amount = 100M;
            public const decimal Deduction2Amount = 50M;
            public const decimal CalculatedNetPay = 1850M;

            public Mock<IGrossPayCalculator> MockGrossPayCalculator;
            public List<IDeduction> DeductionList;
            public Mock<IDeduction> MockDeduction1;
            public Mock<IDeduction> MockDeduction2;
            public NetPayCalculator Calculator;
            public NetPayResponse IrelandResponse;
            public Deduction Deduction1 = new Deduction { Name = Deduction1Name, Amount = Deduction1Amount };
            public Deduction Deduction2 = new Deduction { Name = Deduction2Name, Amount = Deduction2Amount };

            public virtual void Initialize()
            {
                MockGrossPayCalculator = new Mock<IGrossPayCalculator>(MockBehavior.Strict);
                MockGrossPayCalculator.Setup(m => m.CalculateGrossPay(It.IsAny<decimal>(), It.IsAny<decimal>()))
                    .Returns(CalculatedGrossPay);
                MockDeduction1 = new Mock<IDeduction>(MockBehavior.Strict);
                MockDeduction1.Setup(m => m.CalculateDeduction(It.IsAny<decimal>()))
                    .Returns(Deduction1);
                MockDeduction2 = new Mock<IDeduction>(MockBehavior.Strict);
                MockDeduction2.Setup(m => m.CalculateDeduction(It.IsAny<decimal>()))
                    .Returns(Deduction2);
                DeductionList = new List<IDeduction> { MockDeduction1.Object, MockDeduction2.Object };
            }
        }

        [TestClass]
        public class Constructor : NetPayCalculatorBase
        {
            [TestInitialize]
            public override void Initialize()
            {
                base.Initialize();
            }

            [ExpectedException(typeof(ArgumentNullException))]
            [TestMethod]
            public void ShouldThrowExceptionWithNullGrossPayCalculator()
            {
                Calculator = new NetPayCalculator(null, DeductionList);
            }

            [ExpectedException(typeof(ArgumentNullException))]
            [TestMethod]
            public void ShouldThrowExceptionWithNullDeductionList()
            {
                Calculator = new NetPayCalculator(MockGrossPayCalculator.Object, null);
            }

            [TestMethod]
            public void ShouldInstantiateWithAllRepositories()
            {
                Calculator = new NetPayCalculator(MockGrossPayCalculator.Object, DeductionList);

                Calculator.ShouldNotBeNull();
            }
        }

        [TestClass]
        public class CalculateNetPayMethod : NetPayCalculatorBase
        {
            [TestInitialize]
            public override void Initialize()
            {
                base.Initialize();
                Calculator = new NetPayCalculator(MockGrossPayCalculator.Object, DeductionList);
                IrelandResponse = Calculator.CalculateNetPay(IrelandLocationName, HoursWorked, HourlyRate);
            }

            [TestMethod]
            public void ShouldCallCalculateGrossPayExactlyOnce()
            {
                MockGrossPayCalculator.Verify(m => m.CalculateGrossPay(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Exactly(1));
            }

            [TestMethod]
            public void ShouldCallCalculateGrossPayWithHoursWorked()
            {
                MockGrossPayCalculator.Verify(m => m.CalculateGrossPay(HoursWorked, It.IsAny<decimal>()), Times.Exactly(1));
            }

            [TestMethod]
            public void ShouldCallCalculateGrossPayWithHourlyRate()
            {
                MockGrossPayCalculator.Verify(m => m.CalculateGrossPay(It.IsAny<decimal>(), HourlyRate), Times.Exactly(1));
            }

            [TestMethod]
            public void ShouldCallCalculateDeductionForFirstDeductionExactlyOnce()
            {
                MockDeduction1.Verify(m => m.CalculateDeduction(It.IsAny<decimal>()), Times.Exactly(1));
            }

            [TestMethod]
            public void ShouldCallCalculateDeductionForFirstDeductionWithGrossPay()
            {
                MockDeduction1.Verify(m => m.CalculateDeduction(CalculatedGrossPay), Times.Exactly(1));
            }

            [TestMethod]
            public void ShouldCallCalculateDeductionForSecondDeductionExactlyOnce()
            {
                MockDeduction2.Verify(m => m.CalculateDeduction(It.IsAny<decimal>()), Times.Exactly(1));
            }

            [TestMethod]
            public void ShouldCallCalculateDeductionForSecondDeductionWithGrossPay()
            {
                MockDeduction2.Verify(m => m.CalculateDeduction(CalculatedGrossPay), Times.Exactly(1));
            }

            [TestMethod]
            public void ShouldReturnLocationName()
            {
                IrelandResponse.LocationName.ShouldEqual(IrelandLocationName);
            }

            [TestMethod]
            public void ShouldReturnGrossPay()
            {
                IrelandResponse.GrossPay.ShouldEqual(CalculatedGrossPay);
            }

            [TestMethod]
            public void ShouldReturnNetPay()
            {
                IrelandResponse.NetPay.ShouldEqual(CalculatedNetPay);
            }
        }
    }
}
