using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 5. You are given an array of strings. Write a method that sorts the array
* by the length of its elements (the number of characters composing them).
*/
class SortStringsByLength
{
    class StringByLenghtComparer : IComparer<string>
    {
        public int Compare(string first, string second)
        {
            return first.Length.CompareTo(second.Length);
        }
    }

    

    static void Main()
    {
        string[] strings = new string[]
        {
            "12345",
            "12",
            "324365",
            "123",
            "4321"
        };

        Array.Sort(strings, new StringByLenghtComparer());

        for (int i = 0; i < strings.Length; i++)
        {
            Console.WriteLine(strings[i]);
        }
    }
}