using System;

class IsThirdBitOne
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        int mask = 1;
        mask <<= 3;
        bool isThirdBitOne = ((number & mask) >> 3) == 1;
        Console.WriteLine(Convert.ToString(number,2));
        if (isThirdBitOne)
        {
            Console.WriteLine("The third bit of {0} is 1.", number);
        }
        else
        {
            Console.WriteLine("The third bit of {0} is 0.", number);
        }
    }
}