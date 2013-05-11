using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 7. Write a method that reverses the digits of given decimal number. Example: 256  652
*/
class ReverseDigits
{
    static decimal GetReverseDigits(decimal number)
    {
        decimal result = 0;
        while (number > 0)
        {
            result = result * 10 + number % 10;
            number = (int) (number / 10);
        }
        return result;
    }

    static void Main()
    {
        decimal n = -987654321;
        Console.WriteLine("The reverse of\n{0}\nis\n{1}", n, GetReverseDigits(n));
    }
}