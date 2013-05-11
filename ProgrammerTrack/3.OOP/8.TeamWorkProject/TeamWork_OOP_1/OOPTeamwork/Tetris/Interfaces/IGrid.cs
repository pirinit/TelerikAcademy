using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Interfaces
{
    interface IGrid
    {
        bool IsCellOccupied(int row, int col);
        int Width
        {
            get;
        }
        int Height
        {
            get;
        }
    }
}
