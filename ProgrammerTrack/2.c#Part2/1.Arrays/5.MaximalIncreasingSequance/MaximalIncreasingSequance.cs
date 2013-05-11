using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 5. Write a program that finds the maximal increasing sequence
 * in an array. Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.

 */
class MaximalIncreasingSequance
{
    static void Main()
    {
        int[] arr = new int[] { 3, 2, 18, 25, 30, 31, 2, 4, 2, 2, 4 };

        int maxSequenceLength = 1;
        int maxSequenceStartIndex = arr[0];
        int currentSequenceLength = 1;
        int currentSequenceStartIndex = 0;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > arr[i - 1])
            {
                currentSequenceLength++;
            }
            else
            {
                if (currentSequenceLength > maxSequenceLength)
                {
                    maxSequenceLength = currentSequenceLength;
                    maxSequenceStartIndex = currentSequenceStartIndex;
                }
                currentSequenceLength = 1;
                currentSequenceStartIndex = i;
            }
        }

        Console.Write("The longest sequence of increasing elements in:\n{");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(" {0},", arr[i]);
        }
        // using the ascii code of "backspace" to delete the last coma from the for loop.
        Console.Write("\x0008 } \nis: \n{ ");
        for (int i = maxSequenceStartIndex; i < maxSequenceStartIndex + maxSequenceLength; i++)
        {
            // using if statement to determine if we are about to print the last element of the array and prevent the printing of the coma.
            if (i < maxSequenceStartIndex + maxSequenceLength - 1)
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