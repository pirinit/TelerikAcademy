using System;

public class Statistics
{
    public static void Main(string[] args)
    {
        double[] arr = new double[] { 5, 8, 108, 42 };
        PrintStatistics(arr);
    }

    public static void PrintStatistics(double[] arr)
    {
        double max = FindMax(arr);
        Console.WriteLine("Max : {0}.", max);

        double min = FindMin(arr);
        Console.WriteLine("Min : {0}",min);

        double average = FindAverage(arr);
        Console.WriteLine("Average : {0}", average);
    }
  
    private static double FindAverage(double[] arr)
    {
        double sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum / arr.Length;
    }
  
    private static double FindMin(double[] arr)
    {
        double min = double.MaxValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }

        return min;
    }
  
    private static double FindMax(double[] arr)
    {
        double max = double.MinValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }

        return max;
    }
}