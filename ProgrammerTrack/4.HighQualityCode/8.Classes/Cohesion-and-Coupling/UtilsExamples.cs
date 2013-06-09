using System;


class UtilsExamples
{
    static void Main()
    {
        Console.WriteLine(FileUtils.GetFileExtension("example"));
        Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
        Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

        Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
        Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
        Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

        Point2D pointA = new Point2D(1, -2);
        Point2D pointB = new Point2D(3, 4);
        Console.WriteLine("Distance in the 2D space = {0:f2}",
            GeometryUtils.CalcDistance2D(pointA, pointB));

        Point3D pointC = new Point3D(5, 2, -1);
        Point3D pointD = new Point3D(3, -6, 4);
        Console.WriteLine("Distance in the 3D space = {0:f2}",
            GeometryUtils.CalcDistance3D(pointC, pointD));

        Point3D pointE = new Point3D(3, 4, 5);
        Console.WriteLine("Volume = {0:f2}", GeometryUtils.CalcVolume(pointE));
        Console.WriteLine("Diagonal XYZ = {0:f2}", GeometryUtils.CalcDiagonalXYZ(pointE));
        Console.WriteLine("Diagonal XY = {0:f2}", GeometryUtils.CalcDiagonalXY(pointE));
        Console.WriteLine("Diagonal XZ = {0:f2}", GeometryUtils.CalcDiagonalXZ(pointE));
        Console.WriteLine("Diagonal YZ = {0:f2}", GeometryUtils.CalcDiagonalYZ(pointE));
    }
}