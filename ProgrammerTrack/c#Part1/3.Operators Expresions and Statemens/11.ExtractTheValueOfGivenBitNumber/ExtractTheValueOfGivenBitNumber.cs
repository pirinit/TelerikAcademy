using System;

class ExtractTheValueOfGivenBitNumber
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Enter a position: ");
        int position = int.Parse(Console.ReadLine());
        int mask = 1;
        mask <<= position;
        Console.WriteLine("The value of {0}-bit in {1} is {2}.", position, number, (number & mask) >> position);
    }
}