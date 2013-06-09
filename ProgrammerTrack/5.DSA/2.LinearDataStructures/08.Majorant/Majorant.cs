using System;
using System.Collections.Generic;

/* 8. * The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.
 * Write a program to find the majorant of given array (if exists).
 * Example:
 * {2, 2, 3, 3, 2, 3, 4, 3, 3}  3
 */
public class Majorant
{
    public static void Main()
    {
        int[] numbers = new int[] { 2, 2, 3, 2, 2, 2, 2, 3, 4, 3, 3 };

        int majorant = 0;

        bool hasMajorant = FindMajorant(numbers, out majorant);

        if (hasMajorant)
        {
            Console.WriteLine("The majorant is: {0}", majorant);
        }
        else
        {
            Console.WriteLine("There is no majorant.");
        }
    }

    private static bool FindMajorant(int[] numbers, out int majorant)
    {
        var frequancy = CountElementsFrequency(numbers);
        int minMajorantFrequancy = numbers.Length / 2 + 1;

        foreach (var pair in frequancy)
        {
            if (pair.Value >= minMajorantFrequancy)
            {
                majorant = pair.Key;
                return true;
            }
        }

        majorant = 0;
        return false;
    }

    private static Dictionary<int, int> CountElementsFrequency(int[] numbers)
    {
        Dictionary<int, int> frequency = new Dictionary<int, int>();

        foreach (var num in numbers)
        {
            if (frequency.ContainsKey(num))
            {
                frequency[num]++;
            }
            else
            {
                frequency.Add(num, 1);
            }
        }

        return frequency;
    }
}