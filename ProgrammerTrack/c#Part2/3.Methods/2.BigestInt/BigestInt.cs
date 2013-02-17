using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 2. Write a method GetMax() with two parameters that returns the bigger of
 * two integers. Write a program that reads 3 integers from the console and
 * prints the biggest of them using the method GetMax().
 */
class BigestInt
{
    static int GetMax(int first, int second)
    {
        return first > second ? first : second;
    }
    static void Main()
    {
        Console.Write("Please enter first int: ");
        string input = Console.ReadLine();
        int first = int.Parse(input);
        Console.Write("Please enter second int: ");
        input = Console.ReadLine();
        int second = int.Parse(input);
        Console.Write("Please enter third int: ");
        input = Console.ReadLine();
        int third = int.Parse(input);

        Console.WriteLine("The bigest int is {0}.", GetMax(GetMax(first,second),third));
    }
}