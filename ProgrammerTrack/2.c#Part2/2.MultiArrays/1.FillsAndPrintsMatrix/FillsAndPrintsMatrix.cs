using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FillsAndPrintsMatrix
{
    static int[,] matrix;
    static int type;
    static int n;
    static sbyte row = -1;
    static sbyte col = 0;
    static int current = 1;
    static int layerNumber = 0;

    class Point
    {
        public int row;
        public int col;

        public Point()
        {
            if (type == 3)
            {
                this.row = n - 1;
                this.col = 0;
            }
            else
            {
                this.row = 0;
                this.col = 0;
            }
        }
    }

    static void FillOneLine(byte direction, byte lenght)
    {
        for (int i = 0; i < lenght; i++)
        {
            switch (direction)
            {
                case 1:
                    col++;
                    break;
                case 2:
                    row++;
                    break;
                case 3:
                    col--;
                    break;
                case 4:
                    row--;
                    break;
            }
            matrix[row, col] = current++;
        }
    }

    static void FillOneLayer()
    {
        FillOneLine(2, (byte)(n - layerNumber * 2));
        FillOneLine(1, (byte)(n - layerNumber * 2 - 1));
        FillOneLine(4, (byte)(n - layerNumber * 2 - 1));
        FillOneLine(3, (byte)(n - layerNumber * 2 - 2));
    }
    static void CalcNextCell(Point cell)
    {
        if (type == 1)
        {
            cell.row++;
            if (cell.row > n - 1)
            {
                cell.row = 0;
                cell.col++;
            }
        }
        else if (type == 2)
        {
            if (cell.col % 2 == 0)
            {
                cell.row++;
                if (cell.row > n - 1)
                {
                    cell.row = n - 1;
                    cell.col++;
                }
            }
            else
            {
                cell.row--;
                if (cell.row < 0)
                {
                    cell.row = 0;
                    cell.col++;
                }
            }
        }
        else
        {
            cell.row++;
            cell.col++;
            if (cell.col > n - 1)
            {
                cell.col = n + 1 - cell.row;
                cell.row = 0;
            }
            if (cell.row > n - 1)
            {
                cell.row = n - 1 - cell.col;
                cell.col = 0;
            }
        }
    }

    static void PrintMatrix()
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0,4}", matrix[row,col]);
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        Console.Write("Please enter matrix size: ");
        string input = Console.ReadLine();
        n = int.Parse(input);
        Console.Write("Please enter fill patern type (1-4): ");
        input = Console.ReadLine();
        type = int.Parse(input);
        matrix = new int[n, n];

        Point nextCell = new Point();

        int numberOfCells = n * n;
        if (type == 1 || type == 2 || type == 3)
        {
            for (int i = 1; i <= numberOfCells; i++)
            {
                matrix[nextCell.row, nextCell.col] = i;
                CalcNextCell(nextCell);
            }
        }
        else if (type == 4)
        {
            while (current < n * n)
            {
                FillOneLayer();
                layerNumber++;
            }
            if (n % 2 != 0)
            {
                matrix[row, col + 1] = current;
            }
        }
        //for (int i = 0; i < numberOfCells; i++)
        //{
        //    matrix[i % n, i / n] = i+1;
        //}

        //for (int i = 0; i < numberOfCells; i++)
        //{
        //    int row;
        //    int col;
        //    if((i%n)%n != 0)
        //    {
        //        row = n- i%n-1;
        //    }
        //    else
        //    {
        //        row = i%n;
        //    }
        //    col = i / n;
        //    matrix[row, col] = i + 1;
        //}

        PrintMatrix();
    }
}