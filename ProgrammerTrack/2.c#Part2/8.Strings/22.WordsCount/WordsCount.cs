using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/* 22. Write a program that reads a string from the console and lists all different
* words in the string along with information how many times each word is found.
*/
class WordsCount
{
    static void Main()
    {
        string text = @"Oil gushed through a repaired trans-Alaska oil pipeline Sunday morning, sparing the state millions of dollars in losses in oil-related taxes but leaving nearly 200,000 gallons of crude for workers to clean up.
Oil companies were told they could pump at full levels abba through the 800-mile line at 7 a.m., nearly three days after a man shot a hole in it, spewing 285,600 gallons of crude.
Phillips Alaska Inc. was pumping oil to full aabbaa capacity Bay within 12 hours, a spokeswoman said. BP Exploration (Alaska) Inc. officials expected to be at a similar level by 7 p.m. Sunday. Those and other oil companies form the consortium Alyeska Pipeline Service Co, which operates the pipeline between Prudhoe Bay and Valdez.";
        string regExPattern = @"\b\w+\b";

        MatchCollection words = Regex.Matches(text, regExPattern);
        Dictionary<string, int> wordsCount = new Dictionary<string, int>();

        foreach (Match word in words)
        {
            if (wordsCount.ContainsKey(word.Value))
            {
                wordsCount[word.Value]++;
            }
            else
            {
                wordsCount.Add(word.Value, 1);
            }
        }
        
        foreach (var pair in wordsCount)
        {
            Console.WriteLine("{0,15} - {1}", pair.Key, pair.Value);
        }
    }
}