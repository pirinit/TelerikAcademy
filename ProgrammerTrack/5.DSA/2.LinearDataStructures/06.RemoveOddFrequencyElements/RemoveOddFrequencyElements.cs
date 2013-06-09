using System;
using System.Collections.Generic;

/* 6. Write a program that removes from given sequence
 * all numbers that occur odd number of times.
 * Example:
 * {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5}
 */
public class RemoveOddFrequencyElements
{
    public static void Main()
    {
        List<int> numbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
        var result = RemoveOddFrequencyElement(numbers);
        Console.WriteLine(string.Join(" ", result));
    }

    private static List<int> RemoveOddFrequencyElement(List<int> numbers)
    {
        List<int> result = new List<int>();
        Dictionary<int, int> frequency = new Dictionary<int, int>();

        
        foreach (int num in numbers)
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

        foreach (var num in numbers)
        {
            if (frequency[num] % 2 == 0)
            {
                result.Add(num);
            }
        }

        return result;
    }


}