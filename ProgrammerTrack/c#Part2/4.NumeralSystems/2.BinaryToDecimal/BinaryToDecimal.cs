using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 2.Write a program to convert binary numbers to their decimal representation.
*/
class BinaryToDecimal
{
    static int GetBinaryToDecimal(string binary)
    {
        int result = 0;
        for (int i = 0; i < binary.Length; i++)
        {
            result = result << 1;
            if (binary[i] == '1')
            {
                result++;
            }
        }
        return result;
    }

    static void Main()
    {
        string binary = "1000";
        Console.WriteLine(GetBinaryToDecimal(binary));
    }
}