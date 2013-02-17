using System;

class IsPrime
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        bool isPrime = true;
        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                isPrime = false;
                break;
            }
        }
        if (isPrime)
        {
            Console.WriteLine("{0} is prime number.", number);
        }
        else
        {
            Console.WriteLine("{0} is not prime number.", number);
        }
    }
}