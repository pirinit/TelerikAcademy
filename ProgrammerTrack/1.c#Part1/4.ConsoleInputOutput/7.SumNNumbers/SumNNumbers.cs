using System;

class SumNNumbers
{
    static void Main()
    {
        Console.Write("Enter n: ");
        string input = Console.ReadLine();
        int n = int.Parse(input);
        int sum = 0;

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter next number: ");
            input = Console.ReadLine();
            int number = int.Parse(input);
            sum += number;
        }
        Console.WriteLine("The sum of the above numbers is: {0}", sum);
    }
}