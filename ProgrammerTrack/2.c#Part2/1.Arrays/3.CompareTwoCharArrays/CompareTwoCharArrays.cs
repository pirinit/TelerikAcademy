using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 3.Write a program that compares two char arrays
 * lexicographically (letter by letter).
 */
class CompareTwoCharArrays
{
    static void Main()
    {
        string a = "alabala";
        string b = "alacbala";

        char[] charArrA = a.ToCharArray();
        char[] charArrB = b.ToCharArray();

        int result = 0;
        for (int i = 0; i < charArrA.Length; i++)
        {
            if (charArrA[i] > charArrB[i])
            {
                result = 1;
                break;
            }
            if (charArrA[i] < charArrB[i])
            {
                result = -1;
                break;
            }
        }

        //Console.WriteLine(result);
        if (result == 0)
        {
            Console.WriteLine("The two char arrays are lexicographicly equal.");
        }
        else if (result > 0)
        {
            Console.WriteLine("The first char array is lexicographicly greater than the second one.");
        }
        else
        {
            Console.WriteLine("The second char array is lexicographicly greater than the first one.");
        }
        Console.WriteLine("First char array:  {0}",a);
        Console.WriteLine("Second char array: {0}",b);
        //Console.WriteLine(string.Compare(a, b)); 
    }
}
