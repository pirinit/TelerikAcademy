using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 4. Write a program, that reads from the console an array of N integers
 * and an integer K, sorts the array and using the method Array.BinSearch()
 * finds the largest number in the array which is ≤ K. 
 */
class LargestElementSmallerThanK
{
    static void Main()
    {
        Console.Write("Please enter n = ");
        string input = Console.ReadLine();
        int n = int.Parse(input);
        Console.Write("Please enter k = ");
        input = Console.ReadLine();
        int k = int.Parse(input);
        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            input = Console.ReadLine();
            array[i] = int.Parse(input);
        }

        Array.Sort(array);

        int maxPossitionIndex = Array.BinarySearch(array,k);

        if (maxPossitionIndex < -1)
        {
            Console.WriteLine("The biggest number in the array smaller or equal to {0} is {1}.", k, array[~maxPossitionIndex-1]);
        }
        else if (maxPossitionIndex == -1)
        {
            Console.WriteLine("All numbers in the array are bigger than {0}", k);
        }
        else
        {
            Console.WriteLine("There is number in the array equal to {0}.", k);
        }
    }
}