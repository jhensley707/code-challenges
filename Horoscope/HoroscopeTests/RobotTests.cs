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
        private Mock<IChip> MockChip;
        private const int TotalSumChipOutput = 11;
        private object[] input = new object[] { 1, 2, 3, 5 };

        [TestInitialize]
        public void Setup()
        {
            MockChip = new Mock<IChip>(MockBehavior.Strict);
            MockChip.Setup(m => m.Execute(input, It.IsAny<bool>())).Returns(TotalSumChipOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorShouldValidateChip()
        {
            var robot = new Robot(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InstallChipShouldValidateChip()
        {
            var robot = new Robot(null);
        }

        [TestMethod]
        public void ExecuteInvokesChipWithInputExactlyOnce()
        {
            var robot = new Robot(MockChip.Object);

            var result = robot.Execute(input);

            MockChip.Verify(m => m.Execute(input, It.IsAny<bool>()), Times.Once());
        }

        [TestMethod]
        public void ExecuteReturnsChipOutput()
        {
            var robot = new Robot(MockChip.Object);

            var result = robot.Execute(input);

            Assert.AreEqual(TotalSumChipOutput, result);
        }

        [TestMethod]
        public void ReturnsUniqueChipCount()
        {
            var robot = new Robot(new TotalSumIntChip());
            robot.InstallChip(new SortIntChip());
            robot.InstallChip(new TotalSumIntChip());

            Assert.AreEqual(robot.TotalChipsInstalled, 2);
        }

        [TestMethod]
        public void TotalSumChipCalculatesResult()
        {
            var totalSumChip = new TotalSumIntChip();

            var result = totalSumChip.Execute(input);

            Assert.AreEqual(TotalSumChipOutput, result);
        }

        [TestMethod]
        public void SortChipReturnsDescendingList()
        {
            var sortIntChip = new SortIntChip();

            var result = sortIntChip.Execute(input, false);

            Assert.AreEqual(5, ((int[])result)[0]);
        }
    }
}
