using System;

class ExchangeTwoValues
{
    static void Main()
    {
        string input = Console.ReadLine();
        int first = int.Parse(input);
        input = Console.ReadLine();
        int second = int.Parse(input);
        if (first > second)
        {
            int temp = first;
            first = second;
            second = temp;
        }
        Console.WriteLine("First int ({0}) is smaller than the second int ({1})", first, second);
    }
}