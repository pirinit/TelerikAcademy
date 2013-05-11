using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Interfaces;

namespace Tetris
{
    class Block : IDrawable, IMovable
    {
        private int row, col;
        private int rowOffset;
        private int colOffset;
        private Brush brush;
        private Rectangle rectangle;

        public Block(int row, int col, Brush brush, Rectangle rectangle)
        {
            this.row = row;
            this.col = col;
            this.brush = brush;
            this.rectangle = rectangle;
        }

        internal int RowOffset
        {
            get
            {
                return this.rowOffset;
            }
            set
            {
                this.rowOffset = value;
            }
        }

        internal int ColOffset
        {
            get
            {
                return this.colOffset;
            }
            set
            {
                this.colOffset = value;
            }
        }

        public void Draw(Graphics surface)
        {
            //recalculate rectangles possition according to row and col in grid
            this.rectangle.Y = this.rowOffset + this.row * this.rectangle.Width;
            this.rectangle.X = this.colOffset + this.col * this.rectangle.Height;

            //drawing the shape
            surface.FillRectangle(this.brush, this.rectangle);
            surface.FillRectangle(new SolidBrush(Color.Azure),new Rectangle(this.rectangle.X+2,this.rectangle.Y+2,this.rectangle.Width-4,this.rectangle.Height-4));
        }

        public int Col
        {
            get { return col; }
        }

        public int Row
        {
            get { return row; }
        }

        public bool MoveDown()
        {
            this.row++;
            return true;
        }

        public void MoveLeft()
        {
            this.col--;
        }

        public void MoveRight()
        {
            this.col++;
        }

        public void Move(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public bool IsPossibleMove(int row, int col)
        {
            return !GridManager.IsCellOccupied(row, col);
        }
        public bool IsPossibleMoveDown()
        {
            if (GridManager.IsCellOccupied(row + 1, col))
            {
                return true;
            }
            bool isInGrid = this.row + 1 <= GridManager.Height;
            return !isInGrid;
        }

        public bool IsPossibleMoveLeft()
        {
            if (GridManager.IsCellOccupied(row, col - 1))
            {
                return true;
            }
            return false;
        }

        public bool IsPossibleMoveRight()
        {
            if (GridManager.IsCellOccupied(row, col + 1))
            {
                return true;
            }
            bool isInGrid = this.col + 1 <= 30;
            return !isInGrid;
        }
    }
}