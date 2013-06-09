using System;

public class ShapeTest
{
    public static void Main()
    {
        Shape shape = new Shape(200, 100);
        shape = Shape.GetRotatedShape(shape, 123);

        Console.WriteLine("Height: {0}, Width: {1}", shape.Height, shape.Width);
    }
}