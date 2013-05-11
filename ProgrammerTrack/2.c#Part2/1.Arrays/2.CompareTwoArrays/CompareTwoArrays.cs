using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 2. Write a program that reads two arrays from the
 * console and compares them element by element.
 */
class CompareTwoArrays
{
    static void Main()
    {
        Console.Write("Please enter the size of the arrays: ");
        string input = Console.ReadLine();
        int n = int.Parse(input);
        int[] arr1 = new int[n];
        int[] arr2 = new int[n];

        Console.WriteLine("Please enter the first array's elements...");
        for (int i = 0; i < n; i++)
        {
            Console.Write("arr1[{0}] = ", i);
            input = Console.ReadLine();
            arr1[i] = int.Parse(input);
        }

        Console.WriteLine("Please enter the second array's elements...");
        for (int i = 0; i < n; i++)
        {
            Console.Write("arr2[{0}] = ", i);
            input = Console.ReadLine();
            arr2[i] = int.Parse(input);
        }
        Console.WriteLine("Comparing the two arrays...");

        bool areEqual = true;
        for (int i = 0; i < n; i++)
        {
            if (arr1[i] != arr2[i])
            {
                areEqual = false;
                break;
            }
        }
        if (areEqual)
        {
            Console.WriteLine("The two arrays are EQUAL.");
        }
        else
        {
            Console.WriteLine("The two arrays are NOT EQUAL.");
        }
    }
}