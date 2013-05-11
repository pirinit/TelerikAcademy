using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 4. Write a program to convert hexadecimal numbers to their decimal representation.
 */
class HexadecimalToDecimal
{
    static int GetHexadecimalToDecimal(string hexadecimal)
    {
        int result = 0;
        hexadecimal = hexadecimal.ToUpper();
        char[] digits = new char[] { '0', '1','2', '3','4','5','6','7','8','9','A','B','C','D','E','F'};
        for (int i = 0; i < hexadecimal.Length; i++)
        {
            result = result << 4;
            result = result + Array.IndexOf(digits, hexadecimal[i]);
        }
        return result;
    }
    static void Main()
    {
        string hexadecimal = "FF";
        Console.WriteLine(GetHexadecimalToDecimal(hexadecimal));
    }
}