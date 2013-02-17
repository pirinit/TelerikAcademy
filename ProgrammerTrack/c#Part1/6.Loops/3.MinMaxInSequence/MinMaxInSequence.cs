using System;

class MinMaxInSequence
{
    static void Main()
    {
        string input = Console.ReadLine();
        int n = int.Parse(input);
        int min = int.MaxValue;
        int max = int.MinValue;
        for (int i = 0; i < n; i++)
        {
            input = Console.ReadLine();
            int current = int.Parse(input);
            if (current > max)
            {
                max = current;
            }
            if (current < min)
            {
                min = current;
            }
        }
        Console.WriteLine("Min number is: {0}", min);
        Console.WriteLine("Max number is: {0}", max);
    }
}