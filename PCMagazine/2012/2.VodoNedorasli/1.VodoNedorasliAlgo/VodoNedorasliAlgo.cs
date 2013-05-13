using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

class VodoNedorasliAlgo
{
    static byte[,] gameMatrix;
    static byte[,] foodMatrix;
    static int[,] integralMatrix;
    static int t, n, v, vSafe;
    static Patern spaceFiller, spaceFillerNeg;
    static Patern gliderToEast, gliderToWest, gliderToNord, gliderToSouth;
    static Patern uShape, uShapeNeg;
    static Patern square, rPantomino, blinker, fiveCells;

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

        spaceFillerNeg = new Patern(36, 59, 882);
        spaceFillerNeg.patern[0] = " 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 ";
        spaceFillerNeg.patern[1] = " 111111111111111111111111111111111111111111111111111111111 ";
        spaceFillerNeg.patern[2] = " 111111111111111111111 11  11  11  11111111111111111111111 ";
        spaceFillerNeg.patern[3] = "11111111111111111111111             11111111111111111111111";
        spaceFillerNeg.patern[4] = " 11  11  11111111111111             111111111111  11  1111 ";
        spaceFillerNeg.patern[5] = "11         11111111111   111   111   11111111111         11";
        spaceFillerNeg.patern[6] = " 1           11  11111  1  1   1  1  1111111  11         1 ";
        spaceFillerNeg.patern[7] = "111  1111          111     1   1     11111        1111  111";
        spaceFillerNeg.patern[8] = " 11  1   1          111    1   1    1111         1   1  11 ";
        spaceFillerNeg.patern[9] = "11   1        1     111    1   1    111     1        1   11";
        spaceFillerNeg.patern[10] = " 1    1  1  11  1                         1  11  1  1    1 ";
        spaceFillerNeg.patern[11] = "111        1     1       111   111       1     1        111";
        spaceFillerNeg.patern[12] = " 11        1     1        1     1        1     1        11 ";
        spaceFillerNeg.patern[13] = "11         1     1        1111111        1     1       1111";
        spaceFillerNeg.patern[14] = " 1    1  1  11  1  11    1       1    11  1  11  1  1   11 ";
        spaceFillerNeg.patern[15] = "111  1        1   11    11111111111    11   1        1  111";
        spaceFillerNeg.patern[16] = " 11  1   1         11                 11         1   1   1 ";
        spaceFillerNeg.patern[17] = "11   1111           1111111111111111111           1111   11";
        spaceFillerNeg.patern[18] = " 1         11        1 1           1 1      11          11 ";
        spaceFillerNeg.patern[19] = "111        1111 1       11111111111       111111        111";
        spaceFillerNeg.patern[20] = " 11    11 11111111      1         1     1111111111  11 111 ";
        spaceFillerNeg.patern[21] = "1111 11111111111111      111111111    111111111111111111111";
        spaceFillerNeg.patern[22] = " 11111111111111111111        1        11111111111111111111 ";
        spaceFillerNeg.patern[23] = "1111111111111111111111   111   111   1111111111111111111111";
        spaceFillerNeg.patern[24] = " 111111111111111111111     1   1     111111111111111111111 ";
        spaceFillerNeg.patern[25] = "11111111111111111111111               111111111111111111111";
        spaceFillerNeg.patern[26] = " 1111111111111111111111   111 111     11111111111111111111 ";
        spaceFillerNeg.patern[27] = "1111111111111111111111    111 111    1111111111111111111111";
        spaceFillerNeg.patern[28] = " 111111111111111111111   1 11 11 1   111111111111111111111 ";
        spaceFillerNeg.patern[29] = "11111111111111111111111  111   111  11111111111111111111111";
        spaceFillerNeg.patern[30] = " 1111111111111111111111   1     1   1111111111111111111111 ";
        spaceFillerNeg.patern[31] = "111111111111111111111111             1111111111111111111111";
        spaceFillerNeg.patern[32] = " 11111111111111111111111     11      111111111111111111111 ";
        spaceFillerNeg.patern[33] = "1111111111111111111111111  111111  111111111111111111111111";
        spaceFillerNeg.patern[34] = " 111111111111111111111111111111111111111111111111111111111 ";
        spaceFillerNeg.patern[35] = " 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 ";

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

