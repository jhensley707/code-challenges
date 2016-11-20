using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Avenue.Payroll.Business.Interfaces;
using Avenue.Payroll.Business.Logic;
using Should;
using System.Collections.Generic;

namespace Avenue.Payroll.Test
{
    public class PayRollHandlerTests
    {
        public class PayRollHandlerTestBase
        {
            public const string IrelandLocationName = "Ireland";
            public const string ItalyLocationName = "Italy";
            public const decimal HoursWorked = 40M;
            public const decimal HourlyRate = 50M;
            public const decimal CalculatedGrossPay = 2000M;
            public const decimal CalculatedNetPay = 2000M;
            public Mock<INetPayCalculator> MockIrelandNetPayCalculator;
            public Mock<INetPayCalculator> MockItalyNetPayCalculator;
            public Dictionary<string, INetPayCalculator> NetPayCalculators;
            public IPayRollHandler Handler;
            public NetPayResponse IrelandResponse;
            public NetPayResponse ItalyResponse;

            public virtual void Initialize()
            {
                IrelandResponse = new NetPayResponse
                {
                    LocationName = IrelandLocationName,
                    GrossPay = CalculatedGrossPay,
                    NetPay = CalculatedNetPay
                };
                ItalyResponse = new NetPayResponse
                {
                    LocationName = ItalyLocationName,
                    GrossPay = CalculatedGrossPay,
                    NetPay = CalculatedNetPay
                };

                MockIrelandNetPayCalculator = new Mock<INetPayCalculator>(MockBehavior.Strict);
                MockIrelandNetPayCalculator.Setup(m => m.CalculateNetPay(It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
                    .Returns(IrelandResponse);
                MockItalyNetPayCalculator = new Mock<INetPayCalculator>(MockBehavior.Strict);
                MockItalyNetPayCalculator.Setup(m => m.CalculateNetPay(It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
                    .Returns(ItalyResponse);
                NetPayCalculators = new Dictionary<string, INetPayCalculator>();
                NetPayCalculators.Add("Ireland", MockIrelandNetPayCalculator.Object);
                NetPayCalculators.Add("Italy", MockItalyNetPayCalculator.Object);
            }
        }

        [TestClass]
        public class Constructor : PayRollHandlerTestBase
        {
            [TestInitialize]
            public override void Initialize()
            {
                base.Initialize();
            }

            [ExpectedException(typeof(ArgumentNullException))]
            [TestMethod]
            public void ShouldThrowExceptionWithNullNetPayCalculators()
            {
                Handler = new PayRollHandler(null);
            }

            [TestMethod]
            public void ShouldInstantiateWithAllRepositories()
            {
                Handler = new PayRollHandler(NetPayCalculators);

                Handler.ShouldNotBeNull();
            }
        }

        [TestClass]
        public class CalculateNetPayMethodWithIrelandLocationName : PayRollHandlerTestBase
        {
            [TestInitialize]
            public override void Initialize()
            {
                base.Initialize();
                Handler = new PayRollHandler(NetPayCalculators);
                Handler.CalculateNetPay(IrelandLocationName, HoursWorked, HourlyRate);
            }

            [TestMethod]
            public void ShouldCallCalculateNetPayExactlyOnce()
            {
                MockIrelandNetPayCalculator.Verify(m => m.CalculateNetPay(It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Exactly(1));
            }

            [TestMethod]
            public void ShouldCallIrelandNetPayCalculatorWithLocationNameIreland()
            {
                MockIrelandNetPayCalculator.Verify(m => m.CalculateNetPay(IrelandLocationName, It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Exactly(1));
            }

            [TestMethod]
            public void ShouldCallCalculateNetPayWithHoursWorked()
            {
                MockIrelandNetPayCalculator.Verify(m => m.CalculateNetPay(It.IsAny<string>(), HoursWorked, It.IsAny<decimal>()), Times.Exactly(1));
            }

            [TestMethod]
            public void ShouldCallCalculateNetPayWithHourlyRate()
            {
                MockIrelandNetPayCalculator.Verify(m => m.CalculateNetPay(It.IsAny<string>(), It.IsAny<decimal>(), HourlyRate), Times.Exactly(1));
            }
        }

        [TestClass]
        public class CalculateNetPayMethodWithItalyLocationName : PayRollHandlerTestBase
        {
            [TestInitialize]
            public override void Initialize()
            {
                base.Initialize();
                Handler = new PayRollHandler(NetPayCalculators);
                Handler.CalculateNetPay(ItalyLocationName, HoursWorked, HourlyRate);
            }

            [TestMethod]
            public void ShouldNeverCallIrelandNetPayCalculator()
            {
                MockIrelandNetPayCalculator.Verify(m => m.CalculateNetPay(It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Never);
            }

            [TestMethod]
            public void ShouldCallItalyPayRollHandlerExactlyOnce()
            {
                MockItalyNetPayCalculator.Verify(m => m.CalculateNetPay(It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Exactly(1));
            }

            [TestMethod]
            public void ShouldCallItalyPayRollHandlerWithLocationNameItaly()
            {
                MockItalyNetPayCalculator.Verify(m => m.CalculateNetPay(ItalyLocationName, It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Exactly(1));
            }

            [TestMethod]
            public void ShouldCallItalyPayRollHandlerWithHoursWorked()
            {
                MockItalyNetPayCalculator.Verify(m => m.CalculateNetPay(It.IsAny<string>(), HoursWorked, It.IsAny<decimal>()), Times.Exactly(1));
            }

            [TestMethod]
            public void ShouldCallItalyPayRollHandlerWithHourlyRate()
            {
                MockItalyNetPayCalculator.Verify(m => m.CalculateNetPay(It.IsAny<string>(), It.IsAny<decimal>(), HourlyRate), Times.Exactly(1));
            }
        }
    }
}
