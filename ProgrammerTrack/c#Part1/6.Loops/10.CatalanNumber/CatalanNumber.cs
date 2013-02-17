using System;
using System.Numerics;

class CatalanNumber
{
    static BigInteger CalcFactoriel(int lowerBoundery, int upperBoundery)
    {
        int min = (lowerBoundery < upperBoundery) ? lowerBoundery : upperBoundery;
        int max = (lowerBoundery < upperBoundery) ? upperBoundery : lowerBoundery;
        if (min <= 0)
        {
            min = 1;
        }
        BigInteger factoriel = 1;

        for (int i = min; i <= max; i++)
        {
            factoriel *= i;
        }

        return factoriel;
    }
    static void Main()
    {
        string input = Console.ReadLine();
        int n = int.Parse(input);
        BigInteger result = CalcFactoriel(n + 2, 2 * n) / CalcFactoriel(1, n);
        Console.WriteLine(result);
    }
}