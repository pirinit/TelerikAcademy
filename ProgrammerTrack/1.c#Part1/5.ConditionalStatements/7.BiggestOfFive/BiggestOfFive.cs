using System;

class BiggestOfThree
{
    static void Main()
    {
        string input = Console.ReadLine();
        int first = int.Parse(input);
        input = Console.ReadLine();
        int second = int.Parse(input);
        input = Console.ReadLine();
        int third = int.Parse(input);
        input = Console.ReadLine();
        int fourth = int.Parse(input);
        input = Console.ReadLine();
        int fifth = int.Parse(input);

        int biggest = first;

        if (second > biggest)
        {
            biggest = second;
        }
        if (third > biggest)
        {
            biggest = third;
        }
        if (fourth > biggest)
        {
            biggest = fourth;
        }
        if (fifth > biggest)
        {
            biggest = fifth;
        }
        Console.WriteLine("The biggest number is {0}", biggest);
    }
}