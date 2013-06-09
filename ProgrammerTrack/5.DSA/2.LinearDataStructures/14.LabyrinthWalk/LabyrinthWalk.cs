using System;
using System.Collections.Generic;

/* 14. * We are given a labyrinth of size N x N.
 * Some of its cells are empty (0) and some are full (x).
 * We can move from an empty cell to another empty cell
 * if they share common wall. Given a starting position (*)
 * calculate and fill in the array the minimal distance
 * from this position to any other cell in the array.
 * Use "u" for all unreachable cells.
 */
public class LabyrinthWalk
{
    public const string StartPoint = "*";
    public const string UnreachableCell = "u";
    public const string FreeCell = "0";
    static void Main()
    {
        string[,] labyrinth = new string[,] { 
            {"0", "0", "0", "x", "0", "x"},
            {"0", "x", "0", "x", "0", "x"},
            {"0", StartPoint, "x", "0", "x", "0"},
            {"0", "x", "0", "0", "0", "0"},
            {"0", "0", "0", "x", "x", "0"},
            {"0", "0", "0", "x", "0", "x"},
        };

        PrintLabyrinth(labyrinth);
        CalcLabirinthDistances(labyrinth);
        MarkUnreachableCells(labyrinth);
        Console.WriteLine();
        PrintLabyrinth(labyrinth);
    }

    private static void CalcLabirinthDistances(string[,] labyrinth)
    {
        Point start = FindStartingPoint(labyrinth);

        Queue<Point> toVisit = new Queue<Point>();

        toVisit.Enqueue(start);

        while (toVisit.Count > 0)
        {
            Point current = toVisit.Dequeue();

            // mark curent cell as visited and place distance from start
            if (labyrinth[current.Row, current.Col] != StartPoint)
            {
                labyrinth[current.Row, current.Col] = current.DistanceFromStart.ToString();
            }

            //try to visit neighboring cells
            TryVisitCell(current.Row, current.Col - 1, current.DistanceFromStart, labyrinth, toVisit);
            TryVisitCell(current.Row, current.Col + 1, current.DistanceFromStart, labyrinth, toVisit);
            TryVisitCell(current.Row - 1, current.Col, current.DistanceFromStart, labyrinth, toVisit);
            TryVisitCell(current.Row + 1, current.Col, current.DistanceFromStart, labyrinth, toVisit);
        }
    }

    private static void TryVisitCell(int row, int col, int distance, string[,] labyrinth, Queue<Point> toVisit)
    {
        // validate coords
        if (row < 0 || labyrinth.GetLength(0) - 1 < row ||
            col < 0 || labyrinth.GetLength(1) - 1 < col)
        {
            return;
        }

        //check if cell is empty
        if (labyrinth[row, col] == FreeCell)
        {
            toVisit.Enqueue(new Point(row, col, distance + 1));
        }
    }

    private static Point FindStartingPoint(string[,] labyrinth)
    {
        for (int row = 0; row < labyrinth.GetLength(0); row++)
        {
            for (int col = 0; col < labyrinth.GetLength(1); col++)
            {
                if (labyrinth[row, col] == StartPoint)
                {
                    return new Point(row, col, 0);
                }
            }
        }

        string message = string.Format("The labyrinth does not contains a starting point({0}).", StartPoint);
        throw new ArgumentException(message);
    }

    private static void MarkUnreachableCells(string[,] labyrinth)
    {
        for (int row = 0; row < labyrinth.GetLength(0); row++)
        {
            for (int col = 0; col < labyrinth.GetLength(1); col++)
            {
                if (labyrinth[row, col] == FreeCell)
                {
                    labyrinth[row, col] = UnreachableCell;
                }
            }
        }
    }

    private static void PrintLabyrinth(string[,] labyrinth)
    {
        for (int row = 0; row < labyrinth.GetLength(0); row++)
        {
            for (int col = 0; col < labyrinth.GetLength(1); col++)
            {
                Console.Write("{0,4}", labyrinth[row,col]);
            }
            Console.WriteLine();
        }
    }
}