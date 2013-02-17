using System;

class PrintSimpleMatrix
{
    static void Main()
    {
        string input = Console.ReadLine();
        int n = int.Parse(input);
        for (int row = 1; row <= n; row++)
        {
            for (int col = row; col < row + n; col++)
            {
                Console.Write("{0} ", col.ToString().PadLeft(3,' '));
            }
            Console.WriteLine();
        }
    }
}