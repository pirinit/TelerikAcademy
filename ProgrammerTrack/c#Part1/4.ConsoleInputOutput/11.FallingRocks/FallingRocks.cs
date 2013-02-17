using System;
using System.Text;
using System.Threading;
using System.Media;
using System.Collections.Generic;

class FallingRocks
{
    public class Rock
    {
        public int col;
        public int row;
        public string type;
        public int size;
        public ConsoleColor color;

        public void MoveDown()
        {
            this.row++;
        }
    }
    static int consoleWidth = 46;
    static int consoleHeight = 25;
    static string rockType = "^@*&+%$#!.;";
    static byte dificultyLevel = 3;
    static Random generator = new Random();
    static List<Rock> rocks = new List<Rock>();
    static int firstRockIndex = 0;
    static int speed = 200;
    static int dwarfPos = consoleWidth / 2;
    static int money = 100;
    static int lineScore = 5;
    static int score = 0;
    

    static void PrintGameScreen()
    {
        for (int i = firstRockIndex; i < rocks.Count; i++)
		{
            Console.SetCursorPosition(rocks[i].col, rocks[i].row);
            Console.ForegroundColor = rocks[i].color;
            Console.Write(rocks[i].type);
        }
    }

    static void PrintFirstLine()
    {
        Console.SetCursorPosition(0, 0);
        Console.Write("Score: {0}", score);        
    }
    static void PrintDwarf()
    {
        Console.SetCursorPosition(dwarfPos-1, consoleHeight);
        Console.Write("(0)");
    }
    static Rock AddRock()
    {
        Rock nextRock = new Rock();
        int rockSize = generator.Next(1, 4);
        nextRock.row = 1;
        nextRock.col = generator.Next(consoleWidth - rockSize + 1);
        nextRock.type = new string(rockType[generator.Next(rockType.Length)], rockSize);
        nextRock.size = rockSize;
        nextRock.color = (ConsoleColor) generator.Next(16);
        if (nextRock.color == ConsoleColor.Black)
        {
            nextRock.color = ConsoleColor.White;
        }
        return nextRock;
    }
    static void ClearKeyboardBuffer()
    {
        while (Console.KeyAvailable)
        {
            Console.ReadKey();
        }
    }

    static void EndGame()
    {
        Console.Clear();
        PrintFirstLine();
        Console.SetCursorPosition(consoleWidth / 2 - 6, consoleHeight / 2);
        Console.WriteLine("Game Over...");
        Console.SetCursorPosition(consoleWidth / 2 - 6, consoleHeight / 2+1);
        Console.WriteLine("Score: {0}", score);
    }
    static void PrintStartScreen()
    {
        Console.WriteLine(@"Welcome to the FallingRocks game.

Your goal is to avoid the falling rocks using the arrow key on the keyboard.

Collecting $ will give you extra points.

Have fun!

Press enter to start the game...");
    }
    static void Main()
    {
        Console.Title = "..|| FallingRocks ||..";
        Console.SetWindowSize(consoleWidth, consoleHeight+2);
        Console.BufferHeight = consoleHeight + 2;
        Console.BufferWidth = consoleWidth;
        bool gameRun = true;
        Console.ForegroundColor = (ConsoleColor)10;
        PrintStartScreen();
        Console.Read();
        while (gameRun)
        {
            //print game screen
            Console.Clear();
            PrintGameScreen();
            Console.ForegroundColor = (ConsoleColor)10;
            PrintFirstLine();
            PrintDwarf();
            Thread.Sleep(speed);
            //move all rocks one row down
            for (int i = firstRockIndex; i < rocks.Count; i++)
            {
                if (rocks[i].row + 1 <= consoleHeight)
                {
                    rocks[i].MoveDown(); ;
                }
                else
                {
                    firstRockIndex = i;
                }
            }

            //add next group of rocks
            for (int i = 0; i <= generator.Next(dificultyLevel); i++)
            {
                rocks.Add(AddRock());
            }
            
            //collison detection
            for (int i = firstRockIndex; i < rocks.Count; i++)
            {
                if (rocks[i].row < consoleHeight)
                {
                    break;
                }
                if ((rocks[i].col <= dwarfPos + 1) && (dwarfPos - 1 <= rocks[i].col + rocks[i].size - 1))
                {
                    if (rocks[i].type[0] == '$')
                    {
                        score += money;
                        Console.Beep();
                    }
                    else
                    {
                        EndGame();
                        gameRun = false;
                    }
                }
            }
            score += lineScore;
            //move dwarf
            ConsoleKey key;
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey().Key;
                ClearKeyboardBuffer();
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        if (dwarfPos == 1)
                        {
                            break;
                        };
                        dwarfPos--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (dwarfPos == consoleWidth - 2)
                        {
                            break;
                        };
                        dwarfPos++;
                        break;
                    case ConsoleKey.P:
                        Console.ReadKey();
                        break;
                };
            }
        }
    }
}