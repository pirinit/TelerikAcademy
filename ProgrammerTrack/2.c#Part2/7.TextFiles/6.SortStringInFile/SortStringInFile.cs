using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/* 6. Write a program that reads a text file containing a list
 * of strings, sorts them and saves them to another text file.
 */
class SortStringInFile
{
    static void Main()
    {
        string inputFileName = "input.txt";
        string outputFileName = "output.txt";
        StreamReader input = new StreamReader(inputFileName);
        StreamWriter output = new StreamWriter(outputFileName);

        try
        {
            List<string> lines = new List<string>();
            string line = input.ReadLine();
            while (line != null)
            {
                lines.Add(line);
                line = input.ReadLine();
            }

            lines.Sort();

            for (int i = 0; i < lines.Count; i++)
            {
                output.WriteLine(lines[i]);
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