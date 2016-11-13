using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Avenue.Payroll.Business.Interfaces;
using Avenue.Payroll.Business.Logic;
using Should;

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
            public Mock<IPayRollHandler> MockItalyPayRollHandler;
            public IPayRollHandler IrelandHandler;
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
                MockItalyPayRollHandler = new Mock<IPayRollHandler>(MockBehavior.Strict);
                MockIrelandNetPayCalculator.Setup(m => m.CalculateNetPay(It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
                    .Returns(IrelandResponse);
                MockItalyPayRollHandler.Setup(m => m.CalculateNetPay(It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
                    .Returns(ItalyResponse);
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

            [ExpectedException(typeof(ArgumentException))]
            [TestMethod]
            public void ShouldThrowExceptionWithEmptyLocationName()
            {
                IrelandHandler = new PayRollHandler(string.Empty, MockIrelandNetPayCalculator.Object);
            }

            [ExpectedException(typeof(ArgumentNullException))]
            [TestMethod]
            public void ShouldThrowExceptionWithNullNetPayCalculator()
            {
                IrelandHandler = new PayRollHandler(IrelandLocationName, null);
            }

            [TestMethod]
            public void ShouldInstantiateWithAllRepositories()
            {
                IrelandHandler = new PayRollHandler(IrelandLocationName, MockIrelandNetPayCalculator.Object);

                IrelandHandler.ShouldNotBeNull();
            }
        }

        [TestClass]
        public class RegisterNextMethod : PayRollHandlerTestBase
        {
            [TestInitialize]
            public override void Initialize()
            {
                base.Initialize();
                IrelandHandler = new PayRollHandler(IrelandLocationName, MockIrelandNetPayCalculator.Object);
            }

            [ExpectedException(typeof(ArgumentNullException))]
            [TestMethod]
            public void ShouldThrowExceptionWithNullPayRollHandler()
            {
                IrelandHandler.RegisterNext(null);
            }
        }

        [TestClass]
        public class CalculateNetPayMethodWithIrelandLocationName : PayRollHandlerTestBase
        {
            [TestInitialize]
            public override void Initialize()
            {
                base.Initialize();
                IrelandHandler = new PayRollHandler(IrelandLocationName, MockIrelandNetPayCalculator.Object);
                IrelandHandler.RegisterNext(MockItalyPayRollHandler.Object);
                IrelandHandler.CalculateNetPay(IrelandLocationName, HoursWorked, HourlyRate);
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
                IrelandHandler = new PayRollHandler(IrelandLocationName, MockIrelandNetPayCalculator.Object);
                IrelandHandler.RegisterNext(MockItalyPayRollHandler.Object);
                IrelandHandler.CalculateNetPay(ItalyLocationName, HoursWorked, HourlyRate);
            }

            [TestMethod]
            public void ShouldNeverCallIrelandNetPayCalculator()
            {
                MockIrelandNetPayCalculator.Verify(m => m.CalculateNetPay(It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Never);
            }

            [TestMethod]
            public void ShouldCallItalyPayRollHandlerExactlyOnce()
            {
                MockItalyPayRollHandler.Verify(m => m.CalculateNetPay(It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Exactly(1));
            }

            [TestMethod]
            public void ShouldCallItalyPayRollHandlerWithLocationNameItaly()
            {
                MockItalyPayRollHandler.Verify(m => m.CalculateNetPay(ItalyLocationName, It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Exactly(1));
            }

            [TestMethod]
            public void ShouldCallItalyPayRollHandlerWithHoursWorked()
            {
                MockItalyPayRollHandler.Verify(m => m.CalculateNetPay(It.IsAny<string>(), HoursWorked, It.IsAny<decimal>()), Times.Exactly(1));
            }

            [TestMethod]
            public void ShouldCallItalyPayRollHandlerWithHourlyRate()
            {
                MockItalyPayRollHandler.Verify(m => m.CalculateNetPay(It.IsAny<string>(), It.IsAny<decimal>(), HourlyRate), Times.Exactly(1));
            }
        }
    }
}
