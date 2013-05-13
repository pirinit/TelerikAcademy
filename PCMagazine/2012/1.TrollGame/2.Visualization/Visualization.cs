using System;
using System.IO;

class Visualization
{
    public class Move
    {
        public int row;
        public int col;
        public int rocks;
    }
    static int n;
    static int moves;
    static int[,] gameMatrix;
    static Move[] allMoves;

    static void ReadMatrix()
    {
        string[] inputs;
        for (int i = 0; i < n; i++)
        {
            inputs = Console.ReadLine().Split();
            for (int j = 0; j < n; j++)
            {
                gameMatrix[i, j] = int.Parse(inputs[j]);
            }
        }
    }

    static void ReadAllMoves()
    {
        string input;
        string[] inputs;
        for (int i = 0; i < moves; i++)
        {
            input = Console.ReadLine();
            inputs = input.Split();
            allMoves[i] = new Move();
            if (inputs[0] == "take")
            {
                allMoves[i].rocks = -1;
            }
            else
            {
                allMoves[i].rocks = 1;
            }
            allMoves[i].row = int.Parse(inputs[1]);
            allMoves[i].col = int.Parse(inputs[2]);
        }
    }

    static void ExportJS()
    {
        StreamWriter file = new StreamWriter("GameData.js");
        using (file)
        {
            file.WriteLine("function SetInitialPossition()");
            file.WriteLine("{");
            file.WriteLine("    removedRocks = 0;");
            file.WriteLine("    turnNumber = 0;");
            for (int row = 0; row < n; row++)
            {
                file.Write("    m[{0}] = new Array(", row);
                for (int col = 0; col < n; col++)
                {
                    if (col != n - 1)
                    {
                        file.Write("{0}, ", gameMatrix[row, col]);
                    }
                    else
                    {
                        file.WriteLine("{0});", gameMatrix[row, col]);
                    }
                }
            }
            for (int i = 0; i < allMoves.Length; i++)
            {
                file.WriteLine("    turns[{0}] = new Array({1}, {2}, {3});", i, allMoves[i].rocks, allMoves[i].row, allMoves[i].col);
            }
            file.WriteLine("}");
        }
    }

    //sample GameData.js file
    //function SetInitialPossition()
    //{
    //    removedRocks = 0;
    //    matrixSize = 30;
    //    turnNumber = 0;
    //    m[0] = new Array(5, 10, 55, 44, 33, 23, 5, 12, 88, 71);
    //    turns[0] = new Array(1, 2, 2);
    //}

    static void Main()
    {

        string input = Console.ReadLine();
        moves = int.Parse(input);
        input = Console.ReadLine();
        n = int.Parse(input);
        gameMatrix = new int[n, n];
        allMoves = new Move[moves];
        ReadMatrix();
        ReadAllMoves();
        ExportJS();
    }
}