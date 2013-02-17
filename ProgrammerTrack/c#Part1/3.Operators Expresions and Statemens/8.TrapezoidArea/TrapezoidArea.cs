using System;

class TrapezoidArea
{
    static void Main()
    {
        Console.Write("Enter a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter h: ");
        double h = double.Parse(Console.ReadLine());
        double trapezoidArea = (a > b ? b : a) * h + Math.Abs(a - b) * h / 2;
        Console.WriteLine("The area of the trapezoid is {0}.", trapezoidArea);
    }
}