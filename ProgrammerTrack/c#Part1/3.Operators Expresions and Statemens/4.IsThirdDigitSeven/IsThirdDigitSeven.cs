using System;

class IsThirdDigitSeven
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        bool isThirdDigitSeven = ((number / 100) % 10) == 7;
        if (isThirdDigitSeven)
        {
            Console.WriteLine("The third digit of {0} is 7.", number);
        }
        else
        {
            Console.WriteLine("The third digit of {0} is not 7.", number);
        }

        //string numberString = number.ToString();
        //bool resultString = numberString[numberString.Length - 3] == '7';
        //if (resultString)
        //{
        //    Console.WriteLine("The third digit of {0} is 7.", number);
        //}
        //else
        //{
        //    Console.WriteLine("The third digit of {0} is not 7.", number);
        //}
    }
}