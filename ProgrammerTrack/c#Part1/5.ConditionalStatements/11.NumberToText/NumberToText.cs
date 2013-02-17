using System;

class NumberToText
{
    static void Main()
    {
        Console.Write("Please enter a number [0-999]: ");
        string input = Console.ReadLine();
        int number = int.Parse(input);

        int hundreds = number / 100;
        int tens;
        int ones;
        if (number % 100 > 19)
        {
            tens = (number % 100) / 10;
            ones = number % 10;
        }
        else
        {
            tens = 0;
            ones = number % 100;
        }

        string result = "";

        switch (hundreds)
        {
            case 1:
                result = "one hundred";
                break;
            case 2:
                result = "two hundred";
                break;
            case 3:
                result = "three hundred";
                break;
            case 4:
                result = "four hundred";
                break;
            case 5:
                result = "five hundred";
                break;
            case 6:
                result = "six hundred";
                break;
            case 7:
                result = "seven hundred";
                break;
            case 8:
                result = "eight hundred";
                break;
            case 9:
                result = "nine hundred";
                break;
        }
        if (hundreds > 0 && (tens != 0 || ones != 0))
        {
            result = result
                + " ";
        }
        switch (tens)
        {
            case 2:
                result = result + "twenty";
                break;
            case 3:
                result = result + "thirty";
                break;
            case 4:
                result = result + "fourty";
                break;
            case 5:
                result = result + "fifty";
                break;
            case 6:
                result = result + "sixty";
                break;
            case 7:
                result = result + "seventy";
                break;
            case 8:
                result = result + "eighty";
                break;
            case 9:
                result = result + "ninety";
                break;
        }
        if (hundreds > 0 && ones > 0)
        {
            if (tens == 0)
            {
                result = result + "and ";
            }
            else
            {
                result = result + " ";
            }
        }
        if (hundreds == 0 && tens > 0 && ones > 0)
        {
            result = result + " ";
        }
        switch (ones)
        {
            case 1:
                result = result + "one";
                break;
            case 2:
                result = result + "two";
                break;
            case 3:
                result = result + "three";
                break;
            case 4:
                result = result + "four";
                break;
            case 5:
                result = result + "five";
                break;
            case 6:
                result = result + "six";
                break;
            case 7:
                result = result + "seven";
                break;
            case 8:
                result = result + "eight";
                break;
            case 9:
                result = result + "nine";
                break;
            case 10:
                result = result + "ten";
                break;
            case 11:
                result = result + "eleven";
                break;
            case 12:
                result = result + "twelve";
                break;
            case 13:
                result = result + "thirteen";
                break;
            case 14:
                result = result + "fourteen";
                break;
            case 15:
                result = result + "fiftteen";
                break;
            case 16:
                result = result + "sixteen";
                break;
            case 17:
                result = result + "seventeen";
                break;
            case 18:
                result = result + "eighteen";
                break;
            case 19:
                result = result + "nineteen";
                break;
        }
        if (hundreds == 0 && tens == 0 && ones == 0)
        {
            result = "zero";
        }
        Console.WriteLine("|{0}|", result);
    }
}