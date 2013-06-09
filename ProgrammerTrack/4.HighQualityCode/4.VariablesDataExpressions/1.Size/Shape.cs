using System;

public class Shape
{
    public Shape(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public double Width { get; private set; }

    public double Height { get; private set; }

    public static Shape GetRotatedShape(Shape size, double angleInRads)
    {
        double cos = Math.Cos(angleInRads);
        double sin = Math.Sin(angleInRads);
        double newWidth = (Math.Abs(cos) * size.Width) + (Math.Abs(sin) * size.Height);
        double newHeight = (Math.Abs(sin) * size.Width) + (Math.Abs(cos) * size.Height);
        return new Shape(newWidth, newHeight);
    }
}