using System;
using System.Numerics;

/* 14. Write methods to calculate minimum, maximum, average, sum and
 * product of given set of integer numbers. Use variable number of arguments.
 */
class VariableParameters
{
    static int Minimum(params int[] numbers)
    {
        int min = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (min > numbers[i])
            {
                min = numbers[i];
            }
        }
        return min;
    }

    static int Maximum(params int[] numbers)
    {
        int max = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (max < numbers[i])
            {
                max = numbers[i];
            }
        }
        return max;
    }

    static int Sum(params int[] numbers)
    {
        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }

    static double Average(params int[] numbers)
    {
        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum/(double)numbers.Length;
    }

    static BigInteger Product(params int[] numbers)
    {
        BigInteger product = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }
        return product;
    }

    static void Main()
    {
        Console.WriteLine(Minimum(5,6,7,8,9,3,4,2,34,5,65,56,2));
        Console.WriteLine(Maximum(5, 6, 7, 8, 9, 3, 4, 2, 34, 5, 65, 56, 2));
        Console.WriteLine(Average(5, 6, 7, 8, 9, 3, 4, 2, 34, 5, 65, 56, 2));
        Console.WriteLine(Sum(5, 6, 7, 8, 9, 3, 4, 2, 34, 5, 65, 56, 2));
        Console.WriteLine(Product(5, 6, 7, 8, 9, 3, 4, 2, 34, 5, 65, 56, 2));
    }
}