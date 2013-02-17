using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/* 2. Write a program that concatenates two text files into another text file.
 */
class ConcatenateTextFiles
{
    static void Main()
    {
        string firstFile = "first.txt";
        string secondFile = "second.txt";
        string resultFile = "result.txt";

        StreamReader first = new StreamReader(firstFile);
        StreamReader second = new StreamReader(secondFile);

        StreamWriter result = new StreamWriter(resultFile);

        try
        {
            Console.WriteLine("Reading first's file content...");
            string content = first.ReadToEnd();
            Console.WriteLine("Writing to result.txt...");
            result.WriteLine(content);
            Console.WriteLine("Reading second's file content...");
            content = second.ReadToEnd();
            Console.WriteLine("Writing to result.txt...");
            result.WriteLine(content);
        }
        finally
        {
            first.Dispose();
            second.Dispose();
            result.Dispose();
            Console.WriteLine("Done!");
        }
    }
}