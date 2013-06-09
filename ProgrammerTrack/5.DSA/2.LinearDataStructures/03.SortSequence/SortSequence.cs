using System;
using System.Collections.Generic;

/* 3. Write a program that reads a sequence of integers (List<int>)
 * ending with an empty line and sorts them in an increasing order.
 */

public class SortSequence
{
    public static void Main()
    {
        List<int> numbers = ReadList();

        //numbers.Sort();
        numbers.Sort((a, b) => a.CompareTo(b));

        PrintList(numbers);
    }

    private static void PrintList(List<int> numbers)
    {
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }
    }

    private static List<int> ReadList()
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a sequence of integers. To exit enter empty line.");
        string input = Console.ReadLine();

        while (input != String.Empty)
        {
            int number = 0;
            bool isNumber = int.TryParse(input, out number);

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

        return numbers;
    }
}