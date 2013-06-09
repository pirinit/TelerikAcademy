using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

class SimpleMathOperationsComparation
{
    public delegate void Operation(int firstOperand, int secondOperand, int iterationsCount);

    static void Main()
    {
        CheckBasicTypesPerformance<int>("Addition", AddBenchmark);
    }

    static void CheckBasicTypesPerformance<T>(string operationName, Operation operation)
    {
        Stopwatch sw = new Stopwatch();
        int iterations = 100000000;

        sw.Start();
        AddBenchmark(100, 150, iterations);
        sw.Stop();
        Console.WriteLine("{0} - int - Elapsed milliseconds: {1}.", operationName, sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        AddBenchmark(100L, 150L, iterations);
        sw.Stop();
        Console.WriteLine("{0} - long - Elapsed milliseconds: {1}.", operationName, sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        AddBenchmark(100.0f, 150.0f, iterations);
        sw.Stop();
        Console.WriteLine("{0} - float - Elapsed milliseconds: {1}.", operationName, sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        AddBenchmark(100.0, 150.0, iterations);
        sw.Stop();
        Console.WriteLine("{0} - double - Elapsed milliseconds: {1}.", operationName, sw.ElapsedMilliseconds);

        sw.Reset();
        sw.Start();
        AddBenchmark(100.0m, 150.0m, iterations);
        sw.Stop();
        Console.WriteLine("{0} - decimal - Elapsed milliseconds: {1}.", operationName, sw.ElapsedMilliseconds);
    }

    static void AddBenchmark<T>(T firstOperand, T secondOperand, int iterationsCount)
    {
        dynamic sum = firstOperand;
        for (int i = 0; i < iterationsCount; i++)
        {
            sum = (dynamic)firstOperand + (dynamic)secondOperand;
        }
    }

    static void AddBenchmark(int firstOperand, int secondOperand, int iterationsCount)
    {
        int sum = firstOperand;
        for (int i = 0; i < iterationsCount; i++)
        {
            sum = firstOperand + secondOperand;
        }
    }

    static void AddBenchmark(long firstOperand, long secondOperand, int iterationsCount)
    {
        long sum = firstOperand;
        for (int i = 0; i < iterationsCount; i++)
        {
            sum = firstOperand + secondOperand;
        }
    }

    static void AddBenchmark(float firstOperand, float secondOperand, int iterationsCount)
    {
        float sum = firstOperand;
        for (int i = 0; i < iterationsCount; i++)
        {
            sum = firstOperand + secondOperand;
        }
    }

    static void AddBenchmark(double firstOperand, double secondOperand, int iterationsCount)
    {
        double sum = firstOperand;
        for (int i = 0; i < iterationsCount; i++)
        {
            sum = firstOperand + secondOperand;
        }
    }

    static void AddBenchmark(decimal firstOperand, decimal secondOperand, int iterationsCount)
    {
        decimal sum = firstOperand;
        for (int i = 0; i < iterationsCount; i++)
        {
            sum = firstOperand + secondOperand;
        }
    }

    static void SubstractBenchmark<T>(T firstOperand, T secondOperand, int iterationsCount)
    {
        dynamic substraction = firstOperand;
        for (int i = 0; i < iterationsCount; i++)
        {
            substraction = (dynamic)firstOperand - (dynamic)secondOperand;
        }
    }
}