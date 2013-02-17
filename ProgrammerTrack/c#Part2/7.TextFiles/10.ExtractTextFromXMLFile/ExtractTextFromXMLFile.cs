using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

/* 10. Write a program that extracts from given XML file all the text without the tags. 
 */
class ExtractTextFromXMLFile
{
    static void Main()
    {
        string fileName = "input.txt";
        StreamReader input = new StreamReader(fileName);
        string regExPattern = @">([^<]*)<";

        using (input)
        {
            string currentLine = input.ReadLine();
            while (currentLine != null)
            {
                MatchCollection text = Regex.Matches(currentLine, regExPattern);
                for (int i = 0; i < text.Count; i++)
                {
                    Console.WriteLine(text[i].ToString().Trim('>','<'));
                }
                currentLine = input.ReadLine();
            }
        }
    }
}