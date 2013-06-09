using System;
using System.Collections.Generic;

/* 7. Write a program that finds in given array of integers
 * (all belonging to the range [0..1000])
 * how many times each of them occurs.
 * Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
 * 2  2 times
 * 3  4 times
 * 4  3 times
 */ 
public class ElementFrequency
{
    public static void Main()
    {
        int[] numbers = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

        //using dictionary
        var frequency = CountElementsFrequency(numbers);

        foreach (var pair in frequency)
        {
            Console.WriteLine("{0} --> {1}", pair.Key, pair.Value);
        }

        //using array
        var frequencyArray = CountElementsFrequencyArray(numbers);

        for (int i = 0; i < frequencyArray.Length; i++)
        {
            if (frequencyArray[i] != 0)
            {
                Console.WriteLine("{0} --> {1}", i, frequencyArray[i]);
            }
        }
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

    private static int[] CountElementsFrequencyArray(int[] numbers)
    {
        int[] frequency = new int[1001];

        foreach (var num in numbers)
        {
            frequency[num]++;
        }

        return frequency;
    }
}