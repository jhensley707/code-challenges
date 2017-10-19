using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedaronMedical
{
    /// <summary>
    /// Given two files with random words, identify the one word
    /// contained in both lists.
    /// </summary>
    public class WordMatcher
    {
        /// <summary>
        /// An O(n^2) method. While this brute force method works,
        /// it is not efficient when the list sizes grow.
        /// </summary>
        /// <param name="list1">Random string array of words</param>
        /// <param name="list2">Random string array of words</param>
        /// <returns>First matched word</returns>
        public string MatchFirst(string[] list1, string[] list2)
        {
            foreach (var word1 in list1)
            {
                foreach (var word2 in list2)
                {
                    if (word1.Equals(word2))
                    {
                        return word1;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Uses sorted dictionaries to group words by first character
        /// and significantly reduce run time
        /// </summary>
        /// <param name="list1">Random string array of words</param>
        /// <param name="list2">Random string array of words</param>
        /// <returns>First matched word</returns>
        public string MatchFirst2(string[] list1, string[] list2)
        {
            var alphabet = new Char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            var dictionary1 = new SortedDictionary<Char, List<string>>();
            var dictionary2 = new SortedDictionary<Char, List<string>>();

            // Initialize dictionary
            for (int i = 0; i < 26; i++)
            {
                dictionary1.Add(alphabet[i], new List<string>());
                dictionary2.Add(alphabet[i], new List<string>());
            }

            // Convert to indexed lists
            foreach (var word in list1)
            {
                IndexWord(dictionary1, word);
            }

            foreach (var word in list2)
            {
                IndexWord(dictionary2, word);
            }

            // Loop through lists, comparing indexed words
            foreach (var letter in dictionary1.Keys)
            {
                foreach (var word1 in dictionary1[letter])
                {
                    foreach (var word2 in dictionary2[letter])
                    {
                        if (word1.Equals(word2))
                        {
                            return word1;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Helper method to add word into the dictionary
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="word"></param>
        public void IndexWord (SortedDictionary<char, List<string>> dictionary, string word)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException("dictionary");
            }

            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentException("value is empty or null", "word");
            }

            var firstChar = Convert.ToChar(word.Substring(0, 1));
            if (!dictionary.ContainsKey(firstChar))
            {
                throw new Exception(string.Format("Key not found {0}", firstChar));
            }
            if (dictionary[firstChar] == null)
            {
                dictionary[firstChar] = new List<string>();
            }

            dictionary[firstChar].Add(word);
        }
    }
}
