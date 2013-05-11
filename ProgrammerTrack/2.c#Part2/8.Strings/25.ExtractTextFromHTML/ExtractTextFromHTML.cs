using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/* 25. Write a program that extracts from given HTML file its title (if available),
 * and its body text without the HTML tags.
 */
class ExtractTextFromHTML
{
    static string ExtractHTMLTagContent(string s, string tag)
    {
        var startTag = "<" + tag + ">";
        int startIndex = s.IndexOf(startTag) + startTag.Length;
        int endIndex = s.IndexOf("</" + tag + ">", startIndex);
        return s.Substring(startIndex, endIndex - startIndex);
    }

    static void Main()
    {
        string html = @"<html>
  <head><title>News</title></head>
  <body><p><a href=""http://academy.telerik.com"">Telerik
    Academy</a>aims to provide free real-world practical
    training for young people who want to turn into
    skillful .NET software engineers.</p></body>
</html>";

        string title = ExtractHTMLTagContent(html, "title");
        string body = ExtractHTMLTagContent(html, "body");
        string bodyText = Regex.Replace(body, "<(.*?)>", "");

        Console.WriteLine(title);
        //Console.WriteLine(body);
        Console.WriteLine(bodyText);
    }
}