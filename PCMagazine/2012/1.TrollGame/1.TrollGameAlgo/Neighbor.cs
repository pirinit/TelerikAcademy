using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

class Neighbor : IComparable<Neighbor>
{
    public int min;
    public int max;
    public int difference;
    public int height;
    public Point pos = new Point();
    public int CompareTo(Neighbor other)
    {
        if (this.difference == other.difference)
        {
            return 1;
        }
        else
        {
            return ((this.difference > other.difference) ? 1 : -1);
        }
    }
    public override string ToString()
    {
        string result = String.Format("Row {0}, Col {1}, Height {2}, Root Difference {3}, Min {4}, Max {5}.",
            this.pos.row - TrollGameAlgo.offset, this.pos.col - TrollGameAlgo.offset, this.height, this.difference, this.min, this.max);
        return result;
    }
}