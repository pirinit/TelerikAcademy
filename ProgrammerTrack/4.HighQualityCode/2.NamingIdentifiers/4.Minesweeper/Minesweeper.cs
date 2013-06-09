using System;
using System.Collections.Generic;
using System.Linq;

public class Minesweeper
{
    private const int BoardWidth = 10;
    private const int BoardHeight = 5;
    private const int TotalMinesCount = 15;
    private const int HighScoresMaxCount = 6;
    private const char MineCellSymbol = '*';
    private const char EmptyCellSymbol = '-';
    private const char UnknownCellSymbol = '?';

    public static void Main()
    {
        string command = string.Empty;
        char[,] gameBoard = CreateGameBoard();
        char[,] minesBoard = CreateMinesBoard();
        List<ScoreEntry> highScores = new List<ScoreEntry>(HighScoresMaxCount);
        int row = 0;
        int col = 0;
        int currentPoints = 0;
        int emptyCells = (BoardHeight * BoardWidth) - TotalMinesCount;
        bool isNewGame = true;
        bool isGameWon = false;
        bool isMineOpened = false;

        do
        {
            if (isNewGame)
            {
                Console.WriteLine("Let's play Minesweeper! Try to find all cells without mines.");
                Console.WriteLine("Enter \"help\" for list of commands.");
                PrintBoard(gameBoard);
                isNewGame = false;
            }

            Console.Write("Enter cell (row and col) : ");
            command = Console.ReadLine().Trim();
            if (command.Length >= 3)
            {
                if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                    row <= gameBoard.GetLength(0) && col <= gameBoard.GetLength(1))
                {
                    command = "turn";
                }
            }

            switch (command)
            {
                case "help":
                    ProcessHelpCommand();
                    break;
                case "top":
                    PrintHighScores(highScores);
                    break;
                case "restart":
                    gameBoard = CreateGameBoard();
                    minesBoard = CreateMinesBoard();
                    isMineOpened = false;
                    isNewGame = true;
                    break;
                case "exit":
                    ProcessExitCommand();
                    break;
                case "turn":
                    if (minesBoard[row, col] != '*')
                    {
                        RevealCell(gameBoard, minesBoard, row, col);
                        currentPoints++;

                        if (currentPoints == emptyCells)
                        {
                            isGameWon = true;
                        }
                        else
                        {
                            PrintBoard(gameBoard);
                        }
                    }
                    else
                    {
                        isMineOpened = true;
                    }

                    break;
                default:
                    Console.WriteLine("Wrong command!\nEnter \"help\" for list of commands.");
                    break;
            }

            if (isMineOpened)
            {
                PrintBoard(minesBoard);
                Console.Write("Mine detonated! You are dead!\n You have {0} points\nPlease, enter your name: ", currentPoints);
                string playerName = Console.ReadLine();
                ScoreEntry scoreEntry = new ScoreEntry(playerName, currentPoints);

                if (highScores.Count < HighScoresMaxCount)
                {
                    highScores.Add(scoreEntry);
                }
                else
                {
                    for (int i = 0; i < highScores.Count; i++)
                    {
                        if (highScores[i].Points < scoreEntry.Points)
                        {
                            highScores.Insert(i, scoreEntry);
                            highScores.RemoveAt(highScores.Count - 1);
                            break;
                        }
                    }
                }

                highScores.Sort((ScoreEntry r1, ScoreEntry r2) => r2.Name.CompareTo(r1.Name));
                highScores.Sort((ScoreEntry r1, ScoreEntry r2) => r2.Points.CompareTo(r1.Points));

                PrintHighScores(highScores);

                gameBoard = CreateGameBoard();
                minesBoard = CreateMinesBoard();
                currentPoints = 0;
                isMineOpened = false;
                isNewGame = true;
            }

            if (isGameWon)
            {
                Console.WriteLine("Congratulations! You have won the game!\n");
                PrintBoard(minesBoard);
                Console.WriteLine("Daj si imeto, batka: ");
                string playerName = Console.ReadLine();
                ScoreEntry scoreEntry = new ScoreEntry(playerName, currentPoints);
                highScores.Add(scoreEntry);
                PrintHighScores(highScores);
                gameBoard = CreateGameBoard();
                minesBoard = CreateMinesBoard();
                currentPoints = 0;
                isGameWon = false;
                isNewGame = true;
            }
        }
        while (command != "exit");
    }
  
    private static void ProcessHelpCommand()
    {
        Console.WriteLine("Valid commands:");
        Console.WriteLine("---------------------------------------------------------------");
        Console.WriteLine("\"top\"               - prints high scores.");
        Console.WriteLine("\"restart\"           - starts new game.");
        Console.WriteLine("\"exit\"              - exits the game.");
        Console.WriteLine("\"help\"              - prints this in-game help.");
        Console.WriteLine("\"row[space]col\"     - will open the col-th cell on row-th row");
        Console.WriteLine("---------------------------------------------------------------");
    }
  
    private static void ProcessExitCommand()
    {
        Console.WriteLine("Good bye!");
        Console.WriteLine("Minesweepers - made in Bulgaria!");
        Console.Read();
    }

    private static void PrintHighScores(List<ScoreEntry> highScores)
    {
        if (highScores.Count > 0)
        {
            Console.WriteLine("High Scores:");
            for (int i = 0; i < highScores.Count; i++)
            {
                Console.WriteLine("{0}. {1:20} --> {2}", i + 1, highScores[i].Name, highScores[i].Points);
            }

            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Empty Score Board!");
        }
    }

    private static void PrintBoard(char[,] board)
    {
        int rows = board.GetLength(0);
        int cols = board.GetLength(1);

        string separator = new string('-', (cols * 2) + 3);
        separator = "  " + separator;
        Console.Write("\n   ");
        for (int i = 0; i < cols; i++)
        {
            Console.Write(" {0}", i);
        }

        Console.WriteLine("{0}{1}", System.Environment.NewLine, separator);

        for (int row = 0; row < rows; row++)
        {
            Console.Write("{0} | ", row);
            for (int col = 0; col < cols; col++)
            {
                Console.Write("{0} ", board[row, col]);
            }

            Console.Write("|");
            Console.WriteLine();
        }

        Console.WriteLine(separator);
    }

    private static char[,] CreateGameBoard()
    {
        int rows = BoardHeight;
        int cols = BoardWidth;
        char[,] board = new char[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                board[row, col] = UnknownCellSymbol;
            }
        }

        return board;
    }

    private static char[,] CreateMinesBoard()
    {
        int rows = BoardHeight;
        int cols = BoardWidth;
        char[,] gameField = new char[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                gameField[row, col] = EmptyCellSymbol;
            }
        }

        List<int> minesToPlace = new List<int>(TotalMinesCount);
        Random random = new Random();
        int lastMineIndex = BoardHeight * BoardWidth;

        while (minesToPlace.Count < TotalMinesCount)
        {
            int currentMineIndex = random.Next(lastMineIndex);
            if (!minesToPlace.Contains(currentMineIndex))
            {
                minesToPlace.Add(currentMineIndex);
            }
        }

        foreach (int mine in minesToPlace)
        {
            int col = mine % cols;
            int row = mine / cols;
            gameField[row, col] = MineCellSymbol;
        }

        return gameField;
    }

    private static void RevealCell(char[,] gameBoard, char[,] minesBoard, int row, int col)
    {
        char surroundingMinesCount = CalculateSurroundingMinesCount(minesBoard, row, col);
        minesBoard[row, col] = surroundingMinesCount;
        gameBoard[row, col] = surroundingMinesCount;
    }

    private static char CalculateSurroundingMinesCount(char[,] minesBoard, int row, int col)
    {
        int minesCount = 0;
        int maxRow = minesBoard.GetLength(0);
        int maxCol = minesBoard.GetLength(1);

        for (int rowOffset = -1; rowOffset <= 1; rowOffset++)
        {
            for (int colOffset = -1; colOffset <= 1; colOffset++)
            {
                int currentRow = row + rowOffset;
                int currentCol = col + colOffset;
                if (AreCoordinatesValid(currentRow, currentCol, maxRow, maxCol))
                {
                    if (minesBoard[currentRow, currentCol] == MineCellSymbol)
                    {
                        minesCount++;
                    }
                }
            }
        }

        return char.Parse(minesCount.ToString());
    }

    private static bool AreCoordinatesValid(int row, int col, int maxRow, int maxCol)
    {
        bool areValid = (0 <= row && row < maxRow) && (0 <= col && col < maxCol);
        return areValid;
    }
}