        uShape = new Patern(3, 3, 7, 49, 30, 22, 24);
        uShape.patern[0] = "1 1";
        uShape.patern[1] = "1 1";
        uShape.patern[2] = "111";

        uShapeNeg = new Patern(9, 9, 60, 49, 30, 19, 21);
        uShapeNeg.patern[0] = " 11  11  ";
        uShapeNeg.patern[1] = "         ";
        uShapeNeg.patern[2] = "1       1";
        uShapeNeg.patern[3] = "1  1 1  1";
        uShapeNeg.patern[4] = "   1 1   ";
        uShapeNeg.patern[5] = "   111   ";
        uShapeNeg.patern[6] = "1       1";
        uShapeNeg.patern[7] = "1       1";
        uShapeNeg.patern[8] = "   11    ";

        square = new Patern(2, 2, 4, 3, 3, 0, 0);
        square.patern[0] = "11";
        square.patern[1] = "11";

        rPantomino = new Patern(3, 3, 5);
        rPantomino.patern[0] = " 11";
        rPantomino.patern[1] = "11 ";
        rPantomino.patern[2] = " 1 ";

        blinker = new Patern(1, 3, 3);
        blinker.patern[0] = "111";

        fiveCells = new Patern(1, 5, 5);
        fiveCells.patern[0] = "     ";
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
                    foodMatrix[row, col] = 2;
                }
            }
        }
    }

    public static void PrintMatrix(byte[,] matrix)
    {
        int totalCellsCount = 0;
        StringBuilder sb = new StringBuilder();
        for (int row = 1; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 1; col < matrix.GetLength(0) - 1; col++)
            {
                switch (matrix[row, col])
                {
                    case 1:
                        sb.Append("o");
                        totalCellsCount++;
                        break;
                    case 0:
                        if (foodMatrix[row, col] == 0)
                        {
                            sb.Append(' ');
                        }
                        else
                        {
                            sb.Append('F');
                        }
                        break;
                }
            }
            sb.AppendLine();
        }
        if (totalCellsCount != vSafe)
        {
            if (totalCellsCount > vSafe)
            {
                int count = totalCellsCount - vSafe;
                int index = sb.Length - 3;
                while (count > 0)
                {
                    if (sb[index] == 'o')
                    {
                        sb[index] = ' ';
                        count--;
                    }
                    index--;
                }
            }
            else
            {
                int count = vSafe - totalCellsCount;
                int index = sb.Length - 3;
                while (count > 0)
                {
                    if (sb[index] != 'o')
                    {
                        sb[index] = 'o';
                        count--;
                    }
                    index--;
                }
            }
        }
        Console.Write(sb);
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
        int totalCellsCount = 0;
        StringBuilder sb = new StringBuilder();
        for (int row = 1; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 1; col < matrix.GetLength(0) - 1; col++)
            {
                switch (matrix[row, col])
                {
                    case 1:
                        sb.Append("+");
                        totalCellsCount++;
                        break;
                    case 0:
                        if (foodMatrix[row, col] == 0)
                        {
                            sb.Append('0');
                        }
                        else
                        {
                            sb.Append('F');
                        }
                        break;
                }
            }
            sb.AppendLine();
        }
        if (totalCellsCount != vSafe)
        {
            if (totalCellsCount > vSafe)
            {
                int count = totalCellsCount - vSafe;
                int index = sb.Length - 3;
                while (count > 0)
                {
                    if (sb[index] == 'o')
                    {
                        sb[index] = ' ';
                        count--;
                    }
                    index--;
                }
            }
            else
            {
                int count = vSafe - totalCellsCount;
                int index = sb.Length - 3;
                while (count > 0)
                {
                    if (sb[index] != 'o')
                    {
                        sb[index] = 'o';
                        count--;
                    }
                    index--;
                }
            }
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

    public static int CalcFoodQuantity(int upperRow, int upperCol, int lowerRow, int lowerCol)
    {
        lowerRow++;
        lowerCol++;
        int result = integralMatrix[lowerRow, lowerCol] - integralMatrix[lowerRow, upperCol] - integralMatrix[upperRow, lowerCol] + integralMatrix[upperRow, upperCol];
        return result;
    }

    static int ApplyPatern(Patern patern, int startRow, int startCol, byte[,] destinationMatrix)
    {
        int usedCellsCount = 0;
        int initialRowOffset = startRow + patern.rowOffset + 1;
        int initialColOffset = startCol + patern.colOffset + 1;
        for (int row = 0; row < patern.height; row++)
        {
            for (int col = 0; col < patern.patern[row].Length; col++)
            {
                if (patern.patern[row][col] == '1')
                {
                    if (destinationMatrix[initialRowOffset + row, initialColOffset + col] == 0 || destinationMatrix[initialRowOffset + row, initialColOffset + col] == 2)
                    {
                        destinationMatrix[initialRowOffset + row, initialColOffset + col] = 1;
                        usedCellsCount++;
                    }
                }
                else
                {
                    if (destinationMatrix[initialRowOffset + row, initialColOffset + col] == 1)
                    {
                        destinationMatrix[initialRowOffset + row, initialColOffset + col] = 0;
                        usedCellsCount--;
                    }
                }
            }
        }
        return usedCellsCount;
    }

    static void Main()
    {
        string input = Console.ReadLine();
        t = int.Parse(input);
        input = Console.ReadLine();
        v = int.Parse(input);
        vSafe = v;
        input = Console.ReadLine();
        n = int.Parse(input);
        Console.SetBufferSize(250, 250);
        gameMatrix = new byte[n + 2, n + 2];
        foodMatrix = new byte[n + 2, n + 2];
        integralMatrix = new int[n + 2, n + 2];
        InitPaterns();
        ReadGameMatrix();
        CreateIntegralMatrix();
        if (n < 100 && v > n * 4 - 4 && v < n * n / 2)
        {
            //put available cells along the shores
            SpiralFill filler = new SpiralFill(v, gameMatrix);
            filler.Go();
        }
        else if (t > n + 50 && v > n * n * 0.12 && v < n * n * 0.42)
        {
            //apply squares
            ApplySquares();
        }
        else if (v < 5)
        {
            //apply singel blinker in the middle of the field
            //TODO List<PotentialPatern> p = new List<PotentialPatern>();
            int row = n / 2;
            int col = n / 2;
            v -= ApplyPatern(blinker, row, col, gameMatrix);
            if (v == 1)
            {
                gameMatrix[n, n] = 1;
            }
        }
        else if (v < 7)
        {
            //apply single rPantomino in the middle of the field
            int row = n / 2;
            int col = n / 2;
            v -= ApplyPatern(rPantomino, row, col, gameMatrix);
            if (v == 1)
            {
                gameMatrix[n, n] = 1;
            }
        }
        else if (v < 200)
        {
            //apply multiple uShapes, using list<potentialPatern>
            ApplyUShapes();
        }
        else if (v < n * n - 3500)
        {
            if (t < n / 2)
            {
                //apply many SpaceFillers
                SpaceFillerS();
            }
            else
            {
                //apply central SpaceFiller and multiple uShapes or uShapesNeg
                ApplySpaceFillerAndUShapes();
            }
        }
        else if (v < n * n - spaceFillerNeg.cellsNeeded)
        {
            //apply central SpaceFillerNeg and multiple uShapesNeg
            TooManyCells();
        }
        else if (v < n * n - uShapeNeg.cellsNeeded)
        {
            //apply multiple uShapeNeg
            ApplyUShapeNeg();
        }
        else
        {
            //apply fiveCells patern in every corner and a randomly place remaining free cells
            Last50FreeSpaces();
        }

        //PrintMatrix(gameMatrix);
        PrintFinalMatrix(gameMatrix);
    }
  
    private static void Last50FreeSpaces()
    {
        //apply fiveCells patern in every corner and a randomly place remaining free cells
        RemainingCells filler = new RemainingCells(gameMatrix, 5);
        filler.Go(n * n);
        v -= n * n;
        v -= ApplyPatern(fiveCells, 0, 0, gameMatrix);
        if (v <= -fiveCells.cellsNeeded)
        {
            v -= ApplyPatern(fiveCells, n - 1, 0, gameMatrix);
        }
        if (v <= -fiveCells.cellsNeeded)
        {
            v -= ApplyPatern(fiveCells, 0, n - 5, gameMatrix);
        }
        if (v <= -fiveCells.cellsNeeded)
        {
            v -= ApplyPatern(fiveCells, n - 1, n - 5, gameMatrix);
        }
        int row = n / 2;
        int col = n / 2;
        while (v < 0)
        {
            gameMatrix[row++, col++] = 0;
            v++;
        }
    }
  
    private static void ApplyUShapes()
    {
        //apply multiple uShapes, using list<potentialPatern>
        List<PotentialPatern> p = new List<PotentialPatern>();

        for (int row = 1; row < n - uShape.maxHeight; row = row + uShape.maxHeight)
        {
            for (int col = 1; col < n - uShape.maxWidth; col = col + uShape.maxWidth)
            {
                p.Add(new PotentialPatern(uShape, row, col, row + uShape.maxHeight, col + uShape.maxWidth));
            }
        }
        p.Sort();
        int i = 0;
        while (v >= uShape.cellsNeeded && i < p.Count)
        {
            v -= ApplyPatern(p[i].patern, p[i].upperRow, p[i].upperCol, gameMatrix);
            i++;
        }
        int r = n - v / n;
        int c = 1;
        while (v > 0)
        {
            gameMatrix[r, c++] = 1;
            if (c > n)
            {
                c = 1;
                r++;
            }
            v--;
        }
    }

    private static void ApplySquares()
    {
        int row = 0;
        int col = 0;
        while (v > 4 * (n / 3))
        {
            for (int i = 0; i < n / 3; i++)
            {
                v -= ApplyPatern(square, row, col + i * 3, gameMatrix);
            }
            row += 3;
        }
        row++;
        col = 0;
        while (v > 3)
        {
            v -= ApplyPatern(square, row, col, gameMatrix);
            col += 3;
        }
        row = n;
        col = n - 4;
        while (v > 0)
        {
            gameMatrix[row, col++] = 1;
            v--;
        }
    }
  
    private static void SpaceFillerAndGliderS()
    {
        {
            int col1 = (gameMatrix.GetLength(0) - spaceFiller.width) / 2;
            int row = (gameMatrix.GetLength(1) - spaceFiller.height) / 2;
            ApplyPatern(spaceFiller, row, col1, gameMatrix);
            v -= spaceFiller.cellsNeeded;
        }
        int col = n / 2 - gliderToWest.height - gliderToWest.width;
        for (int row = 1; row < n / 2 - gliderToWest.height; row = row + gliderToWest.height * 2)
        {
            if (v > uShape.cellsNeeded * 2 && (row < n / 2 && col > 8))
            {
                ApplyPatern(gliderToWest, row, col, gameMatrix);
                ApplyPatern(gliderToWest, row + gliderToWest.height, col - 7, gameMatrix);
                v -= uShape.cellsNeeded * 2;
            }
            else
            {
                break;
            }
            col -= 14;
        }
    }
  
    private static void ApplySpaceFillerAndUShapes()
    {
        {
            int col = (gameMatrix.GetLength(0) - spaceFiller.width) / 2;
            int row = (gameMatrix.GetLength(1) - spaceFiller.height) / 2;
            v -= ApplyPatern(spaceFiller, row, col, gameMatrix);
        }
        List<PotentialPatern> p = new List<PotentialPatern>();

        //corner 1
        int maxRow = n / 2 - uShape.maxHeight;
        for (int row = 1; row < maxRow; row = row + uShape.maxHeight)
        {
            int maxCol = n / 2 - (row + uShape.maxWidth) + (n / 2 - (spaceFiller.height / 2 + t / 2));
            if (maxCol > n / 2)
            {
                maxCol = n / 2;
            }
            for (int col = 1; col < maxCol; col = col + uShape.maxWidth)
            {
                p.Add(new PotentialPatern(uShape, row, col, row + uShape.maxHeight, col + uShape.maxWidth));
            }
        }
        //corner 2
        maxRow = n / 2;
        for (int row = 1; row < maxRow; row = row + uShape.maxHeight)
        {
            int minCol = n / 2 + (row + uShape.maxWidth) - (n / 2 - (spaceFiller.height / 2 + t / 2));
            if (minCol < n / 2)
            {
                minCol = n / 2;
            }
            for (int col = n - uShape.maxWidth; col > minCol; col = col - uShape.maxWidth)
            {
                p.Add(new PotentialPatern(uShape, row, col, row + uShape.maxHeight, col + uShape.maxWidth));
            }
        }
        
        //corner 3
        //corner 4
        //another time ;)
        p.Sort();
        int i = 0;
        if (v < n * n * 0.1)
        {
            while (v >= uShape.cellsNeeded && i < p.Count)
            {
                v -= ApplyPatern(p[i].patern, p[i].upperRow-3, p[i].upperCol-3, gameMatrix);
                i++;
            }
            FourDiagonalFill(v);
        }
        else
        {
            while (v >= uShapeNeg.cellsNeeded && i < p.Count)
            {
                v -= ApplyPatern(uShapeNeg, p[i].upperRow, p[i].upperCol, gameMatrix);
                i++;
            }
            FourDiagonalFill(v);
        }
    }
  
    private static void ApplyUShapeNeg()
    {
        RemainingCells filler = new RemainingCells(gameMatrix, 5);
        filler.Go(n * n);
        v -= n * n;
        int col = (gameMatrix.GetLength(0) - uShape.width) / 2;
        int row = (gameMatrix.GetLength(1) - uShape.height) / 2;
        v -= ApplyPatern(uShapeNeg, row, col, gameMatrix);
        FourDiagonalFill(v);
    }
  
    private static void FourDiagonalFill(int v)
    {
        RemainingCells filler1 = new RemainingCells(gameMatrix, 1);
        RemainingCells filler2 = new RemainingCells(gameMatrix, 2);
        RemainingCells filler3 = new RemainingCells(gameMatrix, 3);
        RemainingCells filler4 = new RemainingCells(gameMatrix, 4);
        if (v > 0)
        {
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
            for (int i = 0; i > v / 4; i--)
            {
                filler1.Go(-1);
                filler2.Go(-1);
                filler3.Go(-1);
                filler4.Go(-1);
            }
            filler1.Go(-(v % 4));
        }
    }

    private static void SpaceFillerS()
    {
        int hStep = spaceFiller.width + t;
        int vStep = spaceFiller.height + t;
        List<PotentialPatern> possiblePaterns = new List<PotentialPatern>();

        for (int row = 1; row < n - vStep; row = row + vStep)
        {
            for (int col = 1; col < n - hStep; col = col + hStep)
            {
                possiblePaterns.Add(new PotentialPatern(spaceFiller, row, col, row + vStep, col + hStep));
            }
        }

        for (int row = vStep / 2; row < n - vStep; row = row + vStep)
        {
            for (int col = hStep / 2; col < n - hStep; col = col + hStep)
            {
                possiblePaterns.Add(new PotentialPatern(spaceFiller, row, col, row + vStep, col + hStep));
            }
        }
        
        possiblePaterns.Sort();

        if (v < n * n / 2)
        {
            for (int i = 0; i < possiblePaterns.Count; i++)
            {
                if (v < 200)
                {
                    break;
                }
                PotentialPatern p = possiblePaterns[i];
                v -= ApplyPatern(p.patern, p.upperRow + t / 2, p.upperCol + t / 2, gameMatrix);
            }

            FourDiagonalFill(v);
        }
        else
        {
            RemainingCells filler = new RemainingCells(gameMatrix, 5);
            filler.Go(n * n);
            v -= n * n;
            for (int i = 0; i < possiblePaterns.Count; i++)
            {
                PotentialPatern p = possiblePaterns[i];
                v -= ApplyPatern(spaceFillerNeg, p.upperRow + t / 2 - 5, p.upperCol + t / 2 - 5, gameMatrix);
            }
            FourDiagonalFill(v);
        }
    }

    private static void TooManyCells()
    {
        RemainingCells filler = new RemainingCells(gameMatrix, 5);
        filler.Go(n * n);
        v -= n * n;
        int col = (gameMatrix.GetLength(0) - spaceFiller.width) / 2;
        int row = (gameMatrix.GetLength(1) - spaceFiller.height) / 2;
        v -= ApplyPatern(spaceFillerNeg, row - 5, col - 5, gameMatrix);
        FourDiagonalFill(v);
    }
}