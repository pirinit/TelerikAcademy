using System;
using System.Collections.Generic;

/* 1. Write a program that reads from the console a sequence of positive integer numbers.
 * The sequence ends when empty line is entered. Calculate and print the sum and average
 * of the elements of the sequence. Keep the sequence in List<int>.
 */

public class ReadSequence
{
    public static void Main()
    {
        List<uint> numbers = new List<uint>();

        Console.WriteLine("Enter a sequence of positive integers. To exit enter empty line.");
        string input = Console.ReadLine();

        while (input != String.Empty)
        {
            uint number = 0;
            bool isNumber = uint.TryParse(input, out number);

            if (isNumber)
            {
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine("Please enter a positive integer number.");
            }

            input = Console.ReadLine();
        }

        ulong sum = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
        }


        if (numbers.Count > 0)
        {
            Console.WriteLine("The sum of all numbers is {0}.", sum);
            Console.WriteLine("The count of the numbers is {0} and average number is {1}.", numbers.Count, (double)sum / numbers.Count);
        }
        else
        {
            Console.WriteLine("No valid numbers are entered");
        }
    }
}
