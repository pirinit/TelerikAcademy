using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

/* 3. Write a program that counts how many times each word
 * from given text file words.txt appears in it. The character
 * casing differences should be ignored. The result words should
 * be ordered by their number of occurrences in the text.
 */

namespace _3.CountWordsInFile
{
    public class CountWordsInFile
    {
        public static void Main()
        {
            string text = string.Empty;
            using (StreamReader file = new StreamReader(@"..\..\words.txt"))
            {
                text = file.ReadToEnd();
            }

            var words = Regex.Matches(text, @"\w+");

            Dictionary<string, int> occurances = new Dictionary<string, int>();

            foreach (var match in words)
            {
                string word = match.ToString();
                if (occurances.ContainsKey(word))
                {
                    occurances[word] += 1;
                }
                else
                {
                    occurances.Add(word, 1);
                }
            }

            var ordered = occurances.OrderByDescending(x => x.Value);
            foreach (var pair in ordered)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }
    }
}
