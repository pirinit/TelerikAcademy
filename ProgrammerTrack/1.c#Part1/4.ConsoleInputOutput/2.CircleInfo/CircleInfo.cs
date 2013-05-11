using System;


class CircleInfo
{
    static void Main()
    {
        Console.WriteLine("Enter circle radius: ");
        string input = Console.ReadLine();
        double radius = Double.Parse(input);

        double perimeter = 2 * Math.PI * radius;
        double area = Math.PI * radius * radius;
        Console.WriteLine("The perimeter of the circle is: {0,10:f2}\nThe area of the circle is:      {1,10:f2}", perimeter, area);
    }
}