using System;

static class GeometryUtils
{
    public static double CalcDistance2D(Point2D first, Point2D second)
    {
        double deltaX = first.X - second.X;
        double deltaY = first.Y - second.Y;
        double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

        return distance;
    }

    public static double CalcDistance3D(Point3D first, Point3D second)
    {
        double deltaX = first.X - second.X;
        double deltaY = first.Y - second.Y;
        double deltaZ = first.Z - second.Z;
        double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);

        return distance;
    }

    public static double CalcVolume(double width, double height, double depth)
    {
        double volume = width * height * depth;

        return volume;
    }

    public static double CalcVolume(Point3D point)
    {
        return CalcVolume(point.X, point.Y, point.Z);
    }

    public static double CalcDiagonalXYZ(Point3D point)
    {
        double distance = CalcDistance3D(new Point3D(0,0,0), point);

        return distance;
    }

    public static double CalcDiagonalXY(Point3D point)
    {
        double distance = CalcDistance2D(new Point2D(0, 0), new Point2D(point.X, point.Y));

        return distance;
    }

    public static double CalcDiagonalXZ(Point3D point)
    {
        double distance = CalcDistance2D(new Point2D(0, 0), new Point2D(point.X, point.Z));

        return distance;
    }

    public static double CalcDiagonalYZ(Point3D point)
    {
        double distance = CalcDistance2D(new Point2D(0, 0), new Point2D(point.Y, point.Z));

        return distance;
    }
}