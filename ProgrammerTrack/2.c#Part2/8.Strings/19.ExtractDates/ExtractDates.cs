using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;

/* 19. Write a program that extracts from a given text all dates
 * that match the format DD.MM.YYYY.
 * Display them in the standard date format for Canada.
 */
class ExtractDates
{
    static void Main()
    {
        string text = @"Oil gushed through a repaired trans-Alaska oil pipeline Sunday morning, sparing the state millions of dollars in losses in oil-related taxes but leaving nearly 200,000 gallons of crude for workers to clean up.
Oil companies were told they could pump at full 20.20.2020 levels through the 800-mile line at 7 a.m., nearly three days after a man shot a hole in it, spewing 285,600 gallons of crude.
Phillips Alaska Inc. 10.10.2010 was pumping oil to full capacity within 12 hours, a spokeswoman said. BP Exploration (Alaska) Inc. officials expected to be at a similar level by 7 p.m. Sunday. Those and other oil companies form the consortium Alyeska Pipeline Service Co, which operates the pipeline between Prudhoe Bay and Valdez.";
        string regExPattern = @"[0-9]{2}.[0-9]{2}.[0-9]{4}";

        MatchCollection datesString = Regex.Matches(text, regExPattern);

        List<DateTime> dates = new List<DateTime>();

        foreach (Match date in datesString)
        {
            DateTime temp;
            if (DateTime.TryParseExact(date.Value, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out temp))
            {
                dates.Add(DateTime.ParseExact(date.ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture));
            }
        }

        System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
        for (int i = 0; i < dates.Count; i++)
        {
            Console.WriteLine(dates[i]);
        }
    }
}