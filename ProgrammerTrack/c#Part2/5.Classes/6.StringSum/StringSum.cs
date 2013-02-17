using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 6. You are given a sequence of positive integer values written into a string,
 * separated by spaces. Write a function that reads these values from given
 * string and calculates their sum. Example:
   string = "43 68 9 23 318"  result = 461
 */
class StringSum
{
    static int SumsIntsInString(string input)
    {
        string[] inputs = input.Split();
        int sum = 0;
        for (int i = 0; i < inputs.Length; i++)
        {
            sum += int.Parse(inputs[i]);
        }
        return sum;
    }
    static void Main()
    {
        string input = "5454 545 677 22324 454 23 23 5000";
        Console.WriteLine("The sum of the following numbers\n{0}\nis {1}.", input, SumsIntsInString(input));
    }
}
