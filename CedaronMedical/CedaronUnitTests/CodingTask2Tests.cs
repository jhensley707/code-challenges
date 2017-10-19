using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CedaronMedical;

namespace CedaronUnitTests
{
    [TestClass]
    public class CodingTask2Tests
    {
        const string Line1 = "We test programmers. Give us a try?";
        const string Line2 = "Forget   resumes.. Save time . x x";

        CodingTask2 task2;

        [TestInitialize]
        public void Initialize()
        {
            task2 = new CodingTask2();
        }

        [TestMethod]
        public void GivenLine1ShouldReturn4()
        {
            var i = task2.Solve(Line1);

            Assert.AreEqual(4, i);
        }

        [TestMethod]
        public void GivenLine2ShouldReturn2()
        {
            var i = task2.Solve(Line2);

            Assert.AreEqual(2, i);
        }
    }
}
