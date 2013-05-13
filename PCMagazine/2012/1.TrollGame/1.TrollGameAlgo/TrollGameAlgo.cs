using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;
using System.Diagnostics;
using System.Threading;
using System.Text;

class TrollGameAlgo
{
    class tower : IComparable<tower>
    {
        public int moves;
        public double efficiency;
        public int targetNeighborRow;
        public int targetNeighborCol;
        public int row;
        public int col;
        public int removedRocks;
        public tower(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
        public int CompareTo(tower other)
        {
            if (this.efficiency == other.efficiency)
            {
                return this.moves.CompareTo(other.moves);
            }
            else
            {
                return ((this.efficiency < other.efficiency) ? 1 : -1);
            }
        }
    }

    static int n;
    static int moves;
    public static int[,] gameMatrix;
    static tower[,] resultMatrix;
    static OrderedBag<tower> results;
    static StringBuilder sb = new StringBuilder();
    //using bigger matrix for the game data and not worry for IndexOutOfRangeException
    public static int offset = 2;

    static tower AnalyzeTower(int row, int col)
    {
        tower currentTower = new tower(row, col);
        int currentHeight = gameMatrix[row, col];
        int neighborHeight = 1001;
        if (gameMatrix[row - 1, col] > currentHeight && gameMatrix[row - 1, col] < neighborHeight)
        {
            neighborHeight = gameMatrix[row - 1, col];
            currentTower.targetNeighborRow = row - 1;
            currentTower.targetNeighborCol = col;
        }
        if (gameMatrix[row, col + 1] > currentHeight && gameMatrix[row, col + 1] < neighborHeight)
        {
            neighborHeight = gameMatrix[row, col + 1];
            currentTower.targetNeighborRow = row;
            currentTower.targetNeighborCol = col + 1;
        }
        if (gameMatrix[row + 1, col] > currentHeight && gameMatrix[row + 1, col] < neighborHeight)
        {
            neighborHeight = gameMatrix[row + 1, col];
            currentTower.targetNeighborRow = row + 1;
            currentTower.targetNeighborCol = col;
        }
        if (gameMatrix[row, col - 1] > currentHeight && gameMatrix[row, col - 1] < neighborHeight)
        {
            neighborHeight = gameMatrix[row, col - 1];
            currentTower.targetNeighborRow = row;
            currentTower.targetNeighborCol = col - 1;
        }
        if (neighborHeight != 1001)
        {
            currentTower.moves = neighborHeight - currentHeight;
            currentTower.removedRocks = neighborHeight + currentHeight;
            currentTower.efficiency = currentTower.removedRocks / (double) currentTower.moves;
        }
        else
        {
            currentTower.moves = neighborHeight - currentHeight;
            currentTower.removedRocks = neighborHeight + currentHeight;
            currentTower.efficiency = -1;
        }
        return currentTower;
    }

    static void AnalyzeMatrix()
    {
        for (int row = 2; row < resultMatrix.GetLength(0)-2; row++)
        {
            for (int col = 2; col < resultMatrix.GetLength(1)-2; col++)
            {
                resultMatrix[row, col] = AnalyzeTower(row, col);
                results.Add(resultMatrix[row,col]);
            }
        }
    }

    static void ReadMatrix()
    {
        string[] inputs;
        for (int i = offset; i < n; i++)
        {
            inputs = Console.ReadLine().Split();
            for (int j = offset; j < n; j++)
            {
                gameMatrix[i, j] = int.Parse(inputs[j - offset]);
            }
        }
    }

    static void PrintGameMatrix()
    {
        for (int row = 2; row < gameMatrix.GetLength(0)-2; row++)
        {
            for (int col = 2; col < gameMatrix.GetLength(1)-2; col++)
            {
                if (gameMatrix[row, col] != 0)
                {
                    Console.Write("{0,4} ", gameMatrix[row, col]);
                }
                else
                {
                    Console.Write("     ");
                }
            }
            Console.WriteLine();
        }
    }

    static void PrintResultMatrix()
    {
        for (int row = 2; row < resultMatrix.GetLength(0)-2; row++)
        {
            for (int col = 2; col < resultMatrix.GetLength(1)-2; col++)
            {
                Console.Write("{0,4} ", resultMatrix[row,col].efficiency);
            }
            Console.WriteLine();
        }
    }

    static void PlayGame()
    {
        while (moves > 0)
        {
            if (gameMatrix[results[0].row, results[0].col] == 0)
            {
                results.RemoveFirst();
                continue;
            }
            if (gameMatrix[results[0].targetNeighborRow, results[0].targetNeighborCol] == 0)
            {
                results.Add(AnalyzeTower(results[0].row, results[0].col));
                results.RemoveFirst();
                continue;
            }
            //Console.WriteLine("{0} {1} {2} {3}", results[0].efficiency, results[0].moves, results[0].targetNeighbroRow-2, results[0].targetNeighbroCol-2);
            for (int i = 0; i < results[0].moves; i++)
            {
                sb.AppendFormat("put {0} {1} {2} {3}\r\n", results[0].row - 2, results[0].col - 2, results[0].efficiency, results[0].moves);
                gameMatrix[results[0].row, results[0].col]++;
            }
            if (gameMatrix[results[0].row, results[0].col] == gameMatrix[results[0].targetNeighborRow, results[0].targetNeighborCol])
            {
                gameMatrix[results[0].row, results[0].col] = 0;
                gameMatrix[results[0].targetNeighborRow, results[0].targetNeighborCol] = 0;
            }
            moves -= results[0].moves;
            //PrintGameMatrix();
            results.RemoveFirst();
        }

    }

    static void Main()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        string input = Console.ReadLine();
        moves = int.Parse(input);
        input = Console.ReadLine();
        n = int.Parse(input);
        gameMatrix = new int[n+offset*2,n+offset*2];
        resultMatrix = new tower[n + offset * 2, n + offset * 2];
        results = new OrderedBag<tower>();
        n += offset;
        ReadMatrix();
        AnalyzeMatrix();
       // Console.WriteLine();
        PlayGame();
        //Console.WriteLine();
        //PrintResultMatrix();
        Console.WriteLine(sb);
        stopWatch.Stop();
        TimeSpan ts = stopWatch.Elapsed;

        // Format and display the TimeSpan value. 
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine("RunTime " + elapsedTime);
    }

   
}