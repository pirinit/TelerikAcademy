using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.ShapesStore
{
    class ShapeJ : Shape
    {
        public ShapeJ(int row, int col, int blockSize)
            : base(new List<Block>(), 0, 0, 0)
        {
            Brush brush = new SolidBrush(Color.Purple);

            this.blocks.Add(new Block(row, col, brush, new Rectangle(0, 0, blockSize, blockSize)));
            this.blocks.Add(new Block(row + 1, col, brush, new Rectangle(0, 0, blockSize, blockSize)));
            this.blocks.Add(new Block(row + 1, col + 1, brush, new Rectangle(0, 0, blockSize, blockSize)));
            this.blocks.Add(new Block(row + 1, col + 2, brush, new Rectangle(0, 0, blockSize, blockSize)));

            this.row = row;
            this.col = col;
            this.formSize = 3;
        }
    }
}