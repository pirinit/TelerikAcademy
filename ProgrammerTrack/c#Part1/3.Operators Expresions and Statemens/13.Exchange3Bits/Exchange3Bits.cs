using System;

class Exchange3Bits
{
    static void PrintNumberInBinery(uint number)
    {

        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
    }
    static void Main()
    {
        Console.Write("Enter number: ");
        string input = Console.ReadLine();
        uint number = uint.Parse(input);
        Console.WriteLine("Number {0} in binery numeric system looks: ", number);
        PrintNumberInBinery(number);
        Console.WriteLine();
        byte firstGroupOffset = 3-1;
        byte secondGroupOffset = 24 - 1;
        byte numberOfBits = 3;
        uint mask = (uint)Math.Pow(2,numberOfBits)-1;
        //copy source bits to a mask
        uint firstGroupBits = (number >> firstGroupOffset) & mask;
        uint secondGroupBits = (number >> secondGroupOffset) & mask;
        Console.WriteLine("First group (pos {0}, lenght {1}) in binery numeric system looks: ", firstGroupOffset + 1, numberOfBits);
        PrintNumberInBinery(firstGroupBits);
        Console.WriteLine("Second group (pos {0}, lenght {1}) in binery numeric system looks: ", secondGroupOffset + 1, numberOfBits);
        PrintNumberInBinery(secondGroupBits);
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
        Console.WriteLine("Number {0} with exchanged groups of bits: ");
        PrintNumberInBinery(result);
    }
}