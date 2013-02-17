using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 3. Write a program that prints to the console which
 * day of the week is today. Use System.DateTime.
 */
class PrintDayOfWeek
{
    static void Main()
    {
        Console.WriteLine("Today is {0}.", DateTime.Now.DayOfWeek);
    }
}