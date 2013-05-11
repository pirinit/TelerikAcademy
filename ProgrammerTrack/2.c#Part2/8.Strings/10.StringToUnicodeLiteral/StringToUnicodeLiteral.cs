using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 10. Write a program that converts a string to a sequence of C#
 * Unicode character literals. Use format strings. Sample input:
 * Hi!
 * Expected output:
 * \u0048\u0069\u0021
 */
class StringToUnicodeLiteral
{
    static void Main()
    {
        string input = "Hi!";
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            result.AppendFormat("\\u{0:X4}", (int)input[i]);
        }

        Console.WriteLine(result);
    }
}