using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 1. Define abstract class Shape with only one abstract method CalculateSurface()
 * and fields width and height. Define two new classes Triangle and Rectangle
 * that implement the virtual method and return the surface of the figure
 * (height*width for rectangle and height*width/2 for triangle).
 * Define class Circle and suitable constructor so that at initialization height
 * must be kept equal to width and implement the CalculateSurface() method.
 * Write a program that tests the behavior of  the CalculateSurface()
 * method for different shapes (Circle, Rectangle, Triangle) stored in an array.
 */
namespace _1.Shape
{
    class TestShape
    {
        static void Main()
        {
            List<Shape> shapes = new List<Shape>();

            shapes.Add(new Triangle(10, 5));
            shapes.Add(new Rectangle(50, 50));
            shapes.Add(new Circle(10));

            foreach (var shape in shapes)
            {
                Console.WriteLine("The surface of the shape is: {0:f3}", shape.CalculateSurface());
            }
        }
    }
}
