using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CedaronMedical;

namespace CedaronUnitTests
{
    [TestClass]
    public class WordMatcherUnitTests
    {
        const string expectedMatch = "snowbanks ";
        WordMatcher wordMatcher;
        string[] list1;
        string[] list2;

        [TestInitialize]
        public void Initialize()
        {
            wordMatcher = new WordMatcher();
            list1 = System.IO.File.ReadAllLines("Text1.txt");
            list2 = System.IO.File.ReadAllLines("Text2.txt");

        }

        // Run time 1:54
        [TestMethod]
        public void WithMatchFirstShouldReturnMatch()
        {
            var match = wordMatcher.MatchFirst(list1, list2);

            Assert.AreEqual(expectedMatch, match);
        }

        // Run time 0:14
        [TestMethod]
        public void WithMatchFirst2ShouldReturnMatch()
        {
            var match = wordMatcher.MatchFirst2(list1, list2);

            Assert.AreEqual(expectedMatch, match);
        }
    }
}
