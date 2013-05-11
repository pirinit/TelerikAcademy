using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 13. Write a program that can solve these tasks:
* Reverses the digits of a number
* Calculates the average of a sequence of integers
* Solves a linear equation a * x + b = 0
* Create appropriate methods.
* Provide a simple text-based menu for the user to choose which task to solve.
* Validate the input data:
* The decimal number should be non-negative
* The sequence should not be empty
* a should not be equal to 0
*/
class TasksSolver
{
    static decimal GetReverseDigits(decimal number)
    {
        decimal result = 0;
        while (number > 0)
        {
            result = result * 10 + number % 10;
            number = (int)(number / 10);
        }
        return result;
    }

    static decimal Average(int[] numbers)
    {
        decimal sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        return sum / numbers.Length;
    }

    static double SolveLinearEquation(double a, double b)
    {
        double result = -(b / a);
        return result;
    }

    static void Main()
    {
        string line = new string('-', 55);
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine(line);
            Console.WriteLine(" Tasks:");
            Console.WriteLine(" 1. Reverse the digits of a number.");
            Console.WriteLine(" 2. Calculates the average of a sequence of integers.");
            Console.WriteLine(" 3. Solves a linear equation a * x + b = 0");
            Console.WriteLine(" 4. Exit");
            Console.WriteLine(line);
            Console.Write("Please enter task's number: ");
            string input = Console.ReadLine();
            int task = int.Parse(input);

            switch (task)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine(line);
                    Console.WriteLine(" 1. Reverse the digits of a number.");
                    Console.WriteLine(line);
                    decimal number;
                    do
                    {
                        Console.Write(" Please enter non-negative decimal number to be reversed: ");
                        input = Console.ReadLine();
                        number = decimal.Parse(input);
                    } while (number < 0);
                    Console.WriteLine(" Reversed number is: {0}", GetReverseDigits(number));
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine(line);
                    Console.WriteLine(" 2. Calculates the average of a sequence of integers.");
                    Console.WriteLine(line);
                    int n;
                    do
                    {
                        Console.Write(" Please enter the size of the sequence: ");
                        input = Console.ReadLine();
                        n = int.Parse(input);
                    } while (n < 0);
                    int[] numbers = new int[n];
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write("  numbers[{0}] = ", i+1);
                        input = Console.ReadLine();
                        numbers[i] = int.Parse(input);
                    }
                    Console.WriteLine(" The average is: {0}", Average(numbers));
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine(line);
                    Console.WriteLine(" 3. Solves a linear equation a * x + b = 0");
                    Console.WriteLine(line);
                    double a;
                    do
                    {
                        Console.Write(" Please enter a: ");
                        input = Console.ReadLine();
                        a = int.Parse(input);
                    } while (a == 0);
                    Console.Write(" Please enter b: ");
                    input = Console.ReadLine();
                    double b = int.Parse(input);
                    Console.WriteLine(" The solution is : {0}", SolveLinearEquation(a, b));
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 4:
                    isRunning = false;
                    break;
            }
        }
    }
}