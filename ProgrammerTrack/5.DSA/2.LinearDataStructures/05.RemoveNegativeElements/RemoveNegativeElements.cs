using System;
using System.Collections.Generic;
//using System.Linq;

/* 5. Write a program that removes from given sequence all negative numbers.
 */
class RemoveNegativeElements
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>() { 4, 4, 4, 4, 5, 3, -4, -0, -8, -2, -3, 5, 6, 7, -3, -3, -3, 3, 3, 3, 3, 6, 5, 9, 0, 8, 7, 6, 5 };

        numbers = RemoveNegative(numbers);
        Console.WriteLine(string.Join(", ", numbers));
    }

    private static List<int> RemoveNegative(List<int> list)
    {
        List<int> result = new List<int>();

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] >= 0)
            {
                result.Add(list[i]);
            }
        }

        return result;
    }
}