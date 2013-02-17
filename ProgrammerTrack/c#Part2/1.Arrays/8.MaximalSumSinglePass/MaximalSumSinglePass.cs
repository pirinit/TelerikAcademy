using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 8. Write a program that finds the sequence of maximal sum in given array. Example:
{2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
Can you do it with only one loop (with single scan through the elements of the array)?
*/
class MaximalSumSinglePass
{
    static void Main()
    {

        int[] arr = new int[] { 2, 3, -6, -1, 88, -1, 6, 4, -12, 8, 4, 1 };

        int sequenceMaxSum = int.MinValue;
        int sequenceStartIndex = 0;
        int sequenceEndIndex = 0;
        int currentSequenceSum = 0;
        int currentSequenceStarIndex = 0;
        int currentSequenceEndIndex = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            currentSequenceSum += arr[i];
            currentSequenceEndIndex = i;
            if (currentSequenceSum > sequenceMaxSum)
            {
                sequenceMaxSum = currentSequenceSum;
                sequenceStartIndex = currentSequenceStarIndex;
                sequenceEndIndex = currentSequenceEndIndex;
            }
            if (currentSequenceSum < 0)
            {
                currentSequenceSum = 0;
                currentSequenceStarIndex = i+1;
                currentSequenceStarIndex = i+1;
            }
        }

        Console.Write("The maximal sequence in:\n{");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(" {0},", arr[i]);
        }
        // using the ascii code of "backspace" to delete the last coma from the for loop.
        Console.Write("\x0008 }} \nwhit maximal sum ({0}) is: \n{{ ", sequenceMaxSum);
        for (int i = sequenceStartIndex; i <= sequenceEndIndex; i++)
        {
            // using if statement to determine if we are about to print the last element of the array and prevent the printing of the coma.
            if (i <= sequenceEndIndex - 1)
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