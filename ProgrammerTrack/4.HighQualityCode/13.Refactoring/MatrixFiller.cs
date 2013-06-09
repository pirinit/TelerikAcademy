using System;
using System.Text;

public class MatrixFiller
{
    static bool IsCellPossible(int row, int col, int[,] matrix)
    {
        bool isRowInMatrix = 0 <= row && row < matrix.GetLength(0);
        bool isColInMatrix = 0 <= col && col < matrix.GetLength(1);

        return isRowInMatrix && isColInMatrix && matrix[row, col] == 0;
    }

    static void Main(string[] args)
    {
        int n = ReadInput();
        int[,] matrix = new int[n, n];
        DirectionHolder direction = new DirectionHolder();

        FillMatrixElements(matrix, direction);
        Console.WriteLine(PrintMatrix(matrix, n * n));
    }
  
    public static void FillMatrixElements(int[,] matrix, DirectionHolder direction)
    {
        Point pos = new Point(0, 0);
        int currentNumber = 1;

        while (true)
        {
            matrix[pos.Row, pos.Col] = currentNumber++;
            // try to find empty neighbor
            bool newDirectionFound = false;
            for (int i = 0; i < 8; i++)
            {
                if (IsCellPossible(pos.Row + direction.DeltaRow, pos.Col + direction.DeltaCol, matrix))
                {
                    pos.Row += direction.DeltaRow;
                    pos.Col += direction.DeltaCol;
                    newDirectionFound = true;
                    break;
                }
                direction.Next();
            }

            // try to find empty cell in matrix
            if (!newDirectionFound)
            {
                for (int newRow = 0; newRow < matrix.GetLength(0); newRow++)
                {
                    for (int newCol = 0; newCol < matrix.GetLength(1); newCol++)
                    {
                        if (matrix[newRow, newCol] == 0)
                        {
                            pos.Row = newRow;
                            pos.Col = newCol;
                            newDirectionFound = true;
                            break;
                        }
                    }

                    if (newDirectionFound)
                    {
                        break;
                    }
                }
            }

            // matrix is filled
            if (!newDirectionFound)
            {
                break;
            }
        }
    }
  
    public static string PrintMatrix(int[,] matrix, int maxNumber)
    {
        StringBuilder sb = new StringBuilder();
        int maxNumberWidth = maxNumber.ToString().Length;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
                sb.AppendFormat(" {0}", matrix[row, col].ToString().PadLeft(maxNumberWidth));

            sb.AppendLine();
        }

        return sb.ToString();
    }
  
    public static int ReadInput()
    {
        Console.WriteLine("Enter a positive number");
        string input = Console.ReadLine();
        int n;
        while (true)
        {
            if (!int.TryParse(input, out n))
            {
                Console.WriteLine("You haven't entered a correct number.\nPlease enter number between 0 and 100.");
                input = Console.ReadLine();
                continue;
            }
            else if (n < 0 || n > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number.\nPlease enter number between 0 and 100.");
                input = Console.ReadLine();
                continue;
            }
            else
            {
                return n;
            }
        }
    }
}