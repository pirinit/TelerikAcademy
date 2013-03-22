using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Interfaces;
using System.Drawing;

namespace Tetris
{
    class Grid : IGrid, IDrawable
    {
        Block[,] matrixField;
        int width, height;

        public Grid(int height, int width)
        {
            this.height = height;
            this.width = width;
            matrixField = new Block[height, width];
        }

        public bool IsCellOccupied(int row, int col)
        {
            if (CheckIfInBorders(row,col) && matrixField[row, col] == null)
            {
                return false;
            }
            return true;
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public void PlaceShapeBlocksInGrid(List<Block> blocks)
        {
            foreach (var block in blocks)
            {
                matrixField[block.Row, block.Col] = block;
            }
            CheckForFullRows();
        }

        public void Draw(Graphics surface)
        {
            foreach (var item in matrixField)
            {
                if(item != null)
                item.Draw(surface);
            }
        }

        /// <summary>
        /// traverses lines from bottom to top
        /// </summary>
        public void CheckForFullRows()
        {
            bool isLineFull = true;
            for (int row = this.height -1; row >= 0; row--)
			{
                isLineFull = true;
                for (int col = 0; col < width; col++)
                {
                    if (matrixField[row, col] == null)
                    {
                        isLineFull = false;
                        break; //goes to next line;
                    }
                }
                if (isLineFull)
                {
                    ScoreManager.LinesDestroyed++;
                    RemoveRow(row);
                    PullDownBlocks(row-1);
                    row++;
                }
			}
        }

        public void PullDownBlocks(int startRow)
        {
            for (int row = startRow; row >= 0; row--)
            {
                for (int col = 0; col < width; col++)
                {
                    matrixField[row + 1, col] = matrixField[row, col]; //this moves the block in the grid
                    if (matrixField[row + 1, col] != null)
                    {
                        matrixField[row, col].MoveDown(); //this moves the rectangle
                    }
                }
            }
        }

        void RemoveRow(int row)
        {
            for (int col = 0; col < width; col++)
            {
                matrixField[row, col] = null;
            }
        }

        bool CheckIfInBorders(int row, int col)
        {
            if (row < 0 || row >= height)
                return false;
            if (col < 0 || col >= width)
                return false;
            return true;
        }
    }
}
