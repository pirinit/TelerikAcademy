using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 12. Write a program that creates an array containing all letters
 * from the alphabet (A-Z). Read a word from the console
 * and print the index of each of its letters in the array.
 */
class AlphabetLetters
{
    static void Main()
    {
        char[] chars = new char[26];

        for (short i = 0; i < chars.Length; i++)
        {
            chars[i] = (char)('A' + i);
        }

        Console.Write("Please enter a string (capital letters only): ");
        string input = Console.ReadLine();
        input = input.ToUpper();
        for (int i = 0; i < input.Length; i++)
        {
            Console.WriteLine("The index of {0} is {1}.", input[i], Array.IndexOf(chars, input[i]));
        }
    }
}