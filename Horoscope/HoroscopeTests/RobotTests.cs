using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotLibrary;
using System.Collections.Generic;

namespace RobotTests
{
    [TestClass]
    public class RobotTests
    {
        private Robot _robot;
        private Mock<IChip> _mockChip;
        private const int TotalSumChipOutput = 11;
        private object[] _input = new object[] { 1, 2, 3, 5 };

        [TestInitialize]
        public void Setup()
        {
            _robot = Robot.Instance;

            _mockChip = new Mock<IChip>(MockBehavior.Strict);
            _mockChip.Setup(m => m.Execute(_input, It.IsAny<bool>())).Returns(TotalSumChipOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InstallChipShouldValidateChip()
        {
            _robot.InstallChip(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExecuteThrowsExceptionWithNoChip()
        {
            _robot.Execute(_input);
        }

        /// <summary>
        /// Due to the Singleton nature of the Robot, this test
        /// can't be run with the TotalChipsInstalled property
        /// or it will be considered another unique chip
        /// </summary>
        [Ignore]
        [TestMethod]
        public void ExecuteInvokesChipWithInputExactlyOnce()
        {
            _robot.InstallChip(_mockChip.Object);

            var result = _robot.Execute(_input);

            _mockChip.Verify(m => m.Execute(_input, It.IsAny<bool>()), Times.Once());
        }

        /// <summary>
        /// Due to the Singleton nature of the Robot, this test
        /// can't be run with the TotalChipsInstalled property
        /// or it will be considered another unique chip
        /// </summary>
        [Ignore]
        [TestMethod]
        public void ExecuteReturnsChipOutput()
        {
            _robot.InstallChip(_mockChip.Object);

            var result = _robot.Execute(_input);

            Assert.AreEqual(TotalSumChipOutput, result);
        }

        [TestMethod]
        public void ReturnsUniqueChipCount()
        {
            _robot.InstallChip(new TotalSumIntChip());
            _robot.InstallChip(new SortIntChip());
            _robot.InstallChip(new TotalSumIntChip());

            Assert.AreEqual(2, _robot.TotalChipsInstalled);
        }

        [TestMethod]
        public void TotalSumChipCalculatesResult()
        {
            var totalSumChip = new TotalSumIntChip();

            var result = totalSumChip.Execute(_input);

            Assert.AreEqual(TotalSumChipOutput, result);
        }

        [TestMethod]
        public void SortChipReturnsDescendingList()
        {
            var sortIntChip = new SortIntChip();

            var result = sortIntChip.Execute(_input, false);

            Assert.AreEqual(5, ((int[])result)[0]);
        }
    }
}
