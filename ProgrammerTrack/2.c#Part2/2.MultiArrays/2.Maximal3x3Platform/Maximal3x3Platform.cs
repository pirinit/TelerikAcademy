using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 2. Write a program that reads a rectangular matrix of size N x M
 * and finds in it the square 3 x 3 that has maximal sum of its elements.
 */

class Maximal3x3Platform
{
    static void Main()
    {
        const int PlatformSize = 3;
        Console.Write("Please enter matrix height n = ");
        string input = Console.ReadLine();
        int n = int.Parse(input);
        Console.Write("Please enter matrix width m = ");
        input = Console.ReadLine();
        int m = int.Parse(input);
        int[,] matrix = new int[n, m];

        for (int row = 0; row < n; row++)
        {
            input = Console.ReadLine();
            string[] inputs = input.Split();
            for (int col = 0; col < m; col++)
            {
                
                matrix[row, col] = int.Parse(inputs[col]);
            }
        }

        int maxPlatformSum = int.MinValue;
        int maxPlatformStartRow = 0;
        int maxPlatformStartCol = 0;
        for (int row = 0; row < n-2; row++)
        {
            for (int col = 0; col < m-2; col++)
            {
                int currentPlatformSum = 0;
                for (int i = 0; i < PlatformSize * PlatformSize; i++)
                {
                    currentPlatformSum += matrix[row + i / PlatformSize, col + i % PlatformSize];
                }
                if (currentPlatformSum > maxPlatformSum)
                {
                    maxPlatformSum = currentPlatformSum;
                    maxPlatformStartRow = row;
                    maxPlatformStartCol = col;
                }
            }
        }
        Console.WriteLine("The 3x3 platform with maximal sum of {0} is:", maxPlatformSum);
        for (int i = 0; i < PlatformSize * PlatformSize; i++)
        {
            if (i % 3 == 0)
            {
                Console.WriteLine();
            }
            Console.Write("{0, 4}", matrix[maxPlatformStartRow + i / PlatformSize, maxPlatformStartCol + i % PlatformSize]);
        }
        Console.WriteLine();
    }
}