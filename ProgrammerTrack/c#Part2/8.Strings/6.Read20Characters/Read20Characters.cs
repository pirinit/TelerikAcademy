using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 6. Write a program that reads from the console a string of maximum 20 characters.
 * If the length of the string is less than 20, the rest of the characters
 * should be filled with '*'. Print the result string into the console.
 */
class Read20Characters
{
    static void Main()
    {
        string input = null;
        while (input == null || input.Length > 20)
        {
            Console.Write("Please enter some charecters (no more than 20):");
            input = Console.ReadLine();
        }

        input = input + new string('*', 20 - input.Length);
        Console.WriteLine(input);
    }
}