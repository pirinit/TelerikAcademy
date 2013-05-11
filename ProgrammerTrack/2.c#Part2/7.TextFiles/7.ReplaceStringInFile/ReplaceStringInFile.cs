using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/* 7. Write a program that replaces all occurrences of the substring "start"
 * with the substring "finish" in a text file. Ensure it will work with large files (e.g. 100 MB).
 */
class ReplaceStringInFile
{
    static void Main()
    {
        string inputFileName = "input.txt";
        string outputFileName = "output.txt";
        StreamReader input = new StreamReader(inputFileName);
        StreamWriter output = new StreamWriter(outputFileName);
        string searchFor = "start";
        string replaceWith = "finish";

        try
        {
            string line = input.ReadLine();
            while (line != null)
            {
                string result = line.Replace(searchFor, replaceWith);
                output.WriteLine(result);
                line = input.ReadLine();
            }
        }
        finally
        {
            input.Dispose();
            output.Dispose();
            Console.WriteLine("Done!");
        }
    }
}