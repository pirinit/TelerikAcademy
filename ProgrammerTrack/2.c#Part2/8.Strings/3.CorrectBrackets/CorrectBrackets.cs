using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 3. Write a program to check if in a given expression the brackets are put correctly.
 * Example of correct expression: ((a+b)/5-d). Example of incorrect expression: )(a+b)).
 */
class CorrectBrackets
{
    static void Main()
    {
        string input = "(kdkdk)(()(ddd(dkdkdk))kdkkd(kdk))";
        int brackets = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                brackets++;
            }
            else if (input[i] == ')')
            {
                brackets--;
            }
            if (brackets < 0)
            {
                break;
            }
        }
        if (brackets != 0)
        {
            Console.WriteLine("Incorrect brackets.");
        }
        else
        {
            Console.WriteLine("Correct brackets.");
        }
    }
}