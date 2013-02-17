using System;

class DivideBySevenAndFive
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int input = int.Parse(Console.ReadLine());
        if (input % 7 == 0 && input % 5 == 0)
        {
            Console.WriteLine("{0} divides by 7 and 5 without remainder.", input);
        }
        else
        {
            Console.WriteLine("{0} does not divides by 7 and 5 without remainder.", input);
        }
    }
}