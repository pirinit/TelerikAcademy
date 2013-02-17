using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 4. Write methods that calculate the surface of a triangle by given:
 * Side and an altitude to it;
 * Three sides;
 * Two sides and an angle between them.
 * Use System.Math.
 */
class TriangleArea
{
    static double CalcAreaSideAltitude(double side, double altitude)
    {
        double area = side * altitude / 2;
        return area;
    }

    static double CalcAreaThreeSides(double sideA, double sideB, double sideC)
    {
        double perimeter = (sideA + sideB + sideC) / 2;
        double area = Math.Sqrt(perimeter*(perimeter-sideA)*(perimeter-sideB)*(perimeter-sideC));
        return area;
    }

    static double CalcAreaTwoSidesAngle(double sideA, double sideB, double angle)
    {
        double area = (sideA*sideB*Math.Sin(angle));
        return area;
    }
    static void Main()
    {
    }
}