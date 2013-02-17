using System;
using System.Numerics;

class NFactorielTrailingZeros
{
    static void Main()
    {
        string input = Console.ReadLine();
        int n = int.Parse(input);
        BigInteger sum = 1;
        int zeroCount = 0;

        //for (int i = 2; i <= n; i++)
        //{
        //    sum *= i;
        //}
        //Console.WriteLine(sum);
        //string result = sum.ToString();
        //for (int i = result.Length-1; i > 0; i--)
        //{
        //    if (result[i] == '0')
        //    {
        //        zeroCount++;
        //    }
        //    else
        //    {
        //        break;
        //    }
        //}
        //Console.WriteLine("Zero count is: {0}", zeroCount);
        //zeroCount = 0;
        int counter = 5;
        while (counter <= n)
        {
            int current = counter;
            while (current % 5 == 0)
            {
                zeroCount++;
                current /= 5;
            }
            counter += 5;
        }
        Console.WriteLine("Zero count is: {0}", zeroCount);
    }
}