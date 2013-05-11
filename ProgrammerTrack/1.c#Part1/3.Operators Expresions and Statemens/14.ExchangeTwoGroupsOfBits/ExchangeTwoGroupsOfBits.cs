using System;

class ExchangeTwoGroupsOfBits
{
    static void PrintNumberInBinery(uint number, byte size)
    {

        Console.WriteLine((Convert.ToString(number, 2).PadLeft(size, '0')).PadLeft(32));
    }

    static void PrintNumberInBinery(uint number)
    {
        PrintNumberInBinery(number, 32);
    }
    static void Main()
    {
        Console.Write("Enter number: ");
        string input = Console.ReadLine();
        uint number = uint.Parse(input);

        Console.Write("Enter first bit group offset, p = ");
        input = Console.ReadLine();
        byte firstGroupOffset = byte.Parse(input);
        firstGroupOffset--;

        Console.Write("Enter second bit group offset, q = ");
        input = Console.ReadLine();
        byte secondGroupOffset = byte.Parse(input);
        secondGroupOffset--;

        Console.Write("Enter bit group size, k = ");
        input = Console.ReadLine();
        byte numberOfBits = byte.Parse(input);

        uint mask = (uint)Math.Pow(2, numberOfBits) - 1;
        Console.WriteLine("Number {0} in binery numeric system looks: ", number);
        PrintNumberInBinery(number);
        Console.WriteLine();
        //copy source bits to a mask
        uint firstGroupBits = (number >> firstGroupOffset) & mask;
        uint secondGroupBits = (number >> secondGroupOffset) & mask;
        Console.WriteLine("First group (pos {0}, lenght {1}) in binery numeric system looks: ", firstGroupOffset + 1, numberOfBits);
        PrintNumberInBinery(firstGroupBits, numberOfBits);
        Console.WriteLine("Second group (pos {0}, lenght {1}) in binery numeric system looks: ", secondGroupOffset + 1, numberOfBits);
        PrintNumberInBinery(secondGroupBits, numberOfBits);
        Console.WriteLine();
        //set destination bits to zeros
        uint result = number & ~(mask << firstGroupOffset);
        result = result & ~(mask << secondGroupOffset);
        Console.WriteLine("Number {0} in binery numeric system looks: ", number);
        PrintNumberInBinery(number);
        Console.WriteLine("Number {0} in binery numeric system looks with zeroed bits: ", number);
        PrintNumberInBinery(result);
        Console.WriteLine();
        //merge source masks with zeroed number
        result = result | (firstGroupBits << secondGroupOffset);
        result = result | (secondGroupBits << firstGroupOffset);
        Console.WriteLine("Number {0} with exchanged groups of bits: ", number);
        PrintNumberInBinery(result);
    }
}