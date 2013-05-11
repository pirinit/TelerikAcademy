using System;

class FibonacciSum
{
    static void Main()
    {
        string input = Console.ReadLine();
        int n = int.Parse(input);
        int currentFib = 1;
        int lastFib = 0;
        long sumFib = 1;
        int tempFib;
        for (int i = 0; i < n-2; i++)
        {
           // Console.Write(sumFib);
            tempFib = currentFib + lastFib;
            sumFib += tempFib;
            lastFib = currentFib;
            currentFib = tempFib;
           // Console.WriteLine(" + {0} = {1}", currentFib, sumFib);
        }
        Console.WriteLine(sumFib);
    }
}