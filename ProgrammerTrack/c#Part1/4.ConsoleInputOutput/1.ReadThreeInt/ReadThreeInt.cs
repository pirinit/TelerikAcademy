using System;

class ReadThreeInt
{
    static void Main()
    {
        Console.Write("Enter a: ");
        string input = Console.ReadLine();
        int a = int.Parse(input);
        Console.Write("Enter b: ");
        input = Console.ReadLine();
        int b = int.Parse(input);
        Console.Write("Enter c: ");
        input = Console.ReadLine();
        int c = int.Parse(input);

        Console.WriteLine("{0} + {1} + {2} = {3}", a, b, c, a + b + c);
    }
}