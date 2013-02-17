using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/* 20. Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".
*/
class ExtractPalindroms
{
    static bool IsPalindrom(string input)
    {
        //single characters are not palindroms
        if (input.Length < 2)
        {
            return false;
        }
        for (int i = 0; i < input.Length / 2; i++)
        {
            if (input[i] != input[input.Length - 1 - i])
            {
                return false;
            }
        }

        return true;
    }

    static void Main()
    {
        string text = @"Oil gushed through a repaired trans-Alaska oil pipeline Sunday morning, sparing the state millions of dollars in losses in oil-related taxes but leaving nearly 200,000 gallons of crude for workers to clean up.
Oil companies were told they could pump at full levels abba through the 800-mile line at 7 a.m., nearly three days after a man shot a hole in it, spewing 285,600 gallons of crude.
Phillips Alaska Inc. was pumping oil to full aabbaa capacity within 12 hours, a spokeswoman said. BP Exploration (Alaska) Inc. officials expected to be at a similar level by 7 p.m. Sunday. Those and other oil companies form the consortium Alyeska Pipeline Service Co, which operates the pipeline between Prudhoe Bay and Valdez.";
        string regExPattern = @"\b\w+\b";

        MatchCollection words = Regex.Matches(text, regExPattern);

        foreach (Match word in words)
        {
            if (IsPalindrom(word.Value))
            {
                Console.WriteLine(word);
            }
        }
    }
}