using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

class SimpleMathOperationsComparation
{
    static void Main()
    {
        int iterations = 10000000;
        CheckAddition(iterations);
        CheckSubstraction(iterations);
        CheckIncrementation(iterations);
        CheckMultiplication(iterations);
        CheckDivision(iterations);
    }

    static void CheckAddition(int iterations)
    {
        Stopwatch sw = new Stopwatch();

        sw.Start();
        SimpleMathOperations.AddBenchmark(100, 150, iterations);
        sw.Stop();
        Console.WriteLine("Addititon - int - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        SimpleMathOperations.AddBenchmark(100L, 150L, iterations);
        sw.Stop();
        Console.WriteLine("Addititon - long - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        SimpleMathOperations.AddBenchmark(100.0f, 150.0f, iterations);
        sw.Stop();
        Console.WriteLine("Addititon - float - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        SimpleMathOperations.AddBenchmark(100.0, 150.0, iterations);
        sw.Stop();
        Console.WriteLine("Addititon - double - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        SimpleMathOperations.AddBenchmark(100.0m, 150.0m, iterations);
        sw.Stop();
        Console.WriteLine("Addititon - decimal - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);
    }

    static void CheckSubstraction(int iterations)
    {
        Stopwatch sw = new Stopwatch();

        sw.Start();
        SimpleMathOperations.SubstractBenchmark(100, 150, iterations);
        sw.Stop();
        Console.WriteLine("Substraction - int - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        SimpleMathOperations.SubstractBenchmark(100L, 150L, iterations);
        sw.Stop();
        Console.WriteLine("Substraction - long - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        SimpleMathOperations.SubstractBenchmark(100.0f, 150.0f, iterations);
        sw.Stop();
        Console.WriteLine("Substraction - float - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        SimpleMathOperations.SubstractBenchmark(100.0, 150.0, iterations);
        sw.Stop();
        Console.WriteLine("Substraction - double - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        SimpleMathOperations.SubstractBenchmark(100.0m, 150.0m, iterations);
        sw.Stop();
        Console.WriteLine("Substraction - decimal - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);
    }

    static void CheckIncrementation(int iterations)
    {
        Stopwatch sw = new Stopwatch();

        sw.Start();
        SimpleMathOperations.IncrementBenchmark(100, iterations);
        sw.Stop();
        Console.WriteLine("Incrementation - int - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        SimpleMathOperations.IncrementBenchmark(100L, iterations);
        sw.Stop();
        Console.WriteLine("Incrementation - long - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        SimpleMathOperations.IncrementBenchmark(100.0f, iterations);
        sw.Stop();
        Console.WriteLine("Incrementation - float - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        SimpleMathOperations.IncrementBenchmark(100.0, iterations);
        sw.Stop();
        Console.WriteLine("Incrementation - double - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        SimpleMathOperations.IncrementBenchmark(100.0m, iterations);
        sw.Stop();
        Console.WriteLine("Incrementation - decimal - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);
    }

    static void CheckMultiplication(int iterations)
    {
        Stopwatch sw = new Stopwatch();

        sw.Start();
        SimpleMathOperations.MultiplyBenchmark(100, 150, iterations);
        sw.Stop();
        Console.WriteLine("Multiplication - int - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        SimpleMathOperations.MultiplyBenchmark(100L, 150L, iterations);
        sw.Stop();
        Console.WriteLine("Multiplication - long - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        SimpleMathOperations.MultiplyBenchmark(100.0f, 150.0f, iterations);
        sw.Stop();
        Console.WriteLine("Multiplication - float - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        SimpleMathOperations.MultiplyBenchmark(100.0, 150.0, iterations);
        sw.Stop();
        Console.WriteLine("Multiplication - double - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        SimpleMathOperations.MultiplyBenchmark(100.0m, 150.0m, iterations);
        sw.Stop();
        Console.WriteLine("Multiplication - decimal - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);
    }

    static void CheckDivision(int iterations)
    {
        Stopwatch sw = new Stopwatch();

        sw.Start();
        SimpleMathOperations.DivideBenchmark(100, 150, iterations);
        sw.Stop();
        Console.WriteLine("Division - int - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        SimpleMathOperations.DivideBenchmark(100L, 150L, iterations);
        sw.Stop();
        Console.WriteLine("Division - long - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        SimpleMathOperations.DivideBenchmark(100.0f, 150.0f, iterations);
        sw.Stop();
        Console.WriteLine("Division - float - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        SimpleMathOperations.DivideBenchmark(100.0, 150.0, iterations);
        sw.Stop();
        Console.WriteLine("Division - double - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        SimpleMathOperations.DivideBenchmark(100.0m, 150.0m, iterations);
        sw.Stop();
        Console.WriteLine("Division - decimal - Elapsed milliseconds: {0}.", sw.ElapsedMilliseconds);
    }
}