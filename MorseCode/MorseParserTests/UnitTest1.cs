using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgrammingTest;

namespace MorseParserTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string fileName = "Input.txt";
            string _filePath = System.AppDomain.CurrentDomain.BaseDirectory;
            var MorseParser = new MorseParser();
            MorseParser.Load(Path.Combine(_filePath, fileName));
            MorseParser.Process();
        }

        [TestMethod]
        public void ParseNextMethod()
        {
            var morseWord = "...";
            var MorseParser = new MorseParser();
            MorseParser.MorseKeys.Add(".", "E");
            MorseParser.MorseKeys.Add("..", "I");
            MorseParser.MorseKeys.Add("...", "S");
            var results = MorseParser.ParseNext(morseWord, "");
        }
    }
}
