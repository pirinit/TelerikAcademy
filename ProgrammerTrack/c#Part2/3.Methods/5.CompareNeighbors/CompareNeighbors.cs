using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 5. Write a method that checks if the element at given position
 * in given array of integers is bigger than its two neighbors (when such exist).
 */
class CompareNeighbors
{
    static int IsBiggerThanNeighbors(int index, int[] array)
    {
        int result = 0;
        if (index < 0 || index > array.Length - 1)
        {
            return -2;
        }
        if (index == 0 || index == array.Length - 1)
        {
            return -1;
        }
        if (array[index] > array[index - 1] && array[index] > array[index + 1])
        {
            return 1;
        }
        return 0;
    }
    static void Main()
    {
        int[] numbers = new int[] { 1, 5, 6, 8, 3, 3, 3, 3, 7, 5, 4, 5, 3, 7, 4, 8 };
        int n = 0;
        switch (IsBiggerThanNeighbors(n, numbers))
        {
            case -2:
                Console.WriteLine("Index {0} is outside the array!", n);
                break;
            case -1:
                Console.WriteLine("Index points either the begining or the end of the array!");
                break;
            case 0:
                Console.WriteLine("Number {1} on possition {0} isn't bigger than his neighbors.", n, numbers[n]);
                break;
            case 1:
                Console.WriteLine("Number {1} on possition {0} is bigger than his neighbors.", n, numbers[n]);
                break;
        }
    }
}