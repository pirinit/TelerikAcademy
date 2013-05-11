using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 15. Write a program that replaces in a HTML document given as string 
 * ll the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL]. 
 * Example:
 * <p>Please visit <a href="http://academy.telerik. com">our site</a> to choose
 * a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
 * Result:
 * <p>Please visit [URL=http://academy.telerik. com]our site[/URL] to choose
 * a training course. Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>
 */
class ReplaceATag
{
    static string ReplaceFirst(string text, string search, string replace, int startIndex)
    {
        int pos = text.IndexOf(search, startIndex);
        if (pos < 0)
        {
            return text;
        }
        return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
    }

    static void Main()
    {
        string input = "<p>Please visit <a href=\"http://academy.telerik. com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";
        string openTag = "<a href=\"";
        string openTagEnd = "\">";
        string closeTag = "</a>";
        string openTagReplace = "[URL=";
        string closeTagReplace = "[/URL]";
        string openTagEndReplace = "]";

        int openTagIndex = 0;
        while((openTagIndex = input.IndexOf(openTag, openTagIndex))>=0)
        {
            input = ReplaceFirst(input, openTag, openTagReplace, openTagIndex);
            input = ReplaceFirst(input, openTagEnd, openTagEndReplace, openTagIndex);
            input = ReplaceFirst(input, closeTag, closeTagReplace, openTagIndex);
        }

        Console.WriteLine(input);
    }
}