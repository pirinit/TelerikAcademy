using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 9. Write a program that finds the most frequent number in an array. Example:
	{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)
 */
class MostFrequantNumber
{
    static void Main()
    {
        int[] arr = new int[] { 4, 1, 4, 1, 2, 3, 4, 1, 1, 2, 4, 9, 3, 4, 4 };
        Dictionary<int, int> frequency = new Dictionary<int, int>();

        for (int i = 0; i < arr.Length; i++)
        {
            if (frequency.ContainsKey(arr[i]))
            {
                frequency[arr[i]]++;
            }
            else
            {
                frequency.Add(arr[i], 1);
            }
        }

        int mostFrequantValue = 0;
        int mostFrequantValueCount = 0;
        foreach (var item in frequency)
        {
            if (item.Value > mostFrequantValueCount)
            {
                mostFrequantValueCount = item.Value;
                mostFrequantValue = item.Key;
            }
        }

        Console.WriteLine("The most frequant value is: {0}({1} times)", mostFrequantValue, mostFrequantValueCount);
    }
}