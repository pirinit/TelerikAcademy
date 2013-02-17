using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/* 15. Write methods to calculate minimum, maximum, average, sum and
 * product of given set of integer numbers. Use variable number of arguments.
* Modify your last program and try to make it work for any number type,
 * not just integer (e.g. decimal, float, byte, etc.).
 * Use generic method (read in Internet about generic methods in C#).

 */
class Generics
{
    static <T> Minimum(params int[] numbers)
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
        return sum / (double)numbers.Length;
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
        Console.WriteLine(Minimum(5, 6, 7, 8, 9, 3, 4, 2, 34, 5, 65, 56, 2));
        Console.WriteLine(Maximum(5, 6, 7, 8, 9, 3, 4, 2, 34, 5, 65, 56, 2));
        Console.WriteLine(Average(5, 6, 7, 8, 9, 3, 4, 2, 34, 5, 65, 56, 2));
        Console.WriteLine(Sum(5, 6, 7, 8, 9, 3, 4, 2, 34, 5, 65, 56, 2));
        Console.WriteLine(Product(5, 6, 7, 8, 9, 3, 4, 2, 34, 5, 65, 56, 2));
    }
}