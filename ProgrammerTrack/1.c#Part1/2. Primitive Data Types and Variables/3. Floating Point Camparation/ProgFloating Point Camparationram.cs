using System;

class FloatingPointCamparation
{
    static void Main()
    {
        double firstNumber = 5.3;
        double secondNumber = 6.01;
        double precision = 0.000001;
        bool isEqual;
        if (Math.Abs(firstNumber - secondNumber) < precision)
        {
            isEqual = true;
        }
        else
        {
            isEqual = false;
        }
        Console.WriteLine(isEqual);
    }
}