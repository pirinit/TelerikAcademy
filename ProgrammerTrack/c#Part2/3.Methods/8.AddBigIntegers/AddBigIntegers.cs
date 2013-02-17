using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 8. Write a method that adds two positive integer numbers represented
* as arrays of digits (each array element arr[i] contains a digit;
* the last digit is kept in arr[0]). Each of the numbers that will be
* added could have up to 10 000 digits.
*/
class AddBigIntegers
{
    static int[] AddTwoIntegers(int[] first, int[] second)
    {
        if (first.Length > second.Length)
        {
            int[] temp = first;
            first = second;
            second = temp;
        }
        int[] result = new int[second.Length];
        int change = 0;
        for (int i = 0; i < first.Length; i++)
        {
            int temp = first[i] + second[i] + change;
            result[i] = temp % 10;
            change = temp / 10;
        }
        for (int i = first.Length; i < second.Length; i++)
        {
            int temp = second[i] + change;
            result[i] = temp % 10;
            change = temp / 10;
        }
        return result;
    }

    static string ArrayToString(int[] arr)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = arr.Length-1; i >= 0; i--)
        {
            sb.Append(arr[i]);
        }
        return sb.ToString();
    }

    static void Main()
    {
        int[] first = new int[] { 1, 5, 6, 7, 8 };
        int[] second = new int[] { 2, 3, 6, 7, 9, 8, 6 };


        Console.WriteLine(ArrayToString(first));
        Console.WriteLine(ArrayToString(second));
        Console.WriteLine(ArrayToString(AddTwoIntegers(second, first)));
    }
}