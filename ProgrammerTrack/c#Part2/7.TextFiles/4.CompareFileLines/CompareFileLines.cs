using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/* 4. Write a program that compares two text files line by line
* and prints the number of lines that are the same and the number
* of lines that are different. Assume the files have equal number of lines.
*/
class CompareFileLines
{
    static void Main()
    {
        string firstFile = "first.txt";
        string secondFile = "second.txt";

        StreamReader first = new StreamReader(firstFile);
        StreamReader second = new StreamReader(secondFile);

        try
        {
            string line = first.ReadLine();
            string otherLine = second.ReadLine();
            int equalLines = 0;
            int differentLines = 0;
            while (line != null)
            {
                if (line == otherLine)
                {
                    equalLines++;
                }
                else
                {
                    differentLines++;
                }
                line = first.ReadLine();
                otherLine = second.ReadLine();
            }

            Console.WriteLine("The number of matching lines is {0}.\nThe number of different lines is {1}.", equalLines, differentLines);
        }
        finally
        {
            first.Dispose();
            second.Dispose();
            Console.WriteLine("Done!");
        }
    }
}