using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/* 9. We are given a string containing a list of forbidden words and a text
 * containing some of these words. Write a program that replaces the forbidden words with asterisks.
 * Example:
 * Microsoft announced its next generation PHP compiler today.
 * It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.
 * Words: "PHP, CLR, Microsoft"
 * The expected result:
 * ********* announced its next generation *** compiler today. It is based on
 * .NET Framework 4.0 and is implemented as a dynamic language in ***.
 */
class ReplaceWords
{
    static void Main()
    {
        string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string[] words = { "PHP", "CLR", "Microsoft"};

        for (int i = 0; i < words.Length; i++)
        {
            string regExPattern = String.Format(@"\b{0}\b", words[i]);
            text = Regex.Replace(text, regExPattern, new string('*', words[i].Length));
        }

        Console.WriteLine(text);
    }
}