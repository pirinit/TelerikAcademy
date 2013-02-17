using System;

class GreatestCommonDivisor
{
    static void Main()
    {
        string input = Console.ReadLine();
        int firstNumber = int.Parse(input);
        input = Console.ReadLine();
        int secondNumber = int.Parse(input);
        int temp;
        if (firstNumber < secondNumber)
        {
            temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;
        }
        Console.Write("The greatest common divisor of {0} and {1} is", firstNumber, secondNumber);
        while (firstNumber != secondNumber)
        {
            if (firstNumber > secondNumber * 2)
            {
                firstNumber = secondNumber + firstNumber % secondNumber;
            }
            if (firstNumber == secondNumber)
            {
                break;
            }
            firstNumber = firstNumber - secondNumber;
            if (firstNumber < secondNumber)
            {
                temp = firstNumber;
                firstNumber = secondNumber;
                secondNumber = temp;
            }
        }
        Console.WriteLine(" {0}.",firstNumber);
    }
}