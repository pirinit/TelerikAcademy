using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Test
{
    const int Rows = 2;
    const int Cols = 2;
    static void Main(string[] args)
    {
        Matrix<int> matrixA = new Matrix<int>(Rows, Cols);
        Matrix<int> matrixB = new Matrix<int>(Rows, Cols);

        int counter = 0;
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Cols; col++)
            {
                matrixA[row, col] = counter++;

                matrixB[row, col] = counter++;
            }
        }

        Matrix<int> matrixC = matrixA * matrixB;


        PrintMatrix(matrixA);
        Console.WriteLine();
        PrintMatrix(matrixB);
        Console.WriteLine();
        PrintMatrix(matrixC);

        Console.WriteLine(!matrixC ? true : false);
        Console.WriteLine(matrixC ? true : false);

    }

    static void PrintMatrix(Matrix<int> matrix)
    {
        StringBuilder output = new StringBuilder();
        for (int row = 0; row < matrix.GetRows(); row++)
        {
            output.Append("{");
            for (int col = 0; col < matrix.GetCols(); col++)
            {
                output.AppendFormat(" {0},", matrix[row, col]);
            }
            output.AppendLine("\x0008 }");
        }
        Console.Write(output);
    }
}