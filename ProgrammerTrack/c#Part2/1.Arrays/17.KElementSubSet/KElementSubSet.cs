using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 17. * Write a program that reads three integer numbers N,
* K and S and an array of N elements from the console.
* Find in the array a subset of K elements that have sum S
* or indicate about its absence.
*/
class KElementSubSet
{
    static void Main()
    {
        //int[] numbers = new int[] { 1, 5, 150, 300, 200, 4, 5, 20, 15, 18, 30, 31, 31, 35, 45, 48, 62, 600, 154321, 12000, 300007, 700, 54543, 666721 };
        //int sum = 92;
        Console.Write("Please enter the lenght of the array: ");
        string input = Console.ReadLine();
        int n = int.Parse(input);
        Console.Write("Please enter the needed sum: ");
        input = Console.ReadLine();
        int sum = int.Parse(input);
        Console.Write("Please enter how many elements should contain the subset: ");
        input = Console.ReadLine();
        int k = int.Parse(input);
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("numbers[{0}] = ", i);
            input = Console.ReadLine();
            numbers[i] = int.Parse(input);
        }

        long combinationsCount = (long)Math.Pow(2, numbers.Length) - 1;
        bool subSetFound = false;

        for (long i = 0; i < combinationsCount; i++)
        {
            int currentSum = 0;
            int combinationElements = 0;
            for (int j = 0; j < numbers.Length; j++)
            {
                if (((i >> j) & 1) == 1)
                {
                    currentSum += numbers[j];
                    combinationElements++;
                }
            }
            if (currentSum == sum && combinationElements == k)
            {
                subSetFound = true;
                Console.Write("The following subset has the sum of {0}.\n{{", sum);
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (((i >> j) & 1) == 1)
                    {
                        Console.Write(" {0},", numbers[j]);
                    }
                }
                Console.WriteLine("\x0008 }");
            }
        }
        if (!subSetFound)
        {
            Console.WriteLine("There is no subset with the sum of {0}.", sum);
        }
    }
}