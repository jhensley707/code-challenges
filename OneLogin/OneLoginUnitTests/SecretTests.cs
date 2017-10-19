using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretLibrary;

namespace OneLoginUnitTests
{
    [TestClass]
    public class SecretTests
    {
        private Secret _secret;
        const string input1 = "agent";
        const string expected1 = "nteag";
        const string input2 = "secret";
        const string expected2 = "retsec";

        [TestInitialize]
        public void Initialize()
        {
            _secret = new Secret();
        }

        [TestMethod]
        public void WithInput1ShouldReturnExpected1()
        {
            var result = _secret.ReverseByCenter(input1);

            Assert.AreEqual(expected1, result);
        }

        [TestMethod]
        public void WithInput2ShouldReturnExpected2()
        {
            var result = _secret.ReverseByCenter(input2);

            Assert.AreEqual(expected2, result);
        }
    }
}
