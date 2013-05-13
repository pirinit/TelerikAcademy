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
    static int allRemoved;
    static int[,] gameMatrix;
    static tower[,] resultMatrix;
    static List<tower> results;
    static StringBuilder sb = new StringBuilder();
    //using bigger matrix for the game data and not worry for IndexOutOfRangeException
    static int offset = 2;

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
            currentTower.efficiency = currentTower.removedRocks / (double)currentTower.moves;
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
        for (int row = 2; row < resultMatrix.GetLength(0) - 2; row++)
        {
            for (int col = 2; col < resultMatrix.GetLength(1) - 2; col++)
            {
                resultMatrix[row, col] = AnalyzeTower(row, col);
                results.Add(resultMatrix[row, col]);
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
        for (int row = 2; row < gameMatrix.GetLength(0) - 2; row++)
        {
            for (int col = 2; col < gameMatrix.GetLength(1) - 2; col++)
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
        for (int row = 2; row < resultMatrix.GetLength(0) - 2; row++)
        {
            for (int col = 2; col < resultMatrix.GetLength(1) - 2; col++)
            {
                Console.Write("{0,4} ", resultMatrix[row, col].efficiency);
            }
            Console.WriteLine();
        }
    }

    static void PlayGame()
    {
        int counter = 0;
        while (moves > 0)
        {
            if (gameMatrix[results[counter].row, results[counter].col] == 0)
            {
                counter++;
                continue;
            }
            if (gameMatrix[results[counter].targetNeighborRow, results[counter].targetNeighborCol] == 0)
            {
                counter++;
                continue;
            }
            //Console.WriteLine("{0} {1} {2} {3}", results[0].efficiency, results[0].moves, results[0].targetNeighbroRow-2, results[0].targetNeighbroCol-2);
            for (int i = 0; i < results[counter].moves; i++)
            {
                sb.AppendFormat("put {0} {1} {2} {3}\r\n", results[counter].row - 2, results[counter].col - 2, results[counter].efficiency, results[counter].moves);
                gameMatrix[results[counter].row, results[counter].col]++;
            }
            if (gameMatrix[results[counter].row, results[counter].col] == gameMatrix[results[counter].targetNeighborRow, results[counter].targetNeighborCol])
            {
                gameMatrix[results[counter].row, results[counter].col] = 0;
                gameMatrix[results[counter].targetNeighborRow, results[counter].targetNeighborCol] = 0;
            }
            moves -= results[counter].moves;
            allRemoved += results[counter].removedRocks;
            //PrintGameMatrix();
            counter++;
        }

    }

    static void ExportHTML()
    {
        StringBuilder output = new StringBuilder();
        output.Append(@"<html 5>
<head>
</head>
<body>
    <table border = '1' style = 'text-align:center'>");
        output.Append("\r\n");
        for (int row = 2; row < gameMatrix.GetLength(0) - 2; row++)
        {
            output.Append("    <tr>\r\n        ");
            for (int col = 2; col < gameMatrix.GetLength(1) - 2; col++)
            {
                output.AppendFormat("<td>{0}</td>", gameMatrix[row, col]);
            }
            output.Append("\r\n    </tr>\r\n");
            Console.WriteLine();
        }
        output.Append("</table>\r\n</body>");
        System.IO.StreamWriter file = new System.IO.StreamWriter("game.html");
        file.Write(output.ToString());
        file.Close();
    }
    static void Main()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        string input = Console.ReadLine();
        moves = int.Parse(input);
        input = Console.ReadLine();
        n = int.Parse(input);
        gameMatrix = new int[n + offset * 2, n + offset * 2];
        resultMatrix = new tower[n + offset * 2, n + offset * 2];
        results = new List<tower>();
        allRemoved = 0;
        n += offset;
        ReadMatrix();
        ExportHTML();
        AnalyzeMatrix();
        results.Sort();
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
        Console.WriteLine("RunTime {0} and removed rocks {1}", elapsedTime, allRemoved);
    }


}