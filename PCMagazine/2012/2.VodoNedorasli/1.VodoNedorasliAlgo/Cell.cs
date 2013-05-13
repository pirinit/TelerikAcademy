using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Cell
{
    public int row;
    public int col;
    public bool isAlive;

    public Cell(int row, int col, bool isAlive)
    {
        this.row = row;
        this.col = col;
        this.isAlive = isAlive;
    }

    
}

