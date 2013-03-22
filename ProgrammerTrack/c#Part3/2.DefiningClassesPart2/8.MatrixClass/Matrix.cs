using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 8. Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 
 * 9. Implement an indexer this[row, col] to access the inner matrix cells.
 * 10. Implement the operators + and - (addition and subtraction of matrices of the same size) 
 * and * for matrix multiplication. Throw an exception when the operation cannot be performed.
 * Implement the true operator (check for non-zero elements).
 */

class Matrix<T>
{
    private T[,] matrix;

    public Matrix(int rows, int cols)
    {
        this.matrix = new T[rows, cols];
    }

    public T this[int row, int col]
    {
        get
        {
            IsIndexInRange(row, col);
            return this.matrix[row, col];
        }
        set
        {
            IsIndexInRange(row, col);
            this.matrix[row, col] = value;
        }
    }

    public int GetRows()
    {
        return this.matrix.GetLength(0);
    }

    public int GetCols()
    {
        return this.matrix.GetLength(1);
    }

    public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
    {
        Matrix<T> result = new Matrix<T>(first.GetRows(), first.GetCols());
        if (first.GetRows() == second.GetRows() &&
            first.GetCols() == second.GetCols())
        {
            for (int row = 0; row < first.GetRows(); row++)
            {
                for (int col = 0; col < first.GetCols(); col++)
                {
                    result[row, col] = (dynamic)first[row, col] + (dynamic)second[row, col];
                }
            }
        }
        else
        {
            throw new ArgumentOutOfRangeException("Matrixes should have equal dimensions.");
        }
        return result;
    }

    public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
    {
        Matrix<T> result = new Matrix<T>(first.GetRows(), first.GetCols());
        if (first.GetRows() == second.GetRows() &&
            first.GetCols() == second.GetCols())
        {
            for (int row = 0; row < first.GetRows(); row++)
            {
                for (int col = 0; col < first.GetCols(); col++)
                {
                    result[row, col] = (dynamic)first[row, col] - (dynamic)second[row, col];
                }
            }
        }
        else
        {
            throw new ArgumentOutOfRangeException("Matrixes should have equal dimensions.");
        }
        return result;
    }

    public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
    {
        Matrix<T> result = new Matrix<T>(first.GetRows(), second.GetCols());
        if (first.GetCols() == second.GetRows())
        {
            for (int row = 0; row < result.GetRows(); row++)
            {
                for (int col = 0; col < result.GetCols(); col++)
                {
                    for (int i = 0; i < first.GetCols(); i++)
                    {
                        result[row, col] += (dynamic)first[row, i] * (dynamic)second[i, col];
                    }
                }
            }
        }
        else
        {
            throw new ArgumentOutOfRangeException("First matrix's col should be equal to second matrix's rows.");
        }
        return result;
    }

    public static bool operator true(Matrix<T> matrix)
    {
        for (int row = 0; row < matrix.GetRows(); row++)
        {
            for (int col = 0; col < matrix.GetCols(); col++)
            {
                if ((dynamic)matrix[row, col] != 0)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static bool operator false(Matrix<T> matrix)
    {
        return matrix ? false : true;
    }

    public static bool operator !(Matrix<T> matrix)
    {
        return matrix ? false : true;
    }

    private void IsIndexInRange(int row, int col)
    {
        if (!(0 <= row && row < this.matrix.GetLength(0)))
        {
            string message = String.Format("Row index should be equal to or greather than 0 and less than or equal to matrix size({0}).", this.matrix.GetLength(0));
            throw new ArgumentOutOfRangeException(message);
        }

        if(!(0 <= col && col < this.matrix.GetLength(1)))
        {
            string message = String.Format("Col index should be equal to or greather than 0 and less than or equal to matrix size({0}).", this.matrix.GetLength(1));
            throw new ArgumentOutOfRangeException(message);
        }

    }
}