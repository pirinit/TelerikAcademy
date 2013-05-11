using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 23. Write a program that reads a string from the console and replaces all series
* of consecutive identical letters with a single one.
* Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".
*/
class ReplaceConsecutiveLetters
{
    static void Main()
    {
        string text = "aaa    !aabb!bbbcd!ddeeeedssaaaaaa";

        StringBuilder result = new StringBuilder(text.Length);

        char previous = text[0];

        for (int i = 1; i < text.Length; i++)
        {
            if ((previous >= 'A' && previous <= 'Z') || (previous >= 'a' && previous <= 'z'))
            {
                if (previous != text[i])
                {
                    result.Append(previous);
                    previous = text[i];
                }
            }
            else
            {
                result.Append(previous);
                previous = text[i];
            }
        }
        
        result.Append(text[text.Length - 1]);

        Console.WriteLine(result);
    }
}