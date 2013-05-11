using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 5. Write a method that calculates the number of workdays between today
* and given date, passed as parameter. Consider that workdays are all days
* from Monday to Friday except a fixed list of public holidays
* specified preliminary as array.
*/
class WorkDays
{
    static int WorkDaysCount(DateTime endDate, DateTime[] holidays)
    {
        int workDays = 0;
        DateTime temp = DateTime.Today;
        while (temp < endDate)
        {
            if (IsWorkDay(temp, holidays) &&
                temp.DayOfWeek != DayOfWeek.Sunday &&
                temp.DayOfWeek != DayOfWeek.Saturday)
            {
                workDays++;
            }
            temp = temp.AddDays(1);
        }
        return workDays;
    }

    static bool IsWorkDay(DateTime date, DateTime[] holidays)
    {
        foreach (var holiday in holidays)
        {
            if (date.Equals(holiday))
            {
                return false;
            }
        }
        return true;
    }

    static void Main()
    {
        DateTime[] holidays = new DateTime[]
        {
            new DateTime(2013,1,24),
            new DateTime(2013,1,25),
        };
        DateTime endDate = new DateTime(2013,1,31);
        Console.WriteLine(WorkDaysCount(endDate, holidays));
    }
}