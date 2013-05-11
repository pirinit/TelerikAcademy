using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/* 18. Write a program for extracting all email addresses from given text.
 * All substrings that match the format <identifier>@<host>…<domain>
 * should be recognized as emails.
 */
class ExtractEmails
{
    static void Main()
    {
        string text = @"Drivers on official business near Point@bestdrugs.edu Woronzof will be allowed to pass through a checkpoint on Northern Lights Boulevard at Postmark Drive, Plumb said. That includes, for instance, Anchorage Water & Wastewater Utility workers. The checkpoint may move back to Boeing Drive in 36 hours, Plumb said.
Bikers and runners may still visit Point Woronzof on the Tony Knowles Coastal Trail.
Also Sunday, the airport@klsjdflksjdf,fffff began sear@ching.com the 15 to 30 small aircraft and 200 or so cars and trucks that pass from the less secure general aviation area outside the airport's fence to the main part of the airport.
It will usually take two to seven minutes for each car or plane to be inspected, though in some cases it could take longer if security officers see something suspicious, Plumb said.
City officials took less noticeable action Sunday. City Manager Harry Kieling and Emergency@office.bg Operations Manager Tracy Matthews met in the city's Emergency Operations Center half an hour after learning of the strikes in Afghanistan.";

        string regExPattern = @"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b";

        MatchCollection addresses = Regex.Matches(text, regExPattern, RegexOptions.IgnoreCase);

        foreach (var address in addresses)
        {
            Console.WriteLine(address.ToString());
        }
    }
}