using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 11.Write a program that reads a number and prints it as a decimal number,
 * hexadecimal number, percentage and in scientific notation.
 * Format the output aligned right in 15 symbols.
 */
class PrintNumber
{
    static void Main()
    {
        string input = Console.ReadLine();
        int n = int.Parse(input);

        Console.WriteLine("Deimal: {0}", n);
        Console.WriteLine("Hexadecimal: {0:X}", n);
        Console.WriteLine("Percentage: {0:P}", n);
        Console.WriteLine("Deimal: {0:e}", n);
    }
}