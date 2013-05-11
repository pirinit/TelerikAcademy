using System;

class UsersInputChoice
{
    static void Main()
    {
        string input = Console.ReadLine();
        int number = 0;
        double doubleNumber = 0;
        if (int.TryParse(input, out number))
        {
            Console.WriteLine(++number);
        }
        else if (double.TryParse(input.Replace('.',','), out doubleNumber))
        {
            Console.WriteLine(++doubleNumber);
        }
        else
        {
            Console.WriteLine(input + "*");
        }
    }
}