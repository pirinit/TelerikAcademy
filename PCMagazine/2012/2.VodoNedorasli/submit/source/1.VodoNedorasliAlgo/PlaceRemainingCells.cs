using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PlaceRemainingCells
{
    byte[,] matrix;
    int cells;
    int zone;

    public PlaceRemainingCells(byte[,] targetMatrix, int cellsCount, int zone)
    {
        this.matrix = targetMatrix;
        this.cells = cellsCount;
        this.zone = zone;
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
        }
    }

    public void Go()
    {
        Point nextCell = new Point(1,1);
        switch (zone)
        {
            case 2:
                nextCell = new Point(1, matrix.GetLength(1) - 2);
                break;
            case 3:
                nextCell = new Point(matrix.GetLength(0) - 2, 1);
                break;
            case 4:
                nextCell = new Point(matrix.GetLength(0) - 2, matrix.GetLength(1) - 2);
                break;
        }

        while (cells > 0)
        {
            matrix[nextCell.row, nextCell.col] = 1;
            GetNextCell(nextCell);
            cells--;
        }
    }
}