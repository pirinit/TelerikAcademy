using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 1. Implement an extension method Substring(int index, int length)
 * for the class StringBuilder that returns new StringBuilder
 * and has the same functionality as Substring in the class String.
 */
public static class Extensions
{
    public static StringBuilder Substring(this StringBuilder builder, int index, int length)
    {
        StringBuilder result = new StringBuilder(length);
        int endIndex = index + length;
        for (int i = index; i < endIndex; i++)
        {
            result.Append(builder[i]);
        }
        return result;
    }
}

class ExtendStringBuilderSubstring
{
    

    static void Main()
    {
        StringBuilder test = new StringBuilder("alalalal csd vc df v dfs fsdf v dsfv");
        Console.WriteLine(test.Substring(5, 10));
    }
}