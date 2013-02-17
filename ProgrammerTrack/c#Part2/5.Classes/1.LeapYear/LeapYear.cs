using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 1. Write a program that reads a year from the console
 * and checks whether it is a leap. Use DateTime.
 */
class LeapYear
{
    static void Main()
    {
        Console.Write("Please enter year: ");
        string input = Console.ReadLine();
        int year = int.Parse(input);
        if (DateTime.IsLeapYear(year))
        {
            Console.WriteLine("{0} is leap year.", year);
        }
        else
        {
            Console.WriteLine("{0} isn't leap year.", year);
        }
    }
}