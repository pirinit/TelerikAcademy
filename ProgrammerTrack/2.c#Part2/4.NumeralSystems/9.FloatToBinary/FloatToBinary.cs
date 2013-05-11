using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 9. * Write a program that shows the internal binary representation of given 32-bit
 * signed floating-point number in IEEE 754 format (the C# type float).
 * Example: -27,25  sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.
 */
class FloatToBinary
{
    static string ByteToBinary(int number)
    {
        StringBuilder result = new StringBuilder();
        while (number > 0)
        {
            result.Insert(0, number % 2);
            number = number / 2;
        }
        while (result.Length < 8)
        {
            result.Insert(0, "0");
        }
        return result.ToString();
    }
    static string GetFloatToBinary(float number)
    {
        StringBuilder result = new StringBuilder();
        byte[] bytes = BitConverter.GetBytes(number);
        for (int i = bytes.Length-1; i >= 0; i--)
        {
            result.Append(ByteToBinary(bytes[i]));
        }
        result.Insert(1, " ");
        result.Insert(10, " ");
        return result.ToString();
    }
    static void Main()
    {
        float number = -27.25f;
        Console.WriteLine(GetFloatToBinary(number));
    }
}