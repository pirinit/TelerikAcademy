using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 21. Write a program that reads a string from the console and prints all different letters
 * in the string along with information how many times each letter is found. 
 */
class LettersCount
{
    static void Main()
    {
        int[] letterCount = new int[256];

        string text = @"Oil gushed through a repaired trans-Alaska oil pipeline Sunday morning, sparing the state millions of dollars in losses in oil-related taxes but leaving nearly 200,000 gallons of crude for workers to clean up.
Oil companies were told they could pump at full levels abba through the 800-mile line at 7 a.m., nearly three days after a man shot a hole in it, spewing 285,600 gallons of crude.
Phillips Alaska Inc. was pumping oil to full aabbaa capacity within 12 hours, a spokeswoman said. BP Exploration (Alaska) Inc. officials expected to be at a similar level by 7 p.m. Sunday. Those and other oil companies form the consortium Alyeska Pipeline Service Co, which operates the pipeline between Prudhoe Bay and Valdez.";

        for (int i = 0; i < text.Length; i++)
        {
            letterCount[(int)text[i]]++;
        }
        int totalLetters = 0;
        for (int i = 65; i < 91; i++)
        {
            int smallLetterIndex = i + 32;
            Console.WriteLine("{0} - {1,5}, {2} - {3,5}", (char)i, letterCount[i], (char)smallLetterIndex, letterCount[smallLetterIndex]);
            totalLetters += letterCount[i] + letterCount[smallLetterIndex];
        }

        Console.WriteLine("String length {0}, counted letters {1}", text.Length, totalLetters);
    }
}