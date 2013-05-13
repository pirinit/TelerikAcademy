using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

class FullSolution : IComparable<FullSolution>
{
    public List<Move> turns = new List<Move>();
    public int moves;
    public double efficiency;
    public int row;
    public int col;
    public int removedRocks;

    public bool isPossible()
    {
        bool isPossible = true;
        foreach (var move in this.turns)
        {
            if (TrollGameAlgo.gameMatrix[move.pos.row, move.pos.col] == 0)
            {
                isPossible = false;
                break;
            }
        }
        return isPossible;
    }
    public FullSolution(int row, int col)
    {
        this.row = row;
        this.col = col;
    }
    public FullSolution()
    {
        this.row = 0;
        this.col = 0;
    }
    public int CompareTo(FullSolution other)
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