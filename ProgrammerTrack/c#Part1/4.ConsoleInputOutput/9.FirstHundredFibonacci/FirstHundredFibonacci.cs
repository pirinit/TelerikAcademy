using System;
using System.Numerics;

class FirstHundredFibonacci
{
    static void Main()
    {
        decimal lastFib = 0;
        decimal currentFib = 1;
        decimal tempFib;
        Console.Write("{0}, {1},", lastFib, currentFib);
        for (int i = 2; i <= 100; i++)
        {
            tempFib = currentFib + lastFib;
            lastFib = currentFib;
            currentFib = tempFib;
            Console.Write("{0}, ", currentFib);
        }
    }
}