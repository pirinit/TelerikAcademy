using System;

class PrintsAgeAfter10Years
{
    static void Main()
    {
        Console.Write("Please enter your current age: ");
        int currentAge;
        while(int.TryParse(Console.ReadLine(), out currentAge)!=true)
        {
            Console.Write("Wrong input. Please enter your age using digits only ( 0-9): ");
        }

        Console.WriteLine("After 10 years you will be {0} years old.", currentAge+10);
    }
}