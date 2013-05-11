using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 6. Write a program to convert binary numbers to hexadecimal numbers (directly).
 */
class BinaryToHexadecimal
{
    static string GetBinaryToHexadecimal(string binary)
    {
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
        StringBuilder binarySB = new StringBuilder(binary);
        while (binarySB.Length % 4 != 0)
        {
            binarySB.Insert(0, '0');
        }
        binary = binarySB.ToString();
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < binarySB.Length/4; i = i+4)
        {
            result.Append(digits[Array.IndexOf(binaryWords,binary.Substring(i,4))]);
        }

        return result.ToString();
    }

    static void Main()
    {
        string binary = "1111";
        Console.WriteLine(GetBinaryToHexadecimal(binary));
    }
}