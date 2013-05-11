using System;

class PrintSpiralMatrix
{
    static int n;
    static int current = 1;
    static int layerNumber = 0;
    static int[,] matrix;
    static byte row = 0;
    static sbyte col = -1;

    static void FillOneLine(byte direction, byte lenght)
    {
        for (int i = 0; i < lenght; i++)
        {
            switch (direction)
            {
                case 1:
                    col++;
                    break;
                case 2:
                    row++;
                    break;
                case 3:
                    col--;
                    break;
                case 4:
                    row--;
                    break;
            }
            matrix[row, col] = current++;
        }
    }

    static void FillOneLayer()
    {
        FillOneLine(1, (byte)(n - layerNumber * 2));
        FillOneLine(2, (byte)(n - layerNumber * 2-1));
        FillOneLine(3, (byte)(n - layerNumber * 2-1));
        FillOneLine(4, (byte)(n - layerNumber * 2-2));
    }

    static void PrintMatrix()
    {
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0} ", matrix[row,col].ToString().PadLeft(3,' '));
            }
            Console.WriteLine();
        }
    }
    static void Main()
    {
        string input = Console.ReadLine();
        n = int.Parse(input);
        matrix = new int[n, n];
        while (current < n*n)
        {
            FillOneLayer();
            layerNumber++;
        }
        if (n % 2 != 0)
        {
            matrix[row, col + 1] = current;
        }
        PrintMatrix();
    }
}