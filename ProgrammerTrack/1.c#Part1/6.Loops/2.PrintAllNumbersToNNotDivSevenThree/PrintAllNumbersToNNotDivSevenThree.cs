using System;

class PrintAllNumbersToNNotDivSevenThree
{
    static void Main()
    {
        string input = Console.ReadLine();
        int n = int.Parse(input);

        for (int i = 1; i <= n; i++)
        {
            if (i % 3 == 0 && i % 7 == 0)
            {
                continue;
            }
            Console.WriteLine(i);
        }
    }
}