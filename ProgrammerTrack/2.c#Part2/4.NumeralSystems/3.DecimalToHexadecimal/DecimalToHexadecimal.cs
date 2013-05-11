using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 3. Write a program to convert decimal numbers to their hexadecimal representation.
 */
class DecimalToHexadecimal
{
    static string GetDecimalToHexadecimal(int number)
    {
        char[] digits = new char[] { '0', '1','2', '3','4','5','6','7','8','9','A','B','C','D','E','F'};
        StringBuilder sb = new StringBuilder();
        while (number > 0)
        {
            sb.Insert(0, digits[number % 16]);
            number = number / 16;
        }
        return sb.ToString();
    }
    static void Main()
    {
        int number = 31;
        Console.WriteLine(GetDecimalToHexadecimal(number));
    }
}