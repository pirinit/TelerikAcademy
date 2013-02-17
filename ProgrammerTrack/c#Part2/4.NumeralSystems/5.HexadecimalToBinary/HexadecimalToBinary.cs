using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 5. Write a program to convert hexadecimal numbers to binary numbers (directly).
*/
class HexadecimalToBinary
{
    static string GetHexadecimalToBinary(string hexadecimal)
    {
        hexadecimal = hexadecimal.ToUpper();
        char[] digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        string[] binaryWords = new string[]
        {
            "0000",
            "0001",
            "0010",
            "0011",
            "0100",
            "0101",
            "0110",
            "0111",
            "1000",
            "1001",
            "1010",
            "1011",
            "1100",
            "1101",
            "1110",
            "1111",
        };
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hexadecimal.Length; i++)
        {
            sb.Append(binaryWords[Array.IndexOf(digits, hexadecimal[i])]);
        }

        //uncomment to remove the leading zeros in the binary number
        //while (sb[0] == '0')
        //{
        //    sb.Remove(0, 1);
        //}
        return sb.ToString();
    }

    static void Main()
    {
        string hexadecimal = "1f";
        Console.WriteLine(GetHexadecimalToBinary(hexadecimal));
    }
}