using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 4. Write a method that counts how many times given number appears in given array.
* Write a test program to check if the method is working correctly.
*/
class NumberCountInArray
{
    static int AppearanceCount(int number, int[] array)
    {
        int count = 0;
        foreach (var n in array)
        {
            if (number == n)
            {
                count++;
            }
        }
        return count;
    }

    static string ArrayToString(int[] array)
    {
        StringBuilder result = new StringBuilder();
        result.Append("{");
        for (int i = 0; i < array.Length; i++)
        {
            result.AppendFormat(" {0},", array[i]);
        }
        result.Append("\x0008 }");
        return result.ToString();
    }

    static void Main()
    {
        int[] numbers = new int[] { 1, 5, 6, 8, 3, 3, 3, 3, 7, 5, 4, 5, 3, 7, 4, 8 };
        int n = 5;
        Console.WriteLine("{0} appearce {1} times in \n{2}", n, AppearanceCount(n,numbers), ArrayToString(numbers));
    }
}