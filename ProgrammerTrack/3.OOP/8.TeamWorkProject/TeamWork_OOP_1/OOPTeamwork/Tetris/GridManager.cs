using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    static class GridManager
    {
        static Grid grid;
        static int height;
        static int width;
       

        public static void GetGrid(Grid currentGrid)
        {
            grid = currentGrid;
            height = currentGrid.Height;
            width = currentGrid.Width;
        }

        public static bool IsCellOccupied(int row, int col)
        {
            return grid.IsCellOccupied(row, col);
        }

        public static int Height
        {
            get { return height; }
        }
        public static int Width
        {
            get { return width; }
        }
    }
}
