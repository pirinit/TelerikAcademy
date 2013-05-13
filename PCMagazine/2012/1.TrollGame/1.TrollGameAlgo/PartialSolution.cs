using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

class PartialSolution : IComparable<PartialSolution>
{
    public int moves;
    public double efficiency;
    public int targetNeighborRow;
    public int targetNeighborCol;
    public int row;
    public int col;
    public int removedRocks;
    public PartialSolution(int row, int col)
    {
        this.row = row;
        this.col = col;
    }
    public PartialSolution()
    {
        this.row = 0;
        this.col = 0;
    }
    public int CompareTo(PartialSolution other)
    {
        if (this.efficiency == other.efficiency)
        {
            return this.moves.CompareTo(other.moves);
        }
        else
        {
            return ((this.efficiency < other.efficiency) ? 1 : -1);
        }
    }
}