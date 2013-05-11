using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 14. A dictionary is stored as a sequence of text lines containing words and
 * their explanations. Write a program that enters a word and translates it
 * by using the dictionary.
 * Sample dictionary:
 * .NET - platform for applications from Microsoft
 * CLR - managed execution environment for .NET
 * namespace - hierarchical organization of classes
 */
class Dictionary
{
    static void Main()
    {
        string dict = @".NET - platform for applications from Microsoft
CLR - managed execution environment for .NET
namespace - hierarchical organization of classes";

        string[] separator = new string[]{"\r\n"};
        string[] lines = dict.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        for (int i = 0; i < lines.Length; i++)
        {
            int separatorIndex = lines[i].IndexOf('-');
            dictionary.Add(lines[i].Substring(0,separatorIndex).Trim(),lines[i].Substring(separatorIndex+1).Trim());
        }
        //foreach (var entry in dictionary)
        //{
        //    Console.WriteLine("{0} -> {1}",entry.Key, entry.Value);
        //}

        Console.Write("Please enter term to resolve: ");
        string term = Console.ReadLine();

        if (dictionary.ContainsKey(term))
        {
            Console.WriteLine("{0} -> {1}", term, dictionary[term]);
        }
        else
        {
            Console.WriteLine("There is no such term in the dictionary.");
        }
    }
}