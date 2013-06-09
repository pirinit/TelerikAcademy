using System;
using System.Collections.Generic;
using System.Linq;

/* 2. Write a program that extracts from a given sequence
 * of strings all elements that present in it odd number of times.
 * Example:
 * {C#, SQL, PHP, PHP, SQL, SQL }  {C#, SQL}
 */
namespace _2.OddElementsInString
{
    public class OddElementsInString
    {
        public static void Main()
        {
            string[] words = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL", "PHP" };

            Dictionary<string, int> occurances = new Dictionary<string, int>();

            //populate dictionary
            foreach (var word in words)
            {
                if (occurances.ContainsKey(word))
                {
                    occurances[word] += 1;
                }
                else
                {
                    occurances.Add(word, 1);
                }
            }

            // print result
            foreach (var pair in occurances)
            {
                if (pair.Value % 2 == 1)
                {
                    Console.WriteLine(pair.Key);
                }
            }
        }
    }
}
