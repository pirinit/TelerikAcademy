using System;

class PrintsBiggerNumber
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        string input = Console.ReadLine();
        int a = int.Parse(input);
        Console.Write("Enter second number: ");
        input = Console.ReadLine();
        int b = int.Parse(input);
        int biggerNumber = (a > b) ? a : b;
        Console.WriteLine("The bigger number is: {0}", biggerNumber);
    }
}