using System;

class TwoStrings
{
    static void Main()
    {
        string firstString = "The \"use\" of quotations causes difficulties.";
        string quatedString = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine("{0}\n{1}", firstString, quatedString);
    }
}