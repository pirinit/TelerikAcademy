using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;

class TilesOrderer
{
    public const int GameFieldSize = 500;
    static List<Tile> tiles;
    static bool[,] gameField;
    static void Main()
    {
        //Stopwatch sw = new Stopwatch();
        //sw.Start();
        tiles = new List<Tile>();
        gameField = new bool[GameFieldSize + 2, GameFieldSize + 2];
        int maxRow = GameFieldSize + 1;
        int maxCol = GameFieldSize + 1;
        for (int row = 0; row < gameField.GetLength(0); row++)
        {
            gameField[row, 0] = true;
            gameField[row, maxCol] = true;
        }

        for (int col = 0; col < gameField.GetLength(0); col++)
        {
            gameField[0, col] = true;
            gameField[maxRow, col] = true;
        }

        ReadInput();
        ArrangeTiles();
        //sw.Stop();
        //Console.WriteLine(sw.ElapsedMilliseconds);
        PrintResult();
    }

    static void ReadInput()
    {
        Tile current = new Vline(5, 5, gameField);
        string input = Console.ReadLine();
        int n = int.Parse(input);

        string[] inputs;
        for (int i = 0; i < n; i++)
        {
            input = Console.ReadLine();
            inputs = input.Split();
            int row = int.Parse(inputs[1]) + 1;
            int col = int.Parse(inputs[2]) + 1;

            switch (inputs[0])
            {
                case "ninetile":
                    current = new Ninetile(row, col, gameField);
                    break;
                case "plus":
                    current = new Plus(row, col, gameField);
                    break;
                case "hline":
                    current = new Hline(row, col, gameField);
                    break;
                case "vline":
                    current = new Vline(row, col, gameField);
                    break;
                case "angle-ur":
                    current = new AngleUR(row, col, gameField);
                    break;
                case "angle-dr":
                    current = new AngleDR(row, col, gameField);
                    break;
                case "angle-dl":
                    current = new AngleDL(row, col, gameField);
                    break;
                case "angle-ul":
                    current = new AngleUL(row, col, gameField);
                    break;
            }

            tiles.Add(current);
        }
    }

    static void ArrangeTiles()
    {
        foreach (var tile in tiles)
        {
            if (tile.IsPlacePossible(tile.row, tile.col))
            {
                tile.Place();
            }
        }
        foreach (var tile in tiles)
        {
            if (!tile.isFixed)
            {
                FindPlace(tile);
            }
        }
    }

    static void FindPlace(Tile tile)
    {
        bool[,] visited = new bool[GameFieldSize + 2, GameFieldSize + 2];
        Queue<int> rows = new Queue<int>();
        Queue<int> cols = new Queue<int>();

        rows.Enqueue(tile.row);
        cols.Enqueue(tile.col);

        while (rows.Count > 0)
        {
            int currentRow = rows.Dequeue();
            int currentCol = cols.Dequeue();
            if (visited[currentRow, currentCol])
            {
                continue;
            }

            bool outsideOfGameField = currentRow < 1 || GameFieldSize + 1 < currentRow ||
                currentCol < 1 || GameFieldSize + 1 < currentCol;
            if (outsideOfGameField)
            {
                continue;
            }
            
            visited[currentRow, currentCol] = true;

            if (tile.IsPlacePossible(currentRow, currentCol))
            {
                tile.row = currentRow;
                tile.col = currentCol;
                tile.Place();
                return;
            }

            rows.Enqueue(currentRow);
            cols.Enqueue(currentCol - 1);

            rows.Enqueue(currentRow);
            cols.Enqueue(currentCol + 1);

            rows.Enqueue(currentRow - 1);
            cols.Enqueue(currentCol);

            rows.Enqueue(currentRow + 1);
            cols.Enqueue(currentCol);
        }
    }

    static void PrintResult()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var tile in tiles)
        {
            sb.AppendFormat("{0} {1}", tile.row - 1, tile.col - 1);
            sb.AppendLine();
        }

        Console.WriteLine(sb.ToString());
    }
}