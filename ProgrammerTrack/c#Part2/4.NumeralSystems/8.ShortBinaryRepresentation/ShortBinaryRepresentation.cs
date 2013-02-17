using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 8. Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).
 */
class ShortBinaryRepresentation
{
    static string ShortToBinary(short number)
    {
        char[] result = new char[16];
        for (int i = 0; i < 16; i++)
        {
            if (((number>>i) & 1) == 1)
            {
                result[15-i] = '1';
            }
            else
            {
                result[15 - i] = '0';
            }
        }
        return new string(result);
    }
    static void Main()
    {
        short number = short.MinValue;
        Console.WriteLine(ShortToBinary(number));
    }
}