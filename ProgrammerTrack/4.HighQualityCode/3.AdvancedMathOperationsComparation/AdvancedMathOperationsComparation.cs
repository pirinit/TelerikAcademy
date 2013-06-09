using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

class AdvancedMathOperationsComparation
{
    static void Main()
    {
        int iterations = 10000000;

        CheckSquareRoot(iterations);
        CheckNaturalLog(iterations);
        CheckSinus(iterations);
    }

    static void CheckSquareRoot(int iterations)
    {
        Stopwatch sw = new Stopwatch();

        sw.Start();
        AdvancedMathOperations.SquareRoothBenchmark(100.0f, iterations);
        sw.Stop();
        Console.WriteLine("Square root - float - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        AdvancedMathOperations.SquareRoothBenchmark(100.0, iterations);
        sw.Stop();
        Console.WriteLine("Square root - double - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        AdvancedMathOperations.SquareRoothBenchmark(100.0M, iterations);
        sw.Stop();
        Console.WriteLine("Square root - decimal - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);
    }

    static void CheckNaturalLog(int iterations)
    {
        Stopwatch sw = new Stopwatch();

        sw.Start();
        AdvancedMathOperations.NaturalLogBenchmark(100.0f, iterations);
        sw.Stop();
        Console.WriteLine("Natural log - float - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        AdvancedMathOperations.NaturalLogBenchmark(100.0, iterations);
        sw.Stop();
        Console.WriteLine("Natural log - double - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        AdvancedMathOperations.NaturalLogBenchmark(100.0M, iterations);
        sw.Stop();
        Console.WriteLine("Natural log - decimal - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);
    }

    static void CheckSinus(int iterations)
    {
        Stopwatch sw = new Stopwatch();

        sw.Start();
        AdvancedMathOperations.SinusBenchmark(100.0f, iterations);
        sw.Stop();
        Console.WriteLine("Sinus - float - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        AdvancedMathOperations.SinusBenchmark(100.0, iterations);
        sw.Stop();
        Console.WriteLine("Sinus - double - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        AdvancedMathOperations.SinusBenchmark(100.0M, iterations);
        sw.Stop();
        Console.WriteLine("Sinus - decimal - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);
    }
}