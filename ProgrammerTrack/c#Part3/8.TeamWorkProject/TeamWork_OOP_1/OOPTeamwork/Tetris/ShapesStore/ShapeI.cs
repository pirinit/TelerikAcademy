using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.ShapesStore
{
    class ShapeI : Shape
    {
        public ShapeI(int row, int col, int blockSize) : base(new List<Block>(),0,0,0)
        {
            Brush brush = new SolidBrush(Color.DarkSalmon);

            this.blocks.Add(new Block(row, col, brush, new Rectangle(0, 0, blockSize, blockSize)));
            this.blocks.Add(new Block(row, col + 1, brush, new Rectangle(0, 0, blockSize, blockSize)));
            this.blocks.Add(new Block(row, col + 2, brush, new Rectangle(0, 0, blockSize, blockSize)));
            this.blocks.Add(new Block(row, col + 3, brush, new Rectangle(0, 0, blockSize, blockSize)));

            this.row = row;
            this.col = col + 2;
            this.formSize = 0;
        }
    }
}