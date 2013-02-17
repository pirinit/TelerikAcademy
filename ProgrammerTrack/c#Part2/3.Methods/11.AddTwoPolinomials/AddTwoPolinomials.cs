using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 11. Write a method that adds two polynomials. Represent them as arrays
* of their coefficients as in the example below:
* x2 + 5 = 1x2 + 0x + 5  501
*/
class AddTwoPolinomials
{
    static int[] AddPolinomials(int[] first, int[] second)
    {
        if (first.Length > second.Length)
        {
            int[] temp = first;
            first = second;
            second = temp;
        }
        for (int i = 0; i < first.Length; i++)
        {
            second[i] += first[i];
        }
        return second;
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
        int[] firstPol = new int[] { 5, 0, 0, 3 };
        int[] secondPol = new int[] { 5, 2, 0, 1, 9, 6 };

        PrintArray(firstPol);
        PrintArray(secondPol);
        int[] result = AddPolinomials(secondPol, firstPol);
        PrintArray(result);
    }
}