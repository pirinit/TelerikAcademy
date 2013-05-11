using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 7. Sorting an array means to arrange its elements in increasing order.
* Write a program to sort an array. Use the "selection sort" algorithm:
* Find the smallest element, move it at the first position,
* find the smallest from the rest, move it at the second position, etc.
*/
class SelectionSort
{
    static void Main()
    {
        int[] arr = new int[] { 3, 90, 18, 25, 30, 31, 2, 4, 2, 2, 4 };

        for (int i = 0; i < arr.Length; i++)
        {
            int minElementIndex = arr.Length - 1;
            for (int j = arr.Length - 1; j >= i; j--)
            {
                if (arr[j] < arr[minElementIndex])
                {
                    minElementIndex = j;
                }
            }

            int temp = arr[i];
            arr[i] = arr[minElementIndex];
            arr[minElementIndex] = temp;

            Console.WriteLine("Pass {0}, temp result is: ", i + 1);
            for (int j = 0; j < arr.Length; j++)
            {
                Console.Write(" {0},", arr[j]);
            }
            Console.WriteLine();
        }
        //for (int i = 0; i < arr.Length; i++)
        //{
        //    Console.Write(" {0},", arr[i]);
        //}
    }
}