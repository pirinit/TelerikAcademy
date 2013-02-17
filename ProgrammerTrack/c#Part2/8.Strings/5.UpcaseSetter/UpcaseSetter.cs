using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 5. You are given a text. Write a program that changes the text in all regions
 * surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested.
 */
class UpcaseSetter
{
    static void Main()
    {
        string input = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        string startTag = "<upcase>";
        string endTag = "</upcase>";

        int startIndex = 0;
        int endIndex = 0;
        StringBuilder result = new StringBuilder();

        while((startIndex = input.IndexOf(startTag,0))>0 && (endIndex = input.IndexOf(endTag,0))>0)
        {
            result.Append(input.Substring(0, startIndex));
            result.Append(input.Substring(startIndex + startTag.Length, endIndex - (startIndex + startTag.Length)).ToUpper());
            input = input.Remove(0, endIndex + endTag.Length);
        }
        result.Append(input);
        Console.WriteLine(result);
    }
}