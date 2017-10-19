using System;
using CedaronMedical;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CedaronUnitTests
{
    [TestClass]
    public class CodingDemoTests
    {
        CodingDemo demo;

        [TestInitialize]
        public void Initialize()
        {
            demo = new CodingDemo();
        }

        [TestMethod]
        public void GivenMixedIntArrayShouldReturn5()
        {
            var array = new int[] { 1, 3, 6, 4, 1, 2 };

            var i = demo.Solve(array);

            Assert.AreEqual(5, i);
        }

        [TestMethod]
        public void GivenSortedIntArrayShouldReturn4()
        {
            var array = new int[] { 1, 2, 3 };

            var i = demo.Solve(array);

            Assert.AreEqual(4, i);
        }

        [TestMethod]
        public void GivenNegativeIntArrayShouldReturn1()
        {
            var array = new int[] { -1, -3 };

            var i = demo.Solve(array);

            Assert.AreEqual(1, i);
        }
    }
}
