using System;

class CalcSumFactoriel
{
    static void Main()
    {
        string input = Console.ReadLine();
        int n = int.Parse(input);
        input = Console.ReadLine();
        int x = int.Parse(input);
        double currentNumber = 1 / (double)x;
        double sum = 1 + currentNumber;
        Console.WriteLine(sum);
        for (int i = 2; i <= n; i++)
        {
            currentNumber = (currentNumber * i) / x;
            sum += currentNumber;
            Console.WriteLine(" + {0}", currentNumber );
        }
        Console.WriteLine(sum);
    }
}