using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/* 9. Write a program that deletes from given text file all odd lines. The result should be in the same file.
 */
class DeleteOddLinesInFile
{
    static void Main()
    {
        string fileName = "input.txt";
        StreamReader input = new StreamReader(fileName);
        List<string> evenLines = new List<string>();

        using (input)
        {
            input.ReadLine();
            string currentLine = input.ReadLine();
            while (currentLine != null)
            {
                evenLines.Add(currentLine);
                input.ReadLine();
                currentLine = input.ReadLine();
            }
        }

        StreamWriter output = new StreamWriter(fileName);
        using (output)
        {
            for (int i = 0; i < evenLines.Count; i++)
            {
                output.WriteLine(evenLines[i]);
            }
        }
    }
}