using System;
using ProgrammingTest;

namespace MorseParserConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "Input.txt";
            while (fileName != string.Empty)
            {
                try
                {
                    var MorseParser = new MorseParser();
                    Console.WriteLine();
                    Console.WriteLine("Processing {0}", fileName);
                    MorseParser.Load(fileName);
                    MorseParser.Process();
                    Console.WriteLine();
                    foreach (var word in MorseParser.Translations)
                    {
                        Console.WriteLine(word);
                    }
                    Console.WriteLine();
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error occurred processing file {0}", fileName);
                    Console.WriteLine(exception.Message);
                }

                Console.WriteLine("Please enter another input file name or return to quit");
                fileName = Console.ReadLine();
            }
        }
    }
}
