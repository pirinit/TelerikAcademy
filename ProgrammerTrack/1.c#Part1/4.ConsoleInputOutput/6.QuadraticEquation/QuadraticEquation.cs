using System;

class QuadraticEquation
{
    static void Main()
    {
        Console.WriteLine("Enter coefficient a: ");
        string input = Console.ReadLine();
        double a = Double.Parse(input);
        Console.WriteLine("Enter coefficient b: ");
        input = Console.ReadLine();
        double b = Double.Parse(input);
        Console.WriteLine("Enter coefficient c: ");
        input = Console.ReadLine();
        double c = Double.Parse(input);

        double d = b * b - 4 * a * c;
        if (d < 0)
        {
            Console.WriteLine("The quadratic equation has no real roots.");
        }
        else
        {
            if (d == 0)
            {
                double root =  -b / (2 * a);
                Console.WriteLine("The quadratic equation has only one real root: {0}", root);
            }
            else
            {
                double dSqrt = Math.Sqrt(d);
                double root1 = (-b - dSqrt) / (2 * a);
                double root2 = (-b + dSqrt) / (2 * a);
                Console.WriteLine("The quadratic equation has two real roots: {0} and {1} ", root1, root2);
            }
        }
    }
}