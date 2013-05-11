using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 2. Write a program that reads a string, reverses it and prints the result at the console. 
 * Example: "sample"  "elpmas".
 */
class ReverseString
{
    static void Main()
    {
        Console.Write("Please enter some text: ");
        string input = Console.ReadLine();
        StringBuilder reversed = new StringBuilder();
        for (int i = input.Length - 1; i >= 0 ; i--)
        {
            reversed.Append(input[i]);
        }
        Console.WriteLine("Reversed text is: {0}", reversed);
    }
}