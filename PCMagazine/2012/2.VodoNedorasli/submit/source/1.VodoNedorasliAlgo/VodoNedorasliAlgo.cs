using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

class VodoNedorasliAlgo
{
    static byte[,] gameMatrix;
    static int[,] integralMatrix;
    static int t, n, v;
    static Patern spaceFiller, spaceFillerNeg;
    static Patern gliderToEast, gliderToWest, gliderToNord, gliderToSouth;
    static Patern uShape, uShapeNeg;

    static void InitPaterns()
    {
        spaceFiller = new Patern(26, 49, 200);
        spaceFiller.patern[0] = "                    111   111";
        spaceFiller.patern[1] = "                   1  1   1  1";
        spaceFiller.patern[2] = "1111                  1   1                  1111";
        spaceFiller.patern[3] = "1   1                 1   1                 1   1";
        spaceFiller.patern[4] = "1        1            1   1            1        1";
        spaceFiller.patern[5] = " 1  1  11  1                         1  11  1  1";
        spaceFiller.patern[6] = "      1     1       111   111       1     1";
        spaceFiller.patern[7] = "      1     1        1     1        1     1";
        spaceFiller.patern[8] = "      1     1        1111111        1     1";
        spaceFiller.patern[9] = " 1  1  11  1  11    1       1    11  1  11  1  1";
        spaceFiller.patern[10] = "1        1   11    11111111111    11   1        1";
        spaceFiller.patern[11] = "1   1         11                 11         1   1";
        spaceFiller.patern[12] = "1111           1111111111111111111           1111";
        spaceFiller.patern[13] = "                1 1           1 1";
        spaceFiller.patern[14] = "                   11111111111";
        spaceFiller.patern[15] = "                   1         1";
        spaceFiller.patern[16] = "                    111111111";
        spaceFiller.patern[17] = "                        1";
        spaceFiller.patern[18] = "                    111   111";
        spaceFiller.patern[19] = "                      1   1";
        spaceFiller.patern[20] = "";
        spaceFiller.patern[21] = "                     111 111";
        spaceFiller.patern[22] = "                     111 111";
        spaceFiller.patern[23] = "                    1 11 11 1";
        spaceFiller.patern[24] = "                    111   111";
        spaceFiller.patern[25] = "                     1     1";

        spaceFillerNeg = new Patern(34, 57, 782);
        spaceFillerNeg.patern[0] = "111111111111111111111111111111111111111111111111111111111";
        spaceFillerNeg.patern[1] = "111111111111111111111 11  11  11  11111111111111111111111";
        spaceFillerNeg.patern[2] = "1111111111111111111111             1111111111111111111111";
        spaceFillerNeg.patern[3] = "11  11  11111111111111             111111111111  11  1111";
        spaceFillerNeg.patern[4] = "1         11111111111   111   111   11111111111         1";
        spaceFillerNeg.patern[5] = "1           11  11111  1  1   1  1  1111111  11         1";
        spaceFillerNeg.patern[6] = "11  1111          111     1   1     11111        1111  11";
        spaceFillerNeg.patern[7] = "11  1   1          111    1   1    1111         1   1  11";
        spaceFillerNeg.patern[8] = "1   1              111    1   1    111     1        1   1";
        spaceFillerNeg.patern[9] = "1    1  1  11  1                         1  11  1  1    1";
        spaceFillerNeg.patern[10] = "11        1     1       111   111       1     1        11";
        spaceFillerNeg.patern[11] = "11        1     1        1     1        1     1        11";
        spaceFillerNeg.patern[12] = "1         1     1        1111111        1     1       111";
        spaceFillerNeg.patern[13] = "1    1  1  11  1  11    1       1    11  1  11  1  1   11";
        spaceFillerNeg.patern[14] = "11  1        1   11    11111111111    11   1        1  11";
        spaceFillerNeg.patern[15] = "11  1   1         11                 11         1   1   1";
        spaceFillerNeg.patern[16] = "1   1111           1111111111111111111           1111   1";
        spaceFillerNeg.patern[17] = "1         11        1 1           1 1      11          11";
        spaceFillerNeg.patern[18] = "11        1111 1       11111111111       111111        11";
        spaceFillerNeg.patern[19] = "11    11 11111111      1         1     1111111111  11 111";
        spaceFillerNeg.patern[20] = "111 11111111111111      111111111    11111111111111111111";
        spaceFillerNeg.patern[21] = "11111111111111111111        1        11111111111111111111";
        spaceFillerNeg.patern[22] = "111111111111111111111   111   111   111111111111111111111";
        spaceFillerNeg.patern[23] = "111111111111111111111     1   1     111111111111111111111";
        spaceFillerNeg.patern[24] = "1111111111111111111111               11111111111111111111";
        spaceFillerNeg.patern[25] = "1111111111111111111111   111 111     11111111111111111111";
        spaceFillerNeg.patern[26] = "111111111111111111111    111 111    111111111111111111111";
        spaceFillerNeg.patern[27] = "111111111111111111111   1 11 11 1   111111111111111111111";
        spaceFillerNeg.patern[28] = "1111111111111111111111  111   111  1111111111111111111111";
        spaceFillerNeg.patern[29] = "1111111111111111111111   1     1   1111111111111111111111";
        spaceFillerNeg.patern[30] = "11111111111111111111111             111111111111111111111";
        spaceFillerNeg.patern[31] = "11111111111111111111111     11      111111111111111111111";
        spaceFillerNeg.patern[32] = "111111111111111111111111  111111  11111111111111111111111";
        spaceFillerNeg.patern[33] = "111111111111111111111111111111111111111111111111111111111";

        gliderToEast = new Patern(4, 5, 9);
        gliderToEast.patern[0] = "1  1 ";
        gliderToEast.patern[1] = "    1";
        gliderToEast.patern[2] = "1   1";
        gliderToEast.patern[3] = " 1111";

        gliderToWest = new Patern(4, 5, 9);
        gliderToWest.patern[0] = " 1  1";
        gliderToWest.patern[1] = "1    ";
        gliderToWest.patern[2] = "1   1";
        gliderToWest.patern[3] = "1111 ";

        gliderToSouth = new Patern(5, 4, 9);
        gliderToSouth.patern[0] = " 1 1";
        gliderToSouth.patern[1] = "1   ";
        gliderToSouth.patern[2] = "1   ";
        gliderToSouth.patern[3] = "1  1";
        gliderToSouth.patern[4] = "111 ";

        gliderToNord = new Patern(5, 4, 9);
        gliderToNord.patern[0] = " 111";
        gliderToNord.patern[1] = "1  1";
        gliderToNord.patern[2] = "   1";
        gliderToNord.patern[3] = "   1";
        gliderToNord.patern[4] = "1 1 ";

        uShape = new Patern(3, 3, 7);
        uShape.patern[0] = "1 1";
        uShape.patern[1] = "1 1";
        uShape.patern[2] = "111";

        uShapeNeg = new Patern(9, 9, 60);
        uShapeNeg.patern[0] = " 11  11  ";
        uShapeNeg.patern[1] = "         ";
        uShapeNeg.patern[2] = "1       1";
        uShapeNeg.patern[3] = "1  1 1  1";
        uShapeNeg.patern[4] = "   1 1   ";
        uShapeNeg.patern[5] = "   111   ";
        uShapeNeg.patern[6] = "1       1";
        uShapeNeg.patern[7] = "1       1";
        uShapeNeg.patern[8] = "   11    ";
    }

