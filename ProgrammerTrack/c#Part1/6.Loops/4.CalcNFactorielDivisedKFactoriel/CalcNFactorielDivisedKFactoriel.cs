using System;
using System.Numerics;

class CalcNFactorielDivisedKFactoriel
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
        Console.Write("Enter k (k>0): ");
        string input = Console.ReadLine();
        int k = int.Parse(input);
        Console.Write("Enter n (n>{0}): ", k);
        input = Console.ReadLine();
        int n = int.Parse(input);
        Console.WriteLine("N! / K! = {0}", CalcFactoriel(k+1,n));
    }
}