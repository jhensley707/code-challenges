using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProgrammingTest
{
    public class MorseParser
    {
        // The longest any MorseKey can be is 6 dots and dashes
        public const int MaxLengthMorseWord = 6;
        public Dictionary<string, string> MorseKeys = new Dictionary<string, string>();
        protected List<string> WordContext = new List<string>();
        protected List<string> MorseWords = new List<string>();
        public List<string> Translations = new List<string>();
        
        /// <summary>
        /// Loads input information from file. Required before Parse()
        /// </summary>
        /// <param name="fileName"></param>
        public void Load (string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }

            // Open file
            if (!File.Exists(fileName))
            {
                throw new ArgumentException("File {0} not found");
            }

            string line;
            bool IsMorseKeysComplete = false;
            bool IsWordContextComplete = false;
            bool IsMorseWordsComplete = false;
            StreamReader file = new StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                if (line.Trim().Length == 0)
                {
                    continue;
                }

                // Read each line until asterisk to populate MorseKeys
                if (!IsMorseKeysComplete)
                {
                    if (line.Contains("*"))
                    {
                        IsMorseKeysComplete = true;
                        continue;
                    }
                    string[] morseKey = line.Trim().Split(new char[] { ' ' });
                    MorseKeys.Add(morseKey[1], morseKey[0]);
                    continue;
                }

                // Read each line until asterisk to populate WordContext
                if (!IsWordContextComplete)
                {
                    if ((line.Contains("*")))
                    {
                        IsWordContextComplete = true;
                        continue;
                    }
                    WordContext.Add(line.Trim());
                    continue;
                }

                // Read each line until asterisk to populate MorseWords
                if (!IsMorseWordsComplete)
                {
                    if ((line.Contains("*")))
                    {
                        IsWordContextComplete = true;
                        continue;
                    }
                    // Remove any spaces; their accuracy can be misleading
                    var morseWords = line.Split(' ');
                    foreach (var morseWord in morseWords)
                    {
                        MorseWords.Add(morseWord);
                    }
                    continue;
                }
            }

            file.Close();
        }

        /// <summary>
        /// Processes the MorseWords
        /// </summary>
        public void Process()
        {
            foreach (var morseWord in MorseWords)
            {
                ProcessMorseWord(morseWord);
                // Only work on one for now
                //break;
            }
        }

        /// <summary>
        /// Examines an individual MorseWord, parsing the characters
        /// into possible sequences
        /// </summary>
        /// <param name="morseWord"></param>
        public void ProcessMorseWord(string morseWord)
        {
            // The first character sequence could be 1 to 6 characters
            // Identify all of these possible sequences, then check for
            // a matching character with FindCharacter()
            // For each character that is matched, examine the next 1 to 6 characters
            // to identify the next possible character.

            // Once all possible combinations are identified, try to find the best match.
            // Happy path: an exact match is found. We can't assume the first character
            // is correct which makes partial matching complex
            List<string> possibleWords = new List<string>();
            var maxLength = Math.Min(MaxLengthMorseWord, morseWord.Length);
            var pointer = 0;
            for (var i = pointer + 1; i <= maxLength; i++)
            {
                var morseSequence = morseWord.Substring(pointer, i);
                var morseCharacter = FindCharacter(morseSequence);
                if (morseCharacter != null)
                {
                    string possibleWord = morseCharacter;
                    if (WordContext.Any(w => w.IndexOf(possibleWord) == 0))
                    {
                        // Pass the remaining characters in the string to a recursion routine
                        // to keep generating possible words
                        possibleWords.AddRange(ParseNext(morseWord.Substring(i, morseWord.Length - i), possibleWord));
                    }
                }
            }

            Translations.Add(FindBestMatch(possibleWords));
        }

        /// <summary>
        /// Recursion routine to continue parsing the remaining characters of a MorseWord.
        /// This routine is incomplete and may not work. Since it is matching the shortest patterns,
        /// like 'E', it comes up with 'nonsensical' words. This is a code smell
        /// that trying to find possible matches in the WordContext list may be a better
        /// way to proceed
        /// </summary>
        /// <param name="morseWord"></param>
        /// <param name="possibleWord"></param>
        /// <returns></returns>
        public List<string> ParseNext(string morseWord, string possibleWord)
        {
            var possibleWords = new List<string>();
            if (morseWord.Length == 0)
            {
                possibleWords.Add(possibleWord);
                return possibleWords;
            }
            var pointer = 0;
            for (var i = pointer + 1; i <= MaxLengthMorseWord; i++)
            {
                if (i > morseWord.Length)
                {
                    break;
                }
                var morseSequence = morseWord.Substring(pointer, i);
                var morseCharacter = FindCharacter(morseSequence);
                if (morseCharacter != null)
                {
                    possibleWords.AddRange(ParseNext(morseWord.Substring(i, morseWord.Length - i), possibleWord + morseCharacter));
                }
            }
            return possibleWords;
        }

        /// <summary>
        /// Given a possible morse sequence of dots and dashes,
        /// find the matching letter or number
        /// </summary>
        /// <param name="morseSequence"></param>
        /// <returns></returns>
        public string FindCharacter(string morseSequence)
        {
            if (MorseKeys.ContainsKey(morseSequence))
            {
                return MorseKeys[morseSequence];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Logic to take the possible words identified and
        /// choose the best possible match
        /// </summary>
        /// <param name="possibleWords"></param>
        /// <returns></returns>
        public string FindBestMatch(List<string> possibleWords)
        {
            var possibleMatches = new List<string>();
            foreach(var possibleWord in possibleWords)
            {
                if (WordContext.Contains(possibleWord))
                {
                    possibleMatches.Add(possibleWord);
                    if (possibleMatches.Count > 1)
                    {
                        // Multiple matches
                        return possibleMatches.First() + "!";
                    }
                }
            }

            // Logic here to find partial matches, adding question mark or exclamation
            if (possibleMatches.Count == 1)
            {
                // Exact match
                return possibleMatches.First();
            }

            // No matches. Look for best possible
            var percentMatch = new List<MatchRank>();
            foreach (var possibleWord in possibleWords)
            {
                // Get a subset of the words with the same length
                var context = WordContext.Where(w => w.Length == possibleWord.Length).ToList();
                foreach (var contextWord in context)
                {
                    var count = 0;
                    for (var i = 0; i < possibleWord.Length; i++)
                    {
                        if (contextWord.Substring(i, 1) == possibleWord.Substring(i, 1))
                        {
                            count++;
                        }
                    }
                    var matchPercent = (float)count / possibleWord.Length;
                    if (matchPercent > 0.0)
                    {
                        percentMatch.Add(new MatchRank { MatchPercent = matchPercent, Word = contextWord });
                    }
                }
            }

            // Return the best match
            if (percentMatch.Count > 0)
            {
                var bestMatch = percentMatch.OrderByDescending(m => m.MatchPercent).First();
                return bestMatch.Word + "?";
            }
            else
            {
                return "Match not found";
            }
        }
    }
}
