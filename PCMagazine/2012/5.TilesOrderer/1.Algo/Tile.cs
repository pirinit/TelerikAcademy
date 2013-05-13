using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Tile
{
    public int row;
    public int col;
    public bool isFixed = false;
    public bool[,] gameField;

    public abstract bool IsPlacePossible(int row, int col);

    public abstract void Place();
}