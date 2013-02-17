using System;

class IsPointInCircle
{
    static void Main()
    {
        Console.Write("Enter value for X: ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Enter value for Y: ");
        double y = double.Parse(Console.ReadLine());
        Console.Write("Enter circle radius: ");
        double radius = double.Parse(Console.ReadLine());
        bool isPointInCircle = x * x + y * y <= radius * radius;
        if (isPointInCircle)
        {
            Console.WriteLine("The point[{0},{1}] lays within the circle[0,0,{2}].", x, y, radius);
        }
        else
        {
            Console.WriteLine("The point[{0},{1}] lays outside the circle[0,0,{2}].", x, y, radius);
        }
    }
}