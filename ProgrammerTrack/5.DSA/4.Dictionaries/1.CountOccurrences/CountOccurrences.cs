using System;
using System.Collections.Generic;

/* 1. Write a program that counts in a given array of double values
 * the number of occurrences of each value. Use Dictionary<TKey,TValue>.
 * Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
 * -2.5  2 times
 * 3  4 times
 * 4  3 times
 */
namespace _1.CountOccurrences
{
    public class CountOccurrences
    {
        public static void Main(string[] args)
        {
            double[] arr = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            SortedDictionary<double, int> occurances = new SortedDictionary<double, int>();

            // populate dictionary
            foreach (var number in arr)
            {
                if (occurances.ContainsKey(number))
                {
                    occurances[number] += 1;
                }
                else
                {
                    occurances.Add(number, 1);
                }
            }

            // print result
            foreach (var pair in occurances)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }
    }
}
