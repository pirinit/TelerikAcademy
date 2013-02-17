using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/* 8. Write a program that extracts from a given text all sentences containing given word.
 * Example: The word is "in". The text is:
 * We are living in a yellow submarine. We don't have anything else.
 * Inside the submarine is very tight. So we are drinking all the day.
 * We will move out of it in 5 days.
 * The expected result is:
 * We are living in a yellow submarine. We will move out of it in 5 days.
 * Consider that the sentences are separated by "." and the words – by non-letter symbols.
 */
class ExtractSentences
{
    static void Main()
    {
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string target = "in";
        string[] sentences = text.Split('.');
        string regExPatter = String.Format(@"\b{0}\b", target);
        for (int i = 0; i < sentences.Length; i++)
        {
            if (Regex.IsMatch(sentences[i], regExPatter))
            {
                Console.WriteLine(sentences[i].Trim() + ".");
            }
        }
    }
}