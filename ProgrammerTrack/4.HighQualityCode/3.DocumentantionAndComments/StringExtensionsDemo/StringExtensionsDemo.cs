using System;
using Telerik.ILS.Common;

public class StringExtensionsDemo
{
    public static void Main(string[] args)
    {
        string test = "start sadsa endda some other junk";
        Console.WriteLine(test.ToMd5Hash());
        Console.WriteLine(test.CapitalizeFirstLetter());
        Console.WriteLine(test.GetStringBetween("start", "other"));

        string cyrilic = "текст на кирилИца and sOme latin";
        Console.WriteLine(cyrilic.ConvertCyrillicToLatinLetters());
        Console.WriteLine(cyrilic.ConvertLatinToCyrillicKeyboard());

        string userName = "s##ome rea()lly strange chars % @";
        Console.WriteLine(userName.ToValidUsername());
    }
}