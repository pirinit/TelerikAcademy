using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 14. Write a program that sorts an array of strings
* using the quick sort algorithm (find it in Wikipedia).
*/
class QuickSort
{
    static int DivideByPivot(string[] arr, int leftIndex, int rightIndex, int pivotIndex)
    {
        int firstBiggerIndex = leftIndex;
        string temp = arr[pivotIndex];
        arr[pivotIndex] = arr[rightIndex];
        arr[rightIndex] = temp;
        pivotIndex = rightIndex;

        for (int i = leftIndex; i < rightIndex; i++)
        {
            if (arr[i].CompareTo(arr[pivotIndex]) == -1)
            {
                if (i != firstBiggerIndex)
                {
                    temp = arr[i];
                    arr[i] = arr[firstBiggerIndex];
                    arr[firstBiggerIndex] = temp;
                    firstBiggerIndex++;
                }
                else
                {
                    firstBiggerIndex++;
                }
            }
        }
        temp = arr[pivotIndex];
        arr[pivotIndex] = arr[firstBiggerIndex];
        arr[firstBiggerIndex] = temp;
        return firstBiggerIndex;
    }

    static void Sort(string[] arr, int leftIndex, int rightIndex)
    {
        if (leftIndex < rightIndex)
        {
            int pivotIndex = leftIndex + (rightIndex - leftIndex)/2;
            pivotIndex = DivideByPivot(arr, leftIndex, rightIndex, pivotIndex);

            Sort(arr, leftIndex, pivotIndex - 1);
            Sort(arr, pivotIndex + 1, rightIndex);
        }
    }

    static void Main(string[] args)
    {
        string[] strings = new string[]
        {
            "Write", "program", "that", "sorts", "an",
            "array", "of", "strings", "using", "the", "quick", "sort", "algorithm"
        };
        
        for (int i = 0; i < strings.Length; i++)
        {
            Console.WriteLine("{0} - {1}", i, strings[i]);
        }
        Sort(strings, 0, strings.Length - 1);
        Console.WriteLine();
        for (int i = 0; i < strings.Length; i++)
        {
            Console.WriteLine("{0} - {1}", i, strings[i]);
        }
    }
}