using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 18. * Write a program that reads an array of integers
* and removes from it a minimal number of elements
* in such way that the remaining array
* is sorted in increasing order.
* Print the remaining sorted array. Example:
{6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}
*/
class ArrayIncreasingOrder
{
    static int IncreasingElementsInArray(int[] arr, long numbersMask)
    {
        int numberOfElements = 0;
        int lastNumber = int.MinValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (((numbersMask >> i) & 1) == 1)
            {
                if (arr[i] < lastNumber)
                {
                    numberOfElements = -1;
                    break;
                }
                lastNumber = arr[i];
                numberOfElements++;
            }
        }
        return numberOfElements;
    }

    static void Main()
    {
        int[] numbers = new int[] { 6, 1, 4, 9, 2, 4, 4, 4, 4, 0, 3, 6, 4, 5 };

        //Console.Write("Please enter the lenght of the array: ");
        //string input = Console.ReadLine();
        //int n = int.Parse(input);
        //int[] numbers = new int[n];
        //for (int i = 0; i < n; i++)
        //{
        //    Console.Write("numbers[{0}] = ", i);
        //    input = Console.ReadLine();
        //    numbers[i] = int.Parse(input);
        //}

        long combinationsCount = (long)Math.Pow(2, numbers.Length) - 1;
        int maxNumberOfElements = 0;
        long maxNumberOfElementsMask = 0;

        for (long i = 0; i < combinationsCount; i++)
        {
            int currentNumberOfElements = IncreasingElementsInArray(numbers, i);
            if (currentNumberOfElements > maxNumberOfElements)
            {
                maxNumberOfElementsMask = i;
                maxNumberOfElements = currentNumberOfElements;
            }
        }
        Console.Write("The remaining sorted array is:\n{");
        for (int j = 0; j < numbers.Length; j++)
        {
            if (((maxNumberOfElementsMask >> j) & 1) == 1)
            {
                Console.Write(" {0},", numbers[j]);
            }
        }
        Console.WriteLine("\x0008 }");
    }
}