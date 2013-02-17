using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 15. Write a program that finds all prime numbers
 * in the range [1...10 000 000]. Use the sieve of Eratosthenes
 * algorithm (find it in Wikipedia).
 */
class PrimeNumbers
{
    static void Main()
    {
        bool[] isPrime = new bool[10000000];
        Console.Write("1, ");
        int primeCount = 0;
        for (int i = 2; i < isPrime.Length; i++)
        {
            if (!(isPrime[i]))
            {
                Console.WriteLine("{0} - {1, -10} ", primeCount++,i);
                for (int j = i+i; j < isPrime.Length; j +=i)
                {
                    isPrime[j] = true;
                }
            }
        }
    }
}