using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 4. Write a program that finds the maximal sequence of equal elements in an array.
		Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.
 */
class MaximalSequence
{
    static void Main()
    {
        int[] arr = new int[] { 1, 5, 5, 5, 5, 88, 88, 88, 1, 1, 3, 3, 3, 3, 3, 3, 7};

        int maxSequenceLength = 1;
        int maxSequenceNumber = arr[0];
        int currentSequenceLength = 1;
        int currentSequenceNumber = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1])
            {
                currentSequenceLength++;
            }
            else
            {
                if (currentSequenceLength > maxSequenceLength)
                {
                    maxSequenceLength = currentSequenceLength;
                    maxSequenceNumber = currentSequenceNumber;
                }
                currentSequenceLength = 1;
                currentSequenceNumber = arr[i];
            }
        }

        Console.Write("The longest sequence of equal elements in:\n{");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(" {0},", arr[i]);
        }
        // using the ascii code of "backspace" to delete the last coma from the for loop.
        Console.Write("\x0008 } \nis: \n{ ");
        for (int i = 0; i < maxSequenceLength; i++)
        {
            // using if statement to determine if we are about to print the last element of the array and prevent the printing of the coma.
            if (i < maxSequenceLength - 1)
            {
                Console.Write("{0}, ", maxSequenceNumber);
            }
            else
            {
                Console.Write("{0} ", maxSequenceNumber);
                Console.WriteLine("}");
            }
        }
        
    }
}