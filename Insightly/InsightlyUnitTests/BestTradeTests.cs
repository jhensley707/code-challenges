using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    public class BestTradeTests
    {
        [TestClass]
        public class CalculateMethod
        {
            [TestMethod]
            public void ShouldReturnZeroWithOneValue()
            {
                var array = new int[] { 500 };
                var algorithm = new Algorithm.BestTrade();

                var result = algorithm.Calculate(array);

                Assert.IsNotNull(result);
                Assert.AreEqual(0, result);
            }

            [TestMethod]
            public void ShouldReturnTenWithTwoIncreasingValues()
            {
                var array = new int[] { 500, 510, };
                var algorithm = new Algorithm.BestTrade();

                var result = algorithm.Calculate(array);

                Assert.IsNotNull(result);
                Assert.AreEqual(10, result);
            }

            [TestMethod]
            public void ShouldReturnZeroWithTwoDecreasingValues()
            {
                var array = new int[] { 510, 500, };
                var algorithm = new Algorithm.BestTrade();

                var result = algorithm.Calculate(array);

                Assert.IsNotNull(result);
                Assert.AreEqual(0, result);
            }

            [TestMethod]
            public void ShouldReturnSixtyWithTwoDecreasingValues()
            {
                // Difference between 490 and 550 is 60
                // Difference between 400 and 520 is 120
                var array = new int[] { 510, 500, 490, 515, 525, 550, 400, 510, 520, };
                var algorithm = new Algorithm.BestTrade();

                var result = algorithm.Calculate(array);

                Assert.IsNotNull(result);
                Assert.AreEqual(120, result);
            }
        }
    }
}
