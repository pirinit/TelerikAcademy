using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RemainingCells
{
    byte[,] matrix;
    int zone;
    Point nextCell;

    public RemainingCells(byte[,] targetMatrix, int zone)
    {
        this.matrix = targetMatrix;
        this.zone = zone;
        switch (zone)
        {
            case 1:
                this.nextCell = new Point(1, 1);
                break;
            case 2:
                this.nextCell = new Point(1, matrix.GetLength(1) - 2);
                break;
            case 3:
                this.nextCell = new Point(matrix.GetLength(0) - 2, 1);
                break;
            case 4:
                this.nextCell = new Point(matrix.GetLength(0) - 2, matrix.GetLength(1) - 2);
                break;
            case 5:
                this.nextCell = new Point(1, 1);
                break;
        }
    }

    class Point
    {
        public int row;
        public int col;

        public Point(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }

    void GetNextCell(Point cell)
    {
        int maxRow = matrix.GetLength(0) - 2;
        int maxCol = matrix.GetLength(1) - 2;
        int matrixSize = matrix.GetLength(0);

        switch (zone)
        {
            case 1:
                cell.row++;
                cell.col--;
                if (cell.col < 1)
                {
                    cell.col = cell.row;
                    cell.row = 1;
                }
                break;
            case 2:
                cell.row++;
                cell.col++;
                if (cell.col > maxCol)
                {
                    cell.col = matrixSize - 1 - cell.row;
                    cell.row = 1;
                }
                break;
            case 3:
                cell.row++;
                cell.col++;
                if (cell.col > maxCol)
                {
                    cell.col = matrixSize + 1 - cell.row;
                    cell.row = 1;
                }
                if (cell.row > maxRow)
                {
                    cell.row = matrixSize - 1 - cell.col;
                    cell.col = 1;
                }
                break;
            case 4:
                cell.row++;
                cell.col--;
                if (cell.col > maxCol)
                {
                    cell.col = matrixSize - 2 - cell.row;
                    cell.row = 1;
                }
                if (cell.row > maxRow)
                {
                    cell.row = cell.col;
                    cell.col = maxCol;
                }
                break;
            case 5:
                cell.col++;
                if (cell.col > maxRow)
                {
                    cell.col = 1;
                    cell.row++;
                }
                break;
        }
    }

    public void Go(int cells)
    {
        if (cells > 0)
        {
            while (cells > 0)
            {
                if (matrix[nextCell.row, nextCell.col] != 1)
                {
                    matrix[nextCell.row, nextCell.col] = 1;
                    cells--;
                }
                GetNextCell(nextCell);
            }
        }
        else
        {
            while (cells < 0)
            {
                if (matrix[nextCell.row, nextCell.col] != 0)
                {
                    matrix[nextCell.row, nextCell.col] = 0;
                    cells++;
                }
                GetNextCell(nextCell);
            }
        }
    }
}