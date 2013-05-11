using System;

class RectangleArea
{
    static void Main()
    {
        Console.Write("Enter width: ");
        double width = double.Parse(Console.ReadLine());
        Console.Write("Enter height: ");
        double height = double.Parse(Console.ReadLine());
        double rectangleArea = width * height;
        Console.WriteLine("The area of the rectangle is: {0}", rectangleArea);
    }
}