using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 7. Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).
*/
class UniversalNumberConverter
{
    static string FromAnyToAny(string number, int sourceBase, int targetBase)
    {

        string result = FromDecimalToAnyNumeralSystem(ToDecimal(number, sourceBase), targetBase);
        return result;
    }
    static string FromDecimalToAnyNumeralSystem(int number, int b)
    {
        char[] digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        StringBuilder result = new StringBuilder();
        while (number > 0)
        {
            result.Insert(0,digits[number % b]);
            number = number / b;
        }
        return result.ToString();
    }

    static int ToDecimal(string number, int b)
    {
        number = number.ToUpper();
        char[] digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        int result = 0;
        for (int i = 0; i < number.Length; i++)
        {
            result = result * b + Array.IndexOf(digits, number[i]);
        }
        return result;
    }

    static void Main()
    {
        string number = "FFff";
        Console.WriteLine(FromAnyToAny(number, 16, 10));
    }
}