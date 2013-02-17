using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/* 5. Write a program that reads a text file containing a square matrix
* of numbers and finds in the matrix an area of size 2 x 2 with a maximal sum
* of its elements. The first line in the input file contains the size of matrix N.
* Each of the next N lines contain N numbers separated by space.
* The output should be a single number in a separate text file.
*/
class MaximalPlatformInMatrix
{
    static long CalcMax2x2Platform(int[,] matrix)
    {
        long maxSum = 0;
        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                long currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }
        }
        return maxSum;
    }

    static void Main()
    {
        string inputFileName = "inputMatrix.txt";
        string outputFileName = "output.txt";
        StreamReader input = new StreamReader(inputFileName);
        StreamWriter output = new StreamWriter(outputFileName);

        try
        {
            int n = int.Parse(input.ReadLine());
            int[,] matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                string[] elements = input.ReadLine().Split();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = int.Parse(elements[col]);
                }
            }
            output.WriteLine(CalcMax2x2Platform(matrix));
        }
        finally
        {
            input.Dispose();
            output.Dispose();
            Console.WriteLine("Done!");
        }
    }
}