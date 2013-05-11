using System;

class PrintAllNumbersToN
{
    static void Main()
    {
        Console.WriteLine("Enter n: ");
        string input = Console.ReadLine();
        int n = int.Parse(input);
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }
    }
}