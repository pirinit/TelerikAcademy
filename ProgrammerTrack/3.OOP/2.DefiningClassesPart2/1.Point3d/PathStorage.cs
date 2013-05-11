using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/* 4. Create a class Path to hold a sequence of points in the 3D space.
 * Create a static class PathStorage with static methods to save and
 * load paths from a text file. Use a file format of your choice.
 */ 
static class PathStorage
{
    public static void Save(Path path, string fileName)
    {
        using (StreamWriter file = new StreamWriter(fileName))
        {
            List<Point3d> pathList = path.PathList;
            file.WriteLine("{0}", pathList.Count);
            for (int i = 0; i < pathList.Count; i++)
            {
                file.WriteLine("{0} {1} {2}", pathList[i].X, pathList[i].Y, pathList[i].Z);
            }
        }
    }

    public static Path Load(string fileName)
    {
        Path result = new Path();
        using (StreamReader file = new StreamReader(fileName))
        {
            int linesCount = int.Parse(file.ReadLine());
            for (int i = 0; i < linesCount; i++)
            {
                string line = file.ReadLine();
                string[] coords = line.Split();
                double x = double.Parse(coords[0]);
                double y = double.Parse(coords[1]);
                double z = double.Parse(coords[2]);
                Point3d point = new Point3d(x, y, z);
                result.AddPoint3d(point);
            }
        }

        return result;
    }
}