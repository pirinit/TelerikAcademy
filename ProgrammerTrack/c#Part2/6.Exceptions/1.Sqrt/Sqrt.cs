using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 1. Write a program that reads an integer number and calculates
 * and prints its square root. If the number is invalid or negative,
 * print "Invalid number". In all cases finally print "Good bye".
 * Use try-catch-finally.
 */
class Sqrt
{
    static void Main()
    {
        try
        {
            Console.Write("Please enter possitive int number: ");
            string input = Console.ReadLine();
            int n = int.Parse(input);
            if (n < 0)
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                Console.WriteLine("The square root of {0} is {1}.", n, Math.Sqrt(n));
            }
        }
        catch (Exception ex)
        {
            if (ex is FormatException || ex is OverflowException)
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                throw;
            }
        }
        finally
        {
            Console.WriteLine("Good bye!");
        }
    }
}