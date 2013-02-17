using System;

class IsEven
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int input = int.Parse(Console.ReadLine());
        if (input % 2 == 0)
        {
            Console.WriteLine("{0} is even.", input);
        }
        else
        {
            Console.WriteLine("{0} is odd.", input);
        }
    }
}