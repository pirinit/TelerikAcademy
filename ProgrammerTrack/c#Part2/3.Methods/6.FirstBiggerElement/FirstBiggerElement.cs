using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 6. Write a method that returns the index of the first element in array
* that is bigger than its neighbors, or -1, if there’s no such element.
* Use the method from the previous exercise.
*/
class FirstBiggerElement
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

    static int FirstElementBiggerNeighborsIndex(int[] array)
    {
        for (int i = 1; i < array.Length-2; i++)
        {
            if (IsBiggerThanNeighbors(i, array) == 1)
            {
                return i;
            }
        }
        return -1;
    }

    static void Main()
    {
        int[] numbers = new int[] { 1, 5, 6, 8, 3, 3, 3, 3, 7, 5, 4, 5, 3, 7, 4, 8 };
        //if the array is sorted there isn't no such element, bigger than both it's neighbors.
        //Array.Sort(numbers);
        Console.WriteLine(FirstElementBiggerNeighborsIndex(numbers));
    }
}