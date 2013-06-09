using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class IfStatement
{
    public const int MinX = -60;
    public const int MaxX = 160;
    public const int MinY = -60;
    public const int MaxY = 160;

    public static void Main()
    {
        Potato potato = new Potato();

        if (potato != null && potato.IsPeeled && potato.IsFresh)
        {
            Cook(potato);
        }

        int x = 50;
        int y = 300;
        bool inRangeX = MinX <= x && x <= MaxX;
        bool inRangeY = MinY <= y && y <= MaxY;
        bool cellVisitAllowed = true;

        if (cellVisitAllowed && inRangeX && inRangeY)
        {
            VisitCell(x, y);
        }
    }

    public static void Cook(Potato potato)
    {
    }

    public static void VisitCell(int x, int y)
    {
    }
}