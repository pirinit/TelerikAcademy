using System;

class StringAndObject
{
    static void Main()
    {
        string firstString = "Hello";
        string secondString = "World";
        object thirdString = firstString + ' ' + secondString;
        string fourthString = (string)thirdString;
        Console.WriteLine("{0}\n{1}\n{2}\n{3}", firstString, secondString, thirdString, fourthString);
    }
}