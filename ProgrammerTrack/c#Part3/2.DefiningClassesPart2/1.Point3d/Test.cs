using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Test
{
    static void Main()
    {
        Path path = new Path();

        for (int i = 0; i < 5; i++)
        {
            path.AddPoint3d(new Point3d(5.5 * i, 7 * i, 18.8 * i));
        }

        Console.WriteLine(Point3dUtils.Distance3d(path.PathList[2], path.PathList[4]));

        PathStorage.Save(path, "path.txt");
        Path pathCopy = PathStorage.Load("path.txt");

        Console.WriteLine(Point3dUtils.Distance3d(pathCopy.PathList[2], pathCopy.PathList[4]));
    }
}