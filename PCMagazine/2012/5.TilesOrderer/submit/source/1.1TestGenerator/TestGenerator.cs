using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TestGenerator
{
    static void Main()
    {
        string[] tiles = { "ninetile", "plus", "hline", "vline", "angle-ur", "angle-dr", "angle-dl", "angle-ul"};

        int tilesNumber = 1000;

        Console.WriteLine(tilesNumber);
        for (int i = 0; i < tilesNumber; i++)
        {
            Console.WriteLine("{0} {1} {2}", tiles[0], 250, 250);
        }
        Console.WriteLine();
    }
}