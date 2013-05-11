using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 11. Write a method that adds two polynomials. Represent them as arrays
* of their coefficients as in the example below:
* x2 + 5 = 1x2 + 0x + 5  501
*  12. Extend the program to support also subtraction and multiplication of polynomials.
*/
class AddTwoPolinomials
{
    static int[] Add(int[] first, int[] second)
    {
        if (first.Length > second.Length)
        {
            int[] temp = first;
            first = second;
            second = temp;
        }
        int[] result = new int[second.Length];

        for (int i = 0; i < first.Length; i++)
        {
            result[i] = first[i] + second[i];
        }

        for (int i = first.Length; i < second.Length; i++)
        {
            result[i] = second[i];
        }
        return result;
    }

    static int[] Substract(int[] first, int[] second)
    {
        int shorterArrayLenght = 0;
        int[] result;
        if (first.Length < second.Length)
        {
            shorterArrayLenght = first.Length;
            result = new int[second.Length];
        }
        else
        {
            result = new int[first.Length];
            shorterArrayLenght = second.Length;
        }

        for (int i = 0; i < shorterArrayLenght; i++)
        {
            result[i] = first[i] - second[i];
        }

        if (first.Length < second.Length)
        {
            for (int i = shorterArrayLenght; i < second.Length; i++)
            {
                result[i] = -second[i];
            }
        }
        else
        {
            for (int i = shorterArrayLenght; i < first.Length; i++)
            {
                result[i] = first[i];
            }
        }

        return result;
    }

    static int[] Multiplay(int[] first, int[] second)
    {
        int[] temp = MultiplayArrayByInt(first, second[0], 0);

        for (int i = 1; i < second.Length; i++)
        {
            temp = Add(temp, MultiplayArrayByInt(first, second[i], i));
        }
        return temp;
    }

    static int[] MultiplayArrayByInt(int[] arr, int number, int offset)
    {
        int[] result = new int[arr.Length + offset];
        for (int i = 0; i < arr.Length; i++)
        {
            result[i + offset] = arr[i] * number;
        }
        return result;
    }

    static void PrintArray(int[] arr)
    {
        Console.Write("{");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(" {0},", arr[i]);
        }
        Console.WriteLine("\x0008 }");
    }

    static void Main()
    {
        int[] firstPol = new int[] { -2, -3, 4, -1, 3 };
        int[] secondPol = new int[] { 3, 1, 8 };

        PrintArray(firstPol);
        PrintArray(secondPol);
        int[] result = Add(secondPol, firstPol);
        PrintArray(result);
        result = Substract(secondPol, firstPol);
        PrintArray(result);
        result = Multiplay(firstPol, secondPol);
        PrintArray(result);
    }
}