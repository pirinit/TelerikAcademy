using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 10. Write a program to calculate n! for each n in the range [1..100].
 * Hint: Implement first a method that multiplies a number
 * represented as array of digits by given integer number. 
 */
class NFactoriel
{
    static int[] MultiplayArrayByInt(int[] arr, int number)
    {
        int[] result;
        int change = 0;
        List<int> temp = new List<int>();
        for (int i = 0; i < arr.Length; i++)
        {
            int product = arr[i] * number + change;
            int digit = product % 10;
            change = product / 10;
            temp.Add(digit);
        }
        while (change > 0)
        {
            temp.Add(change % 10);
            change = change / 10;
        }
        result = temp.ToArray();
        return result;
    }

    static string ArrayToString(int[] arr)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            sb.Append(arr[i]);
        }
        return sb.ToString();
    }

    static void Main()
    {
        int[] factoriel = new int[] { 1 };
        Console.WriteLine("Factoriel of 1 is 1.");
        for (int i = 2; i < 101; i++)
        {
            factoriel = MultiplayArrayByInt(factoriel, i);
            Console.WriteLine("Factoriel of {0} is {1}.", i, ArrayToString(factoriel));
        }
    }
}