using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 4. Write a program that finds how many times a substring is
 * contained in a given text (perform case insensitive search).
 */
class SubstringFrequency
{
    static void Main()
    {
        string input = @"We are living in an yellow submarine.
We don't have anything else. Inside the submarine is very tight.
So we are drinking all the day. We will move out of it in 5 days. When the alcohol is over!";
        string substring = "in";

        int substringFrequency = 0;
        int index = -1;
        while ((index = input.IndexOf(substring, index+1, StringComparison.OrdinalIgnoreCase)) > 0)
        {
            substringFrequency++;
        }

        Console.WriteLine("{0} occurs {1} times in:\n{2}",substring, substringFrequency, input);
    }
}