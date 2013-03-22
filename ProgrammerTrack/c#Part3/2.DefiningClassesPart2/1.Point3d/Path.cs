using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 4. Create a class Path to hold a sequence of points in the 3D space.
 * Create a static class PathStorage with static methods to save
 * and load paths from a text file. Use a file format of your choice.
 */
class Path
{
    private List<Point3d> pathList;

    public List<Point3d> PathList
    {
        get
        {
            return this.pathList;
        }
    }

    public Path()
    {
        this.pathList = new List<Point3d>();
    }

    public void AddPoint3d(Point3d point)
    {
        this.pathList.Add(point);
    }

    public void DeletePoint3dByIndex(int index)
    {
        this.pathList.RemoveAt(index);
    }

    public void DeletePoint3d(Point3d point)
    {
        this.pathList.Remove(point);
    }
}