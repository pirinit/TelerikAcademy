using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Interfaces;

namespace Tetris
{
    abstract class Shape : IMovable, IDrawable
    {
        protected int row;
        protected int col;
        protected int formSize;

        protected List<Block> blocks;

        public Shape(List<Block> blocks, int row, int col, int formSize)
        {
            this.blocks = blocks;
            this.row = row;
            this.col = col;
            this.formSize = formSize;
        }

        public List<Block> GetBlocks
        {
            get { return blocks; }
        }

        public virtual void Rotate()
        {
            bool rotatePossible = true;
            foreach (var block in blocks)
            {
                int deltaRow = block.Row - this.row;
                int deltaCol = block.Col - this.col;
                int newDeltaRow = deltaCol;
                int newDeltaCol = 1 - (deltaRow -(this.formSize-2));
                rotatePossible = block.IsPossibleMove(this.row + newDeltaRow, this.col +newDeltaCol);
                if (!rotatePossible)
                {
                    break;
                }
            }

            if (rotatePossible)
            {
                foreach (var block in blocks)
                {
                    int deltaRow = block.Row - this.row;
                    int deltaCol = block.Col - this.col;
                    int newDeltaRow = deltaCol;
                    int newDeltaCol = 1 - (deltaRow - (this.formSize - 2));
                    block.Move(this.row + newDeltaRow, this.col + newDeltaCol);
                }
            }
        }

        public bool MoveDown()
        {
            if (this.IsPossibleMoveDown())
            {
                foreach (var block in blocks)
                {
                    block.MoveDown();
                }
                this.row++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void MoveLeft()
        {
            if (this.IsPossibleMoveLeft())
            {
                foreach (var block in blocks)
                {
                    block.MoveLeft();
                }
                this.col--;
            }
        }

        public void MoveRight()
        {
            if (this.IsPossibleMoveRight())
            {
                foreach (var block in blocks)
                {
                    block.MoveRight();
                }
                this.col++;
            }
        }

        public void MoveAtBottom()
        {
            while(this.IsPossibleMoveDown())
            {
                foreach (var block in blocks)
                {
                    block.MoveDown();
                }
            }
        }

        public bool IsShapePossible()
        {
            foreach (var block in blocks)
            {
                if (!block.IsPossibleMove(block.Row, block.Col))
                {
                    return false;
                }
            }
                    return true;
        }

        public bool IsPossibleMoveDown()
        {
            foreach (var block in blocks)
            {
                if (block.IsPossibleMoveDown())
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsPossibleMoveLeft()
        {
            foreach (var block in blocks)
            {
                if (block.IsPossibleMoveLeft())
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsPossibleMoveRight()
        {
            foreach (var block in blocks)
            {
                if (block.IsPossibleMoveRight())
                {
                    return false;
                }
            }
            return true;
        }

        public void Draw(System.Drawing.Graphics surface)
        {
            foreach (var block in blocks)
            {
                block.Draw(surface);
            }
        }
    }
}
