using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 20. Write a program that reads two numbers N and K and
 * generates all the variations of K elements from the set [1..N].
 * Example:
 * N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1},
 * {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}
 */
class Variations
{
    static int n;
    static int k;

    static void PrintVariation(int[] targetArray)
    {
        Console.Write("{");
        for (int i = 0; i < targetArray.Length; i++)
        {
            Console.Write(" {0},", targetArray[i]);
        }
        Console.WriteLine("\x0008 }");
    }

    static void Variate(int startIndex, int endIndex, int[] targetArray)
    {
        if (startIndex > endIndex)
        {
            PrintVariation(targetArray);
        }
        else
        {
            for (int i = 1; i <= n; i++)
            {
                targetArray[startIndex] = i;
                Variate(startIndex + 1, endIndex, targetArray);
            }
        }
    }
    static void Main()
    {
        string input = Console.ReadLine();
        n = int.Parse(input);
        input = Console.ReadLine();
        k = int.Parse(input);

        int[] variation = new int[k];
        Variate(0, variation.Length - 1, variation);

    }
}