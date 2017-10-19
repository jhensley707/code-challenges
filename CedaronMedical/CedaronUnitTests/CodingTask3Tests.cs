using System;
using CedaronMedical;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CedaronUnitTests
{
    [TestClass]
    public class CodingTask3Tests
    {
        CodingTask3 task3;

        [TestInitialize]
        public void Initialize()
        {
            task3 = new CodingTask3();
        }

        [TestMethod]
        public void Give12And56ShouldReturn1526()
        {
            var i = task3.Solve(12, 56);

            Assert.AreEqual(1526, i);
        }

        [TestMethod]
        public void Give12345And678ShouldReturn16273845()
        {
            var i = task3.Solve(12345, 678);

            Assert.AreEqual(16273845, i);
        }

        [TestMethod]
        public void Give123And67890ShouldReturn16273890()
        {
            var i = task3.Solve(123, 67890);

            Assert.AreEqual(16273890, i);
        }

        [TestMethod]
        public void Give1234And0ShouldReturn10234()
        {
            var i = task3.Solve(1234, 0);

            Assert.AreEqual(10234, i);
        }
    }
}
