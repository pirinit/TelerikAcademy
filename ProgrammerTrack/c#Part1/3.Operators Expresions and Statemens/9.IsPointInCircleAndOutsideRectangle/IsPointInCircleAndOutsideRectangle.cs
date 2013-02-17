using System;

class IsPointInCircleAndOutsideRectangle
{
    static void Main()
    {
        Console.Write("Enter value for X: ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Enter value for Y: ");
        double y = double.Parse(Console.ReadLine());
        double radius = 3;
        double circleX = 1;
        double circleY = 1;
        bool isPointInCircle = (x - circleX) * (x - circleX) + (y - circleY) * (y - circleY) <= radius * radius;
        Console.WriteLine(isPointInCircle);
        double rectangleTopLeftX = -1;
        double rectangleTopLeftY = 1;
        double rectangleBottomRightX = rectangleTopLeftX + 6;
        double rectangleBottomRightY = rectangleTopLeftY - 2;
        bool isPointInRectangle = (rectangleTopLeftX <= x && x <= rectangleBottomRightX) && (rectangleTopLeftY <= y && y <= rectangleBottomRightY);
        bool IsPointInCircleAndOutsideRectangle = isPointInCircle && !isPointInRectangle;
    }
}