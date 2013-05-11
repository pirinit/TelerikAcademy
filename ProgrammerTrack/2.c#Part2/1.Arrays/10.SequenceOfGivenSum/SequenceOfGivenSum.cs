using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 10. Write a program that finds in given array of integers
 * a sequence of given sum S (if present).
 * Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}
 */
class SequenceOfGivenSum
{
    static void Main()
    {
        int[] arr = new int[] { 4, 3, 1, 4, 2, 5, 8 };
        int s = 16;
        int sStartIndex = 0;
        int sEndIndex = 0;
        bool sumFound = false;

        for (int i = 0; i < arr.Length; i++)
        {
            int currentSum = 0;
            for (int j = i; j < arr.Length; j++)
            {
                currentSum += arr[j];
                if (currentSum == s)
                {
                    sStartIndex = i;
                    sEndIndex = j;
                    sumFound = true;
                    break;
                }
                if (sumFound)
                {
                    break;
                }
            }
        }
        if (sumFound)
        {
            Console.Write("The first sequence in:\n{");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(" {0},", arr[i]);
            }
            // using the ascii code of "backspace" to delete the last coma from the for loop.
            Console.Write("\x0008 }} \nwhit sum ({0}) is: \n{{ ", s);
            for (int i = sStartIndex; i <= sEndIndex; i++)
            {
                // using if statement to determine if we are about to print the last element of the array and prevent the printing of the coma.
                if (i <= sEndIndex - 1)
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
        else
        {
            Console.WriteLine("No sequence found whit sum of {0}.", s);
        }
    }
}