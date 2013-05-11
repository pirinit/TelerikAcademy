using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

/* 17. Write a program that reads a date and time given in the format:
* day.month.year hour:minute:second and prints the date and time after
* 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.
*/
class ParseDate
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        while (true)
        {
            try
            {
                string input = Console.ReadLine(); // "30.06.1982 06:15:00";
                DateTime moment = DateTime.ParseExact(input, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                moment = moment.AddHours(6).AddMinutes(30);

                Console.WriteLine("{0:d.MM.yyyy HH:mm:ss}", moment);
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
                Console.WriteLine("{0:dddd}", moment);
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong date and time format, should be: dd.MM.yyyy HH:mm:ss.");
            }
        }
    }
}