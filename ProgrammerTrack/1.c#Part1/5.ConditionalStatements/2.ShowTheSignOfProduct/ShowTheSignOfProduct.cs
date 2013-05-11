using System;

class ShowTheSignOfProduct
{
    static void Main()
    {
        string input = Console.ReadLine();
        double first = double.Parse(input);
        input = Console.ReadLine();
        double second = double.Parse(input);
        input = Console.ReadLine();
        double third = double.Parse(input);

        bool isPositive = true;
        if (first < 0)
        {
            isPositive = !isPositive;
        }
        if (second < 0)
        {
            isPositive = !isPositive;
        }
        if (third < 0)
        {
            isPositive = !isPositive;
        }

        if (isPositive)
        {
            Console.WriteLine("The sign of the product of {0}, {1} and {2} is \"+\".", first, second, third);
        }
        else
        {
            Console.WriteLine("The sign of the product of {0}, {1} and {2} is \"-\".", first, second, third);
        }
    }
}