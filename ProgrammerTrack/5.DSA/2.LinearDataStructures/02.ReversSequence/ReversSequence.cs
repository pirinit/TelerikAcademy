using System;
using System.Collections.Generic;

/* 2. Write a program that reads N integers from the console
 * and reverses them using a stack. Use the Stack<int> class.
 */

public class ReversSequence
{
    public static void Main()
    {
        Console.Write("Please enter numbers count: ");
        string input = Console.ReadLine();
        int n = int.Parse(input);
        Stack<int> numbers = new Stack<int>();

        Console.WriteLine("Please enter {0} numbers on a separeta line:", n);
        for (int i = 0; i < n; i++)
        {
            input = Console.ReadLine();
            int currentNumber = int.Parse(input);
            numbers.Push(currentNumber);
        }

        Console.WriteLine("Reversed numbers are:");
        while (numbers.Count > 0)
        {
            Console.WriteLine(numbers.Pop());
        }
    }
}