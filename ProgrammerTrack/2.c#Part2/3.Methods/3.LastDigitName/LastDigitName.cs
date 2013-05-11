using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 3. Write a method that returns the last digit of given integer
 * as an English word. Examples: 512  "two", 1024  "four", 12309  "nine".
 */
class LastDigitName
{
    static string GetLastDigitName(int n)
    {
        string[] digits = new string[]
        {
            "Zero", "One", "Two", "Three", "Four", "Five",
            "Six", "Seven", "Eight", "Nine"
        };
        return digits[n%10];
    }
    static void Main()
    {
        int n = 5450;
        Console.WriteLine("The last digit of {0} is {1}.", n, GetLastDigitName(n));
    }
}