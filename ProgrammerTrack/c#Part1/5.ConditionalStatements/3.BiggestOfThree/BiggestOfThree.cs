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

        int biggest;
        if (first > second)
        {
            if (first > third)
            {
                biggest = first;
            }
            else
            {
                biggest = third;
            }
        }
        else
        {
            if (second > third)
            {
                biggest = second;
            }
            else
            {
                biggest = third;
            }
        }
        Console.WriteLine("The biggest number is {0}",biggest);
    }
}