using System;

class PInRange
{
    static void Main()
    {
        Console.Write("Enter down range limit: ");
        string input = Console.ReadLine();
        int downLimit = int.Parse(input);
        Console.Write("Enter up range limit: ");
        input = Console.ReadLine();
        int upLimit = int.Parse(input);
        if (downLimit > upLimit)
        {
            int temp = downLimit;
            downLimit = upLimit;
            upLimit = temp;
        }

        int result = 0;
        for (int i = downLimit; i <= upLimit; i++)
        {
            if (i % 5 == 0)
            {
                result++;
            }
        }
        Console.WriteLine(result);
    }
}