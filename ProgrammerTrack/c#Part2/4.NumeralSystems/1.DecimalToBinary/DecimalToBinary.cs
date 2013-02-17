using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 1. Write a program to convert decimal numbers to their binary representation.
 */
class DecimalToBinary
{
    static string ConvertDecimalToBinary(int number)
    {
        string result = Convert.ToString(number, 2);
        return result;
    }
    static void Main()
    {
        int number = 31123;

        Console.WriteLine(ConvertDecimalToBinary(number));

    }
}
