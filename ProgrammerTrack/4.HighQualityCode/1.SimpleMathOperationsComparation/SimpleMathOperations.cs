using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SimpleMathOperations
{
    //Addition
    public static void AddBenchmark(int firstOperand, int secondOperand, int iterationsCount)
    {
        int sum;
        for (int i = 0; i < iterationsCount; i++)
        {
            sum = firstOperand + secondOperand;
        }
    }

    public static void AddBenchmark(long firstOperand, long secondOperand, int iterationsCount)
    {
        long sum;
        for (int i = 0; i < iterationsCount; i++)
        {
            sum = firstOperand + secondOperand;
        }
    }

    public static void AddBenchmark(float firstOperand, float secondOperand, int iterationsCount)
    {
        float sum;
        for (int i = 0; i < iterationsCount; i++)
        {
            sum = firstOperand + secondOperand;
        }
    }

    public static void AddBenchmark(double firstOperand, double secondOperand, int iterationsCount)
    {
        double sum;
        for (int i = 0; i < iterationsCount; i++)
        {
            sum = firstOperand + secondOperand;
        }
    }

    public static void AddBenchmark(decimal firstOperand, decimal secondOperand, int iterationsCount)
    {
        decimal sum;
        for (int i = 0; i < iterationsCount; i++)
        {
            sum = firstOperand + secondOperand;
        }
    }

    //Substarction
    public static void SubstractBenchmark(int firstOperand, int secondOperand, int iterationsCount)
    {
        int result;
        for (int i = 0; i < iterationsCount; i++)
        {
            result = firstOperand - secondOperand;
        }
    }

    public static void SubstractBenchmark(long firstOperand, long secondOperand, int iterationsCount)
    {
        long result;
        for (int i = 0; i < iterationsCount; i++)
        {
            result = firstOperand - secondOperand;
        }
    }

    public static void SubstractBenchmark(float firstOperand, float secondOperand, int iterationsCount)
    {
        float result;
        for (int i = 0; i < iterationsCount; i++)
        {
            result = firstOperand - secondOperand;
        }
    }

    public static void SubstractBenchmark(double firstOperand, double secondOperand, int iterationsCount)
    {
        double result;
        for (int i = 0; i < iterationsCount; i++)
        {
            result = firstOperand - secondOperand;
        }
    }

    public static void SubstractBenchmark(decimal firstOperand, decimal secondOperand, int iterationsCount)
    {
        decimal sum = firstOperand;
        for (int i = 0; i < iterationsCount; i++)
        {
            sum = firstOperand - secondOperand;
        }
    }

    //incrementation

    public static void IncrementBenchmark(int firstOperand, int iterationsCount)
    {
        for (int i = 0; i < iterationsCount; i++)
        {
            firstOperand++;
        }
    }

    public static void IncrementBenchmark(long firstOperand, int iterationsCount)
    {
        for (int i = 0; i < iterationsCount; i++)
        {
            firstOperand++;
        }
    }

    public static void IncrementBenchmark(float firstOperand, int iterationsCount)
    {
        for (int i = 0; i < iterationsCount; i++)
        {
            firstOperand++;
        }
    }

    public static void IncrementBenchmark(double firstOperand, int iterationsCount)
    {
        for (int i = 0; i < iterationsCount; i++)
        {
            firstOperand++;
        }
    }

    public static void IncrementBenchmark(decimal firstOperand, int iterationsCount)
    {
        for (int i = 0; i < iterationsCount; i++)
        {
            firstOperand++;
        }
    }

    //multiplication
    public static void MultiplyBenchmark(int firstOperand, int secondOperand, int iterationsCount)
    {
        int result;
        for (int i = 0; i < iterationsCount; i++)
        {
            result = firstOperand * secondOperand;
        }
    }

    public static void MultiplyBenchmark(long firstOperand, long secondOperand, int iterationsCount)
    {
        long result;
        for (int i = 0; i < iterationsCount; i++)
        {
            result = firstOperand * secondOperand;
        }
    }

    public static void MultiplyBenchmark(float firstOperand, float secondOperand, int iterationsCount)
    {
        float result;
        for (int i = 0; i < iterationsCount; i++)
        {
            result = firstOperand * secondOperand;
        }
    }

    public static void MultiplyBenchmark(double firstOperand, double secondOperand, int iterationsCount)
    {
        double result;
        for (int i = 0; i < iterationsCount; i++)
        {
            result = firstOperand * secondOperand;
        }
    }

    public static void MultiplyBenchmark(decimal firstOperand, decimal secondOperand, int iterationsCount)
    {
        decimal result;
        for (int i = 0; i < iterationsCount; i++)
        {
            result = firstOperand * secondOperand;
        }
    }

    //division

    public static void DivideBenchmark(int firstOperand, int secondOperand, int iterationsCount)
    {
        int result;
        for (int i = 0; i < iterationsCount; i++)
        {
            result = firstOperand / secondOperand;
        }
    }

    public static void DivideBenchmark(long firstOperand, long secondOperand, int iterationsCount)
    {
        long result;
        for (int i = 0; i < iterationsCount; i++)
        {
            result = firstOperand / secondOperand;
        }
    }

    public static void DivideBenchmark(float firstOperand, float secondOperand, int iterationsCount)
    {
        float result;
        for (int i = 0; i < iterationsCount; i++)
        {
            result = firstOperand / secondOperand;
        }
    }

    public static void DivideBenchmark(double firstOperand, double secondOperand, int iterationsCount)
    {
        double result;
        for (int i = 0; i < iterationsCount; i++)
        {
            result = firstOperand / secondOperand;
        }
    }

    public static void DivideBenchmark(decimal firstOperand, decimal secondOperand, int iterationsCount)
    {
        decimal result;
        for (int i = 0; i < iterationsCount; i++)
        {
            result = firstOperand / secondOperand;
        }
    }
}