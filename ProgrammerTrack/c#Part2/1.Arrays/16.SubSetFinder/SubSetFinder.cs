using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 16. * We are given an array of integers and a number S.
* Write a program to find if there exists a subset of
* the elements of the array that has a sum S. Example:
arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6)
*/
class SubSetFinder
{
    static void Main()
    {
        int[] numbers = new int[] { 1, 5, 150, 300, 200, 4, 5, 20, 15, 18, 30, 31, 31, 35, 45, 48, 62, 600, 666721 };
        int sum = 29;
        long combinationsCount = (long)Math.Pow(2, numbers.Length) - 1;
        bool subSetFound = false;

        for (long i = 0; i < combinationsCount; i++)
        {
            int currentSum = 0;
            for (int j = 0; j < numbers.Length; j++)
            {
                if (((i >> j) & 1) == 1)
                {
                    currentSum += numbers[j];
                }
            }
            if (currentSum == sum)
            {
                subSetFound = true;
                Console.Write("The following subset has the sum of {0}.\n(", sum);
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (((i >> j) & 1) == 1)
                    {
                        Console.Write("{0}+", numbers[j]);
                    }
                }
                Console.WriteLine("\x0008}");
            }
        }
        if (!subSetFound)
        {
            Console.WriteLine("There is no subset with the sum of {0}.", sum);
        }
    }
}