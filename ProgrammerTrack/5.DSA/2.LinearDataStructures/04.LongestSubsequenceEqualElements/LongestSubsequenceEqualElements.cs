using System;
using System.Collections.Generic;

/* 4. Write a method that finds the longest subsequence of equal numbers
* in given List<int> and returns the result as new List<int>.
* Write a program to test whether the method works correctly.
*/

public class LongestSubsequenceEqualElements
{
    public static void Main()
    {
        List<int> numbers = new List<int>() { 4, 4, 4, 4, 5, 3, 4, 5, 8, 2, 3, 5, 6, 7, 3, 3, 3, 3, 3, 3, 3, 6, 5, 9, 0, 8, 7, 6, 5 };

        List<int> result = LongestSubsequence(numbers);
        Console.WriteLine(string.Join(", ", result));
    }

    private static List<int> LongestSubsequence(List<int> list)
    {
        List<int> result = new List<int>();

        if (list == null)
        {
            throw new ArgumentNullException("List can not be null.");
        }

        if (list.Count <= 1)
        {
            return list;
        }

        int maxSubsequenceElement = list[0];
        int maxSubsequenceLength = 1;

        int currentSubsequenceLenght = 1;

        for (int i = 1; i < list.Count; i++)
        {
            if (list[i - 1] == list[i])
            {
                currentSubsequenceLenght++;
            }
            else
            {
                if (currentSubsequenceLenght > maxSubsequenceLength)
                {
                    maxSubsequenceLength = currentSubsequenceLenght;
                    maxSubsequenceElement = list[i - 1];
                    currentSubsequenceLenght = 1;
                }
            }
        }
        //check the last element
        if (currentSubsequenceLenght > maxSubsequenceLength)
        {
            maxSubsequenceLength = currentSubsequenceLenght;
            maxSubsequenceElement = list[list.Count-1];
            currentSubsequenceLenght = 1;
        }

        for (int i = 0; i < maxSubsequenceLength; i++)
        {
            result.Add(maxSubsequenceElement);
        }

        return result;
    }
}