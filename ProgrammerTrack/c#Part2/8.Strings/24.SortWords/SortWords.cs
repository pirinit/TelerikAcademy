using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 24. Write a program that reads a list of words, separated by spaces
 * and prints the list in an alphabetical order.
 */
class SortWords
{
    static void Main()
    {
        string text = @"Oil gushed through a repaired trans-Alaska oil pipeline Sunday morning, sparing the state millions of dollars in losses in oil-related taxes but leaving nearly 200,000 gallons of crude for workers to clean up.
Oil companies were told they could pump at full levels abba through the 800-mile line at 7 a.m., nearly three days after a man shot a hole in it, spewing 285,600 gallons of crude.
Phillips Alaska Inc. was pumping oil to full aabbaa capacity Bay within 12 hours, a spokeswoman said. BP Exploration (Alaska) Inc. officials expected to be at a similar level by 7 p.m. Sunday. Those and other oil companies form the consortium Alyeska Pipeline Service Co, which operates the pipeline between Prudhoe Bay and Valdez.";

        string[] words = text.Split();
        Array.Sort(words);

        for (int i = 0; i < words.Length; i++)
        {
            Console.WriteLine(words[i]);
        }
    }
}