using System;
using System.Linq;
using System.Diagnostics;

class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Input array can not be null.");

        for (int index = 0; index < arr.Length-1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        Debug.Assert(IsSortedAscending(arr), "Output array is not sorted.");
    }
  
    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Input array can not be null.");
        Debug.Assert(arr.Length > 0, "Input array can not be empty.");
        Debug.Assert(0 <= startIndex && startIndex <= arr.Length, "startIndex should be between 0 and arr.length.");
        Debug.Assert(0 <= endIndex && endIndex <= arr.Length, "endIndex should be between 0 and arr.length.");
        Debug.Assert(startIndex <= endIndex, "startIndex should be less or equal to endIndex.");
        
        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        Debug.Assert(startIndex <= minElementIndex && minElementIndex <= endIndex,
            "minElementIndex should be between startIndex and endIndex.");
        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Input array can not be null.");
        Debug.Assert(IsSortedAscending(arr), "BinarySearch works only with arrays sorted ascending.");
        Debug.Assert(value != null, "Searched value can not be null.");

        int foundValueIndex = BinarySearch(arr, value, 0, arr.Length - 1);

        bool isValueFound =  foundValueIndex != -1;
        if (isValueFound)
        {
            Debug.Assert(arr.Contains(value),
            "Binary search algorythm does not work correctly. Returns -1 while the array contains searched value.");
        }
        else
        {
            Debug.Assert(!arr.Contains(value),
            "Binary search algorythm does not work correctly." +
            "Returns index != -1 while the array does not contains the searched value.");
        }

        return foundValueIndex;
    }

    private static bool IsSortedAscending<T>(T[] arr) where T : IComparable<T>
    {

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i-1].CompareTo(arr[i]) > 0)
            {
                return false;
            }

        }

        return true;
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }
            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else 
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        //BinarySearch(arr, 15); // not sorted assertion
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
}
