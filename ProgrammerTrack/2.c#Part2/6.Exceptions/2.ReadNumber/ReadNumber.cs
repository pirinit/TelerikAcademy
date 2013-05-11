using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 2. Write a method ReadNumber(int start, int end) that enters an integer number
 * in given range [start…end]. If an invalid number or non-number text is entered,
 * the method should throw an exception.
 * Using this method write a program that enters 10 numbers:
 * a1, a2, … a10, such that 1 < a1 < … < a10 < 100
 */
class ReadNumberClass
{
    static int ReadNumber(int start, int end)
    {
        string input = Console.ReadLine();
        int n;
        try
        {
            n = int.Parse(input);
            if (n < start || n > end)
            {
                string errorMessage = string.Format("Entered int number either too small or too big. Acceptable range is [{0}-{1}].", start, end);
                throw new ArgumentOutOfRangeException(errorMessage);
            }
        }
        catch (FormatException fe)
        {
            throw new FormatException("Invalid number.", fe);
        }
        catch (OverflowException oe)
        {
            throw new OverflowException("Number too big.", oe);
        }
        return n;
    }
    static void Main()
    {
        int[] numbers = new int[10];

        while (true)
        {
            Console.WriteLine("Please enter ten int numbers in the range [2-99] matching following rule\na1, a2, … a10, such that 1 < a1 < … < a10 < 100");
            try
            {
                Console.Write("a1 = ");
                numbers[0] = ReadNumber(2, 99);
                for (int i = 1; i < numbers.Length; i++)
                {
                    Console.Write("a{0} = ",i+1);
                    numbers[i] = ReadNumber(numbers[i - 1] + 1, 100);
                }
                break;
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }
            catch (ArgumentOutOfRangeException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        foreach (var num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}