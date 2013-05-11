using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 3. We are given a matrix of strings of size N x M.
* Sequences in the matrix we define as sets of
* several neighbor elements located on the same line,
* column or diagonal. Write a program that finds
* the longest sequence of equal strings in the matrix. 
*/
class SequenceInMatrix
{
    static int longestRow = 0;
    static string longestRowString = "";
    static int longestCol = 0;
    static string longestColString = "";
    static int longestDiagonal = 0;
    static string longestDiagonalString = "";
    static int current = 0;
    static string currentString = "";
    static int m, n;

    static void Main()
    {
        Console.Write("Please enter matrix height n = ");
        string input = Console.ReadLine();
        n = int.Parse(input);
        Console.Write("Please enter matrix width m = ");
        input = Console.ReadLine();
        m = int.Parse(input);
        string[,] matrix = new string[n, m];

        for (int row = 0; row < n; row++)
        {
            input = Console.ReadLine();
            string[] inputs = input.Split();
            for (int col = 0; col < m; col++)
            {
                matrix[row, col] = inputs[col];
            }
        }

        //check rows
        CheckRows(matrix);
        Console.WriteLine("Longest row sequence is {0} times \"{1}\".", longestRow, longestRowString);

        //check cols
        CheckCols(matrix);
        Console.WriteLine("Longest col sequence is {0} times \"{1}\".", longestCol, longestColString);

        //check left-right diagonal
        CheckLeftRightDiagonal(matrix);
        //check right-left diagonal
        CheckRightLeftDiagonal(matrix);
        Console.WriteLine("Longest diagonal sequence is {0} times \"{1}\".", longestDiagonal, longestDiagonalString);
    }
  
    private static void CheckCols(string[,] matrix)
    {
        //check cols
        for (int col = 0; col < n; col++)
        {
            current = 1;
            currentString = matrix[0, col];
            for (int row = 1; row < m; row++)
            {
                if (matrix[row, col] == currentString)
                {
                    current++;
                }
                else
                {
                    if (current > longestCol)
                    {
                        longestCol = current;
                        longestColString = currentString;
                    }
                    else
                    {
                        current = 1;
                        currentString = matrix[row, col];
                    }
                }
            }
            if (current > longestCol)
            {
                longestCol = current;
                longestColString = currentString;
            }
        }
    }

    private static void CheckRows(string[,] matrix)
    {
        for (int row = 0; row < m; row++)
        {
            current = 1;
            currentString = matrix[row, 0];
            for (int col = 1; col < n; col++)
            {
                if (matrix[row, col] == currentString)
                {
                    current++;
                }
                else
                {
                    if (current > longestRow)
                    {
                        longestRow = current;
                        longestRowString = currentString;
                    }
                    else
                    {
                        current = 1;
                        currentString = matrix[row, col];
                    }
                }
            }
            if (current > longestRow)
            {
                longestRow = current;
                longestRowString = currentString;
            }
        }
    }

    private static void CheckLeftRightDiagonal(string[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int row = i;
            int col = 0;
            current = 1;
            currentString = matrix[row, col];
            while (row < matrix.GetLength(0) - 1)
            {
                row++;
                col++;
                if (matrix[row, col] == currentString)
                {
                    current++;
                }
                else
                {
                    if (current > longestDiagonal)
                    {
                        longestDiagonal = current;
                        longestDiagonalString = currentString;
                    }
                    current = 1;
                    currentString = matrix[row, col];
                }
            }
            if (current > longestDiagonal)
            {
                longestDiagonal = current;
                longestDiagonalString = currentString;
            }
        }

        for (int i = 1; i < matrix.GetLength(1); i++)
        {
            int col = i;
            int row = 0;
            current = 1;
            currentString = matrix[row, col];
            while (col < matrix.GetLength(1) - 1)
            {
                row++;
                col++;
                if (matrix[row, col] == currentString)
                {
                    current++;
                }
                else
                {
                    if (current > longestDiagonal)
                    {
                        longestDiagonal = current;
                        longestDiagonalString = currentString;
                    }
                    current = 1;
                    currentString = matrix[row, col];
                }
            }
            if (current > longestDiagonal)
            {
                longestDiagonal = current;
                longestDiagonalString = currentString;
            }
        }
    }

    private static void CheckRightLeftDiagonal(string[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int row = i;
            int col = matrix.GetLength(1)-1;
            current = 1;
            currentString = matrix[row, col];
            while (row < matrix.GetLength(0) - 1)
            {
                row++;
                col--;
                if (matrix[row, col] == currentString)
                {
                    current++;
                }
                else
                {
                    if (current > longestDiagonal)
                    {
                        longestDiagonal = current;
                        longestDiagonalString = currentString;
                    }
                    current = 1;
                    currentString = matrix[row, col];
                }
            }
            if (current > longestDiagonal)
            {
                longestDiagonal = current;
                longestDiagonalString = currentString;
            }
        }

        for (int i = 1; i < matrix.GetLength(1); i++)
        {
            int col = i;
            int row = 0;
            current = 1;
            currentString = matrix[row, col];
            while (col > 1)
            {
                row++;
                col--;
                if (matrix[row, col] == currentString)
                {
                    current++;
                }
                else
                {
                    if (current > longestDiagonal)
                    {
                        longestDiagonal = current;
                        longestDiagonalString = currentString;
                    }
                    current = 1;
                    currentString = matrix[row, col];
                }
            }
            if (current > longestDiagonal)
            {
                longestDiagonal = current;
                longestDiagonalString = currentString;
            }
        }
    }
}