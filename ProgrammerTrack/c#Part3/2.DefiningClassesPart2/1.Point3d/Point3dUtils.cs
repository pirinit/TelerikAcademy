using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 3. Write a static class with a static method to calculate
 * the distance between two points in the 3D space.
 */
static class Point3dUtils
{
    public static double Distance3d(Point3d firstpoint, Point3d secondPoint)
    {
        double deltaX = firstpoint.X - secondPoint.X;
        double deltaY = firstpoint.Y - secondPoint.Y;
        double deltaZ = firstpoint.Z - secondPoint.Z;

        double distance = Math.Sqrt((deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ));
        return distance;
    }
}