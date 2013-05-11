using System;

class BonusScores
{
    static void Main()
    {
        Console.Write("Enter a digit[1-9]: ");
        string input = Console.ReadLine();
        int digit = int.Parse(input);
        int result;
        switch (digit)
        {
            case 1:
            case 2:
            case 3:
                result = digit * 10;
                break;
            case 4:
            case 5:
            case 6:
                result = digit * 100;
                break;
            case 7:
            case 8:
            case 9:
                result = digit * 1000;
                break;
            default:
                result = -1;
                break;
        }
        if (result == -1)
        {
            Console.WriteLine("You have entered an invalid number.");
        }
        else
        {
            Console.WriteLine(result);
        }
    }
}