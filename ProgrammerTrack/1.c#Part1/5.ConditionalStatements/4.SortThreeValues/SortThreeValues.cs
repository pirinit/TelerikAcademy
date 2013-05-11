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
        int middle;
        int smallest;

        if (first > second)
        {
            if (first > third)
            {
                biggest = first;
                if (second > third)
                {
                    middle = second;
                    smallest = third;
                }
                else
                {
                    middle = third;
                    smallest = second;
                }
            }
            else
            {
                biggest = third;
                if (first > second)
                {
                    middle = first;
                    smallest = second;
                }
                else
                {
                    middle = second;
                    smallest = first;
                }
            }
        }
        else
        {
            if (second > third)
            {
                biggest = second;
                if (first > third)
                {
                    middle = first;
                    smallest = third;
                }
                else
                {
                    middle = third;
                    smallest = first;
                }
            }
            else
            {
                biggest = third;
                if (first > second)
                {
                    middle = first;
                    smallest = second;
                }
                else
                {
                    middle = second;
                    smallest = first;
                }
            }
        }
        Console.WriteLine("The three numbers in descenting order: \n1. {0}\n2. {1}\n3. {2}", biggest, middle, smallest);
    }
}