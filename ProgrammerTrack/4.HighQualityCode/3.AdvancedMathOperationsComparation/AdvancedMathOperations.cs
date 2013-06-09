using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AdvancedMathOperations
{
    //square root
    public static void SquareRoothBenchmark(float number, int iterations)
    {
        for (int i = 0; i < iterations; i++)
        {
            Math.Sqrt(number);
        }
    }

    public static void SquareRoothBenchmark(double number, int iterations)
    {
        for (int i = 0; i < iterations; i++)
        {
            Math.Sqrt(number);
        }
    }

    public static void SquareRoothBenchmark(decimal number, int iterations)
    {
        for (int i = 0; i < iterations; i++)
        {
            Math.Sqrt((double)number);
        }
    }

    // natural log
    public static void NaturalLogBenchmark(float number, int iterations)
    {
        for (int i = 0; i < iterations; i++)
        {
            Math.Log(number);
        }
    }

    public static void NaturalLogBenchmark(double number, int iterations)
    {
        for (int i = 0; i < iterations; i++)
        {
            Math.Log(number);
        }
    }

    public static void NaturalLogBenchmark(decimal number, int iterations)
    {
        for (int i = 0; i < iterations; i++)
        {
            Math.Log((double)number);
        }
    }

    //sinus
    public static void SinusBenchmark(float number, int iterations)
    {
        for (int i = 0; i < iterations; i++)
        {
            Math.Sin(number);
        }
    }

    public static void SinusBenchmark(double number, int iterations)
    {
        for (int i = 0; i < iterations; i++)
        {
            Math.Sin(number);
        }
    }

    public static void SinusBenchmark(decimal number, int iterations)
    {
        for (int i = 0; i < iterations; i++)
        {
            Math.Sin((double)number);
        }
    }
}