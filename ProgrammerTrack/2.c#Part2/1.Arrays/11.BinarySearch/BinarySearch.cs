using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 11. Write a program that finds the index of given element
 * in a sorted array of integers by using
 * the binary search algorithm (find it in Wikipedia).
 */
class BinarySearch
{
    static int Search(int element, int[] arr)
    {
        int startIndex = 0;
        int endIndex = arr.Length-1;
        int center = startIndex + (endIndex - startIndex) / 2;
        bool elementFound = false;

        while (startIndex < endIndex+1)
        {
            if (arr[center] == element)
            {
                elementFound = true;
                break;
            }
            if (arr[center] < element)
            {
                startIndex = center + 1;
            }
            else
            {
                endIndex = center - 1;
            }
            if (startIndex + 1 == endIndex)
            {
                if (arr[startIndex] == element)
                {
                    elementFound = true;
                    center = startIndex;
                    break;
                }
                if (arr[endIndex] == element)
                {
                    elementFound = true;
                    center = endIndex;
                    break;
                }
            }
            center = startIndex + (endIndex - startIndex) / 2;
        }

        if (elementFound)
        {
            return center;
        }
        else
        {
            return -1;
        }
    }
    static void Main()
    {
        //int[] arr = new int[] { 1, 5, 6, 10, 21, 90, 105, 123, 156, 180, 200 };

        //create 5000 random elements in the array
        int[] arr = new int[5000];
        Random random = new Random();

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = random.Next(i) * random.Next(i);
        }

        Array.Sort(arr);

        // searching for every single element in the array - element exist, so the return value is its index
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(Search(arr[i], arr));
        }

        //searching for non existing element in the array - the return value is -1
        Console.WriteLine(Search(-152, arr));
    }
}