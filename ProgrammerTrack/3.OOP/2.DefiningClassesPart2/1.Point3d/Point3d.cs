using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 1. Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space.
 * Implement the ToString() to enable printing a 3D point.
 * 
 * 2. Add a private static read-only field to hold the start of the coordinate system –
 * the point O{0, 0, 0}. Add a static property to return the point O.
*/

struct Point3d
{
    private double x;
    private double y;
    private double z;
    private static readonly Point3d pointZero = new Point3d(0, 0, 0);

    public static Point3d PointZero
    {
        get
        {
            return pointZero;
        }
    }

    public double X 
    { 
        get
        {
            return this.x;
        }
        set
        {
            this.x = value;
        }
    }

    public double Y
    {
        get
        {
            return this.y;
        }
        set
        {
            this.y = value;
        }
    }

    public double Z
    {
        get
        {
            return this.z;
        }
        set
        {
            this.z = value;
        }
    }

    public Point3d(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public override string ToString()
    {
        string result = String.Format("[{0}, {1}, {2}]", this.x, this.y, this.z);
        return result;
    }
}