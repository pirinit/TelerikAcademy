using System;

class SubsetSum
{
    static void Main()
    {
        Console.Write("Enter count of numbers:");
        string input = Console.ReadLine();
        int n = int.Parse(input);
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter number[{0}]: ", i+1);
            input = Console.ReadLine();
            numbers[i] = int.Parse(input);
        }

        bool hasZeroSubset = false;
        int combinations = (int)Math.Pow(2, n);
        int sum;

        for (int i = 1; i < combinations; i++)
        {
            sum = 0;
            for (int j = 0; j < n; j++)
            {
                if (((i >> j) & 1) == 1)
                {
                    sum += numbers[j];
                }
                if (sum == 0)
                {
                    hasZeroSubset = true;
                    break;
                }
                sum = 0;
            }
        }
        if (hasZeroSubset)
        {
            Console.WriteLine("There is a subset sum equal to zero.");
        }
        else
        {
            Console.WriteLine("There isn't a subset sum equal to zero.");
        }
    }
}