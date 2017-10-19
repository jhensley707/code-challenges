using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedaronMedical
{
    /// <summary>
    /// Find the sentence with the most words. The sentence contains letters,
    /// spaces, and punctuation (periods, question marks and exclamation points).
    /// The text can be split into sentences at the punctuation. The sentences can
    /// be split into words at spaces. A sentence without words is considered valid.
    /// However, a word must have at least one letter.
    /// </summary>
    public class CodingTask2
    {
        /// <summary>
        /// Parses the given string into sentences, then parses each sentence into words.
        /// Returns the largest count of words in the sentences.
        /// </summary>
        /// <param name="input">Random paragraph of sentences</param>
        /// <returns>Max count of longest sentence</returns>
        public int Solve(string input)
        {
            var maxCount = 0;
            // Split input on punctuation
            var sentences = input.Split('.', '?', '!');
            foreach (var sentence in sentences)
            {
                // Split each sentence into words, dropping empty words
                var words = sentence.Trim().Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                // Compare sentence length with current max
                if (words.Length > maxCount)
                {
                    // Sentence is longer so update maxCount
                    maxCount = words.Length;
                }
            }
                
            return maxCount;
        }
    }
}
