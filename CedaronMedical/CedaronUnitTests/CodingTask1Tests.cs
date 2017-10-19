using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CedaronMedical;

namespace CedaronUnitTests
{
    [TestClass]
    public class CodingTask1Tests
    {
        [TestMethod]
        public void GivenArrayShouldReturn2()
        {
            var task1 = new CodingTask1();
            var i = task1.Solve(new int[] { 1, 0, 0, 1, 0, 0 });

            Assert.AreEqual(2, i);
        }
    }
}
