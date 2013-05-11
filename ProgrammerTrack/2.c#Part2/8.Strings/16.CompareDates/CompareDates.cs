using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 16. Write a program that reads two dates in the format: day.month.year
 * and calculates the number of days between them.
 * Example:
 * Enter the first date: 27.02.2006
 * Enter the second date: 3.03.2004
 * Distance: 4 days
 */
class CompareDates
{
    static void Main()
    {
        Console.Write("Enter the first date: ");
        string[] first = Console.ReadLine().Split('.');
        Console.Write("Enter the second date: ");
        string[] second = Console.ReadLine().Split('.');
        DateTime firstDate = new DateTime(int.Parse(first[2]), int.Parse(first[1]), int.Parse(first[0]));
        DateTime secondtDate = new DateTime(int.Parse(second[2]), int.Parse(second[1]), int.Parse(second[0]));

        Console.WriteLine(Math.Abs((firstDate-secondtDate).Days));

        
        
    }
}