    static void ReadGameMatrix()
    {
        string input;
        for (int row = 1; row <= n; row++)
        {
            input = Console.ReadLine();
            for (int col = 1; col <= n; col++)
            {
                if (input[col - 1] == 'F')
                {
                    gameMatrix[row, col] = 2;
                }
                else if (input[col - 1] == '1')
                {
                    gameMatrix[row, col] = 1;
                }
            }
        }
    }

    public static void PrintMatrix(byte[,] matrix)
    {
        StringBuilder sb = new StringBuilder();
        for (int row = 1; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 1; col < matrix.GetLength(0) - 1; col++)
            {
                if (matrix[row, col] != 0)
                {
                    sb.AppendFormat("o", matrix[row, col]);
                }
                else
                {
                    sb.Append(' ');
                }
            }
            sb.AppendLine();
        }
        Console.WriteLine(sb);
    }

    public static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                Console.Write("{0}", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }

    public static void PrintFinalMatrix(byte[,] matrix)
    {
        StringBuilder sb = new StringBuilder();
        for (int row = 1; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 1; col < matrix.GetLength(0) - 1; col++)
            {
                char c;
                switch(matrix[row, col])
                {
                    case 1:
                        c = '+';
                        break;
                    case 2:
                        c = 'F';
                        break;
                    default:
                        c = '0';
                        break;
                }
                sb.Append(c);
            }
            sb.AppendLine();
        }
        Console.Write(sb);
    }

    static void CreateIntegralMatrix()
    {
        for (int row = 1; row < integralMatrix.GetLength(0) - 1; row++)
        {
            for (int col = 1; col < integralMatrix.GetLength(1) - 1; col++)
            {
                integralMatrix[row, col] = integralMatrix[row, col - 1] + integralMatrix[row - 1, col] - integralMatrix[row - 1, col - 1] + gameMatrix[row, col] / 2;
            }
        }
    }

    static int CalcFoodQuantity(int upperRow, int upperCol, int lowerRow, int lowerCol)
    {
        lowerRow++;
        lowerCol++;
        int result = integralMatrix[lowerRow, lowerCol] - integralMatrix[lowerRow, upperCol] - integralMatrix[upperRow, lowerCol] + integralMatrix[upperRow, upperCol];
        return result;
    }

    static void ApplyPatern(Patern patern, int startRow, int startCol, byte[,] destinationMatrix)
    {
        for (int row = 0; row < patern.height; row++)
        {
            for (int col = 0; col < patern.patern[row].Length; col++)
            {
                if (patern.patern[row][col] == '1')
                {
                    destinationMatrix[startRow + row + 1, startCol + col + 1] = 1;
                }
            }
        }
    }

    static void Main()
    {
        //Console.SetBufferSize(1002, 1002);
        Stopwatch stopWatch = new Stopwatch();
        //stopWatch.Start();

        string input = Console.ReadLine();
        t = int.Parse(input);
        input = Console.ReadLine();
        v = int.Parse(input);
        input = Console.ReadLine();
        n = int.Parse(input);
        gameMatrix = new byte[n + 2, n + 2];
        integralMatrix = new int[n + 2, n + 2];
        InitPaterns();

        ReadGameMatrix();
        //stopWatch.Start();
        //CreateIntegralMatrix();
        if (v >= 200 && n>50)
        {
            int col = (gameMatrix.GetLength(0) - spaceFiller.width) / 2;
            int row = (gameMatrix.GetLength(1) - spaceFiller.height) / 2;
            ApplyPatern(spaceFiller, row, col, gameMatrix);
            v -= spaceFiller.cellsNeeded;
            RemainingCells filler1 = new RemainingCells(gameMatrix, 1);
            RemainingCells filler2 = new RemainingCells(gameMatrix, 2);
            RemainingCells filler3 = new RemainingCells(gameMatrix, 3);
            RemainingCells filler4 = new RemainingCells(gameMatrix, 4);
            for (int i = 0; i < v / 4; i++)
            {
                filler1.Go(1);
                filler2.Go(1);
                filler3.Go(1);
                filler4.Go(1);
            }
            filler1.Go(v % 4);
        }
        else if (v >= 7)
        {
            int col = (gameMatrix.GetLength(0) - uShape.width) / 2;
            int row = (gameMatrix.GetLength(1) - uShape.height) / 2;
            ApplyPatern(uShape, row, col, gameMatrix);
            v -= uShape.cellsNeeded;
            RemainingCells filler1 = new RemainingCells(gameMatrix, 1);
            RemainingCells filler2 = new RemainingCells(gameMatrix, 2);
            RemainingCells filler3 = new RemainingCells(gameMatrix, 3);
            RemainingCells filler4 = new RemainingCells(gameMatrix, 4);
            for (int i = 0; i < v / 4; i++)
            {
                filler1.Go(1);
                filler2.Go(1);
                filler3.Go(1);
                filler4.Go(1);
            }
            filler1.Go(v % 4);
        }
        else
        {
            RemainingCells filler1 = new RemainingCells(gameMatrix, 1);
            filler1.Go(v);
        }
        //ApplyPatern(GliderToEast, 51, 45, gameMatrix);
        //ApplyPatern(USouth, 10, 10, gameMatrix);
        //Console.Clear();
        PrintFinalMatrix(gameMatrix);
        //stopWatch.Stop();
        //TimeSpan ts = stopWatch.Elapsed;

        // Format and display the TimeSpan value. 
        //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
        //    ts.Hours, ts.Minutes, ts.Seconds,
        //    ts.Milliseconds / 10);
        //Console.WriteLine("RunTime " + elapsedTime);
        //Console.ReadLine();
        //Console.WriteLine();
        //PrintMatrix(integralMatrix);
        //Console.WriteLine(CalcFoodQuantity(3,3,6,6));
        //Console.WriteLine("T = {0}, N = {1}, V = {2}", t, n, v);
    }
}