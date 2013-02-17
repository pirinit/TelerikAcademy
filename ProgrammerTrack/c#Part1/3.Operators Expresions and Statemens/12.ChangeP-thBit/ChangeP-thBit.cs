using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Enter a position: ");
        int position = int.Parse(Console.ReadLine());
        Console.Write("Enter a value (0 or 1) for {0}-position: ", position);
        int value = int.Parse(Console.ReadLine());
        int mask = 1;
        mask <<= position;
        int pthBitValue = (number & mask) >> position;
        int resultNumber;
        if (pthBitValue != value)
        {
            if (pthBitValue == 1)
            {
                resultNumber = number ^ (1 << position);
            }
            else
            {
                resultNumber = number | (1 << position);
            }
        }
        else
        {
            resultNumber = number;
        }
        Console.WriteLine(Convert.ToString(resultNumber, 2));
    }
}