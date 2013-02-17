using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/* 1. Write a program that reads a text file and prints on the console its odd lines.
 */
class PrintOddLines
{
    static void Main()
    {
        string fileName = "test.txt";
        StreamReader file = new StreamReader(fileName);
        using (file)
        {
            string currentLine = file.ReadLine();
            while (currentLine != null)
            {
                Console.WriteLine(currentLine);
                file.ReadLine();
                currentLine = file.ReadLine();
            }
        }
    }
}