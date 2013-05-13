using System;
using System.Text;

class Program
{
    static void PrintToFile(string location)
    {

        WriteLine("Printing to file...", 4, 14, ConsoleColor.Yellow);

        System.IO.StreamWriter file = new System.IO.StreamWriter(location);
        file.Write(sb.ToString());
        file.Close();
    }


    static void WriteLine(string msg, byte x, byte y, ConsoleColor color)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(msg);
    }


    static StringBuilder sb = new StringBuilder();

    static void Main()
    {
        Console.BufferWidth = Console.WindowWidth = 70;
        Console.BufferHeight = Console.WindowHeight = 23;

        Console.Title = "Valid input generator || Game of Trolls";
        WriteLine("Game Of Trolls - valid input generator v.1.0", 2, 1, ConsoleColor.Green);
        WriteLine("Antony Jekov", 2, 2, ConsoleColor.Green);

        ushort c;
        ushort n;
        ushort v;
        uint num = 0;
        uint towersMax;

        Random randomGenerator = new Random();


        while (true)
        {
            WriteLine("Enter number of turns (1 <= C <= 1000): ", 4, 4, ConsoleColor.White);
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (ushort.TryParse(Console.ReadLine(), out c) && c > 0 && c < 1001)
            {
                //generatedInput += (c + "\r\n");
                sb.AppendFormat("{0} \r\n", c);
                break;
            }
            else
            {
                WriteLine("".PadLeft(Console.WindowWidth - 2, ' '), 4, 4, ConsoleColor.White);
            }
        }

        while (true)
        {
            WriteLine("Enter number of planes (1 <= N <= 1000): ", 4, 6, ConsoleColor.White);
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (ushort.TryParse(Console.ReadLine(), out n) && n < 1001 && n > 0)
            {
                //generatedInput += (n + "\r\n");
                sb.AppendFormat("{0} \r\n", n);
                towersMax = (uint)(n * n);
                break;
            }
            else
            {
                WriteLine("".PadLeft(Console.WindowWidth - 2, ' '), 4, 6, ConsoleColor.White);
            }
        }

        while (true)
        {
            WriteLine("Enter max height for towers (2 <= H <= 1000): ", 4, 8, ConsoleColor.White);
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (ushort.TryParse(Console.ReadLine(), out v) && v > 1 && v <= 1000)
            {
                v += 1;
                break;
            }
            else
            {
                WriteLine("".PadLeft(Console.WindowWidth - 2, ' '), 4, 6, ConsoleColor.White);
            }
        }
        int[] legacy = new int[n];
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                while (true)
                {
                    byte write = 0;
                    int newNum = randomGenerator.Next(1, v);
                    if (newNum != legacy[col])
                    {
                        write++;
                    }

                    if (col > 0)
                    {
                        if (newNum != legacy[col - 1])
                        {
                            write++;

                        }
                    }

                    if (col == 0 && newNum != legacy[col])
                    {
                        write++;
                    }

                    if (write == 2)
                    {
                        legacy[col] = newNum;
                        num += 1;
                        //WriteLine((num + " / " + towersMax), 4, 10, ConsoleColor.Cyan);
                        break;
                    }
                }
            }

            for (int i = 0; i < legacy.Length; i++)
            {
                //generatedInput += legacy[i];
                sb.Append(legacy[i]);
                if (i < legacy.Length - 1)
                {
                    //generatedInput += ' ';
                    sb.Append(" ");
                }
            }

            if (row != n - 1)
            {
                //generatedInput += "\r\n";
                sb.AppendLine();
            }

        }

        WriteLine("Output file location:  c:\\TrollsInput.txt", 4, 12, ConsoleColor.Yellow);

        PrintToFile("c:\\TrollsInput.txt");

        WriteLine("Don't forget to set your Console.BufferW/H to", 4, 14, ConsoleColor.Cyan);
        WriteLine("N * 2 + num of digits for H, when you enter this", 4, 15, ConsoleColor.Cyan);
        WriteLine("input at the actual 'Game of Trolls'", 4, 16, ConsoleColor.Cyan);
        WriteLine("Done! Press <ENTER> to exit.", 4, 19, ConsoleColor.Green);
        Console.ReadLine();
    }
}