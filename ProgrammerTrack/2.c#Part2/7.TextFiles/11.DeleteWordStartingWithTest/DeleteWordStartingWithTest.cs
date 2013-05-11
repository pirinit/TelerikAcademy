using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

/* 11. Write a program that deletes from a text file all words that start
 * with the prefix "test". Words contain only the symbols 0...9, a...z, A…Z, _.
 */
class DeleteWordStartingWithTest
{
    static void Main()
    {
        string inputFileName = "input.txt";
        StreamReader input = new StreamReader(inputFileName);
        string regExPattern = @"(\btest)\w+\b";
        string tempText;
        using (input)
        {
            string text = input.ReadToEnd();
            tempText = Regex.Replace(text, regExPattern, "");
        }
        string outputFileName = "output.txt";
        StreamWriter output = new StreamWriter(outputFileName);
        using (output)
        {
            output.Write(tempText);
        }
    }
}