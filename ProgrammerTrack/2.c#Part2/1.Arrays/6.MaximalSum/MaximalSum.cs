using System;
using System.Linq;

/* 6. Write a program that reads two integer numbers N and K
* and an array of N elements from the console.
* Find in the array those K elements that have maximal sum.

*/
class MaximalSum
{
    static void Main()
    {
        Console.Write("Please enter the length or array n = ");
        string input = Console.ReadLine();
        int n = int.Parse(input);
        Console.Write("Please enter the length or subarray k = ");
        input = Console.ReadLine();
        int k = int.Parse(input);

        int[] arr = new int[n];
        //int[] arr = new int[] { 3, 2, 18, 25, 30, 31, 2, 4, 2, 2, 4, 50, 50, 50 };

        for (int i = 0; i < n; i++)
        {
            Console.Write("arr[{0}] = ", i);
            input = Console.ReadLine();
            arr[i] = int.Parse(input);
        }

        int maxSequenceSum = int.MinValue;
        int maxSequenceStartIndex = 0;
        int currentSequenceSum;
        int currentSequenceStartIndex;

        for (int i = 0; i <= arr.Length - k; i++)
        {
            currentSequenceStartIndex = i;
            currentSequenceSum = 0;
            for (int j = i; j < i + k; j++)
            {
                currentSequenceStartIndex = i;
                currentSequenceSum += arr[j];
            }
            if (currentSequenceSum > maxSequenceSum)
            {
                maxSequenceSum = currentSequenceSum;
                maxSequenceStartIndex = currentSequenceStartIndex;
            }
        }

        Console.Write("The sequence with {0} elements in:\n{{", k);
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(" {0},", arr[i]);
        }
        // using the ascii code of "backspace" to delete the last coma from the for loop.
        Console.Write("\x0008 }} \nwhit maximal sum ({0}) is: \n{{ ", maxSequenceSum);
        for (int i = maxSequenceStartIndex; i < maxSequenceStartIndex + k; i++)
        {
            // using if statement to determine if we are about to print the last element of the array and prevent the printing of the coma.
            if (i < maxSequenceStartIndex + k - 1)
            {
                Console.Write("{0}, ", arr[i]);
            }
            else
            {
                Console.Write("{0} ", arr[i]);
                Console.WriteLine("}");
            }
        }
    }
}