using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/* 3. Write a program that reads a text file and inserts line numbers
 * in front of each of its lines. The result should be written to another text file.
 */
class LineNumbers
{
    static void Main()
    {
        string inputFile = "input.txt";
        string outputFile = "output     .txt";
        StreamReader input = new StreamReader(inputFile);
        StreamWriter output = new StreamWriter(outputFile);
        try
        {
            Console.WriteLine("Processing file...");
            string currentLine = input.ReadLine();
            int linenumber = 1;
            while (currentLine != null)
            {
                output.WriteLine("{0} - {1}", linenumber++, currentLine);
                currentLine = input.ReadLine();
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