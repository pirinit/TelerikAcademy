using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 19. * Write a program that reads a number N
 * and generates and prints all the permutations
 * of the numbers [1 … N]. Example:
	n = 3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3},
 * {2, 3, 1}, {3, 1, 2}, {3, 2, 1}
 */
class Permutations
{
    static void Swap(int firstElementIndex, int secondElementIndex, int[] targetArray)
    {
        int temp = targetArray[firstElementIndex];
        targetArray[firstElementIndex] = targetArray[secondElementIndex];
        targetArray[secondElementIndex] = temp;
    }

    static void PrintPermutation(int[] targetArray)
    {
        Console.Write("{");
        for (int i = 1; i < targetArray.Length; i++)
        {
            Console.Write(" {0},", targetArray[i]);
        }
        Console.WriteLine("\x0008 }");
    }

    static void Permutate(int startIndex, int endIndex, int[] targetArray)
    {
        if (startIndex == endIndex)
        {
            PrintPermutation(targetArray);
        }
        else
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                Swap(startIndex, i, targetArray);
                Permutate(startIndex+1, endIndex, targetArray);
                Swap(startIndex, i, targetArray);
            }
        }
    }
    static void Main()
    {
        string input = Console.ReadLine();
        int n = int.Parse(input);
        int[] permutatuions = new int[n+1];

        for (int i = 1; i < permutatuions.Length; i++)
        {
            permutatuions[i] = i;
        }

        Permutate(1, permutatuions.Length-1, permutatuions);
    }
}