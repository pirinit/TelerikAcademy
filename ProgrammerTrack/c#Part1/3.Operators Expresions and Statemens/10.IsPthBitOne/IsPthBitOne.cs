using System;

class IsPthBitOne
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Enter a position: ");
        int position = int.Parse(Console.ReadLine());
        int mask = 1;
        mask <<= position;
        bool isPthBitOne = ((number & mask) >> position) == 1;
        Console.WriteLine(Convert.ToString(number, 2));
        if (isPthBitOne)
        {
            Console.WriteLine("The bit on {0} position in the binery representation of {1} is 1. ", position, number);
        }
        else
        {
            Console.WriteLine("The bit on {0} position in the binery representation of {1} is 0. ", position, number);
        }
    }
}