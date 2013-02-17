using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 13. * Write a program that sorts an array of integers
 * using the merge sort algorithm (find it in Wikipedia).
 */
class MergeSort
{
    static int[] Merge(int[] left, int[] right)
    {
        int[] result = new int[left.Length + right.Length];

        int leftIndex = 0;
        int rightIndex = 0;
        for (int i = 0; i < result.Length; i++)
        {
            if (leftIndex < left.Length && rightIndex < right.Length)
            {
                int nextElement = 0;
                if(left[leftIndex]<right[rightIndex])
                {
                    nextElement = left[leftIndex++];
                }
                else
                {
                    nextElement = right[rightIndex++];
                }
                result[i] = nextElement;
                continue;
            }
            if (leftIndex == left.Length && rightIndex < right.Length)
            {
                result[i] = right[rightIndex++];
                continue;
            }
            if (leftIndex < left.Length && rightIndex == right.Length)
            {
                result[i] = left[leftIndex++];
                continue;
            }
        }
        return result;
    }

    static int[] Sort(int[] arr)
    {
        if (arr.Length <= 1)
        {
            return arr;
        }
        int center = arr.Length/2;
        int[] left = new int[center];
        int[] right = new int[arr.Length - center];
        int leftIndex = 0;
        int rightIndex = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (i < center)
            {
                left[leftIndex++] = arr[i];
            }
            else
            {
                right[rightIndex++] = arr[i];
            }
        }
        left = Sort(left);
        right = Sort(right);
        return Merge(left, right);
    }
    static void Main()
    {
        int[] arr = new int[] { 1, 2, 5, 10, 90, 10004, -555664, 15, 333, 17, 200, 89, 555050, 10, 10, 0, 0, 0, -3};

        arr = Sort(arr);

        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(arr[i]);
        }
    }
}