using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 21. Write a program that reads two numbers N and K and generates
* all the combinations of K distinct elements from the set [1..N].
* Example:
* N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3},
* {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}
*/
class Combinations
{
    static int n;
    static int k;

    static void PrintCombination(int[] targetArray)
    {
        Console.Write("{");
        for (int i = 0; i < targetArray.Length; i++)
        {
            Console.Write(" {0},", targetArray[i]);
        }
        Console.WriteLine("\x0008 }");
    }

    static void Combinate(int startIndex, int endIndex, int startNumber, int[] targetArray)
    {
        if (startIndex > endIndex)
        {
            PrintCombination(targetArray);
        }
        else
        {
            for (int i = startNumber; i <= n; i++)
            {
                targetArray[startIndex] = i;
                Combinate(startIndex + 1, endIndex, i+1, targetArray);
            }
        }
    }

    static void Main()
    {
        string input = Console.ReadLine();
        n = int.Parse(input);
        input = Console.ReadLine();
        k = int.Parse(input);

        int[] combination = new int[k];
        Combinate(0, combination.Length - 1, 1, combination);
    }
}