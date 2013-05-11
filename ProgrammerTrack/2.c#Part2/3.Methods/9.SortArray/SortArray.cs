using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 9. Write a method that return the maximal element in a portion of array
* of integers starting at given index. Using it write another method
* that sorts an array in ascending / descending order.
*/
class SortArray
{
    static int MaxElementIndex(int[] arr, int startIndex)
    {
        int max = int.MinValue;
        int maxIndex = 0;

        for (int i = startIndex; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
                maxIndex = i;
            }
        }
        return maxIndex;
    }

    static void Sort(int[] arr, bool descending = false)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int maxElementIndex = MaxElementIndex(arr, i);
            int temp = arr[maxElementIndex];
            arr[maxElementIndex] = arr[i];
            arr[i] = temp;
        }
        if (descending)
        {
            Array.Reverse(arr);
        }
    }

    static void PrintArray(int[] arr)
    {
        Console.Write("{");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(" {0},", arr[i]);
        }
        Console.WriteLine("\x0008 }");
    }

    static void Main()
    {
        int[] arr = new int[] { 2, 3, 6, 7, 9, 8, 6, 45345, 4, 5, 4535 };

        PrintArray(arr);
        Sort(arr, true);
        PrintArray(arr);
        Sort(arr);
        PrintArray(arr);
    }
}