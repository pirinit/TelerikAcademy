using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GOL
{
    byte[,] matrix;
    byte[,] nextMatrix;
    byte[,] tempMatrix;
    int generations;
    int v;

    public int CalcNeighbors(int row, int col)
    {
        int result = 0;
        if (matrix[row - 1, col - 1] == 1) result++;
        if (matrix[row - 1, col] == 1) result++;
        if (matrix[row - 1, col + 1] == 1) result++;

        if (matrix[row, col - 1] == 1) result++;
        if (matrix[row, col + 1] == 1) result++;

        if (matrix[row + 1, col - 1] == 1) result++;
        if (matrix[row + 1, col] == 1) result++;
        if (matrix[row + 1, col + 1] == 1) result++;
        return result;
    }

    public int Play()
    {
        int generation = 1;
        int endPopulation = v;
        int minVitalPopulation = v / 2;
        int foodEaten = 0;
        while (generation<=generations)
        {
            endPopulation = 0;
            int minRow = 1;
            int maxRow = matrix.GetLength(0) - 1;
            int minCol = 1;
            int maxCol = matrix.GetLength(0) - 1;
            for (int row = minRow; row < maxRow; row++)
            {
                for (int col = minCol; col < maxCol; col++)
                {
                    int neighbors = CalcNeighbors(row, col);
                    if(matrix[row,col] == 1)
                    {
                        if (neighbors == 2 || neighbors == 3)
                        {
                            endPopulation++;
                            nextMatrix[row, col] = 1;
                        }
                        else
                        {
                            nextMatrix[row, col] = 0;
                        }
                    }
                    else if (matrix[row, col] == 0)
                    {
                        if (neighbors == 3)
                        {
                            endPopulation++;
                            nextMatrix[row, col] = 1;
                        }
                        else
                        {
                            nextMatrix[row, col] = 0;
                        }
                    }
                    else
                    {
                        if (neighbors == 3)
                        {
                            foodEaten++;
                            endPopulation++;
                            nextMatrix[row, col] = 1;
                        }
                        else
                        {
                            nextMatrix[row, col] = 2;
                        }
                    }

                }
            }
            tempMatrix = nextMatrix;
            nextMatrix = matrix;
            matrix = tempMatrix;
            Console.Clear();
            VodoNedorasliAlgo.PrintMatrix(matrix);
            Console.WriteLine("Generation = {3}, EndPopulation = {0}, FoodEaten = {1}, MinVitalPopulation = {2}", endPopulation, foodEaten, minVitalPopulation, generation);
            generation++;
            Console.ReadLine();
            //if (endPopulation < minVitalPopulation)
            //{
            //    endPopulation = 0;
            //    foodEaten = 0;
            //    break;
            //}
        }
        return (endPopulation + foodEaten);
    }

    public GOL(byte[,] inputMatrix, int generations, int v)
    {
        this.matrix = new byte[inputMatrix.GetLength(0), inputMatrix.GetLength(0)];
        this.nextMatrix = new byte[inputMatrix.GetLength(0), inputMatrix.GetLength(0)];
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                matrix[row, col] = inputMatrix[row, col];
            }
        }
        this.generations = generations;
        this.v = v;
    }
}
