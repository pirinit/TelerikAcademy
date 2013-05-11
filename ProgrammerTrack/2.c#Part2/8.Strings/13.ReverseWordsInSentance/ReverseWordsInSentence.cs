using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 13. Write a program that reverses the words in given sentence. 
* Example:
* "C# is not C++, not PHP and not Delphi!"
* Result:
* "Delphi not and PHP, not C++ not is C#!".
*/
class ReverseWordsInSentence
{
    static void Main()
    {
        string sentence = "C# is not C++, not PHP and not Delphi!";
        string wordBreaks = " .!?,;";

        StringBuilder result = new StringBuilder();
        string[] words = sentence.Split(wordBreaks.ToCharArray());//, StringSplitOptions.RemoveEmptyEntries);
        int wordsIndex = words.Length - 2;

        //for (int i = 0; i < words.Length; i++)
        //{
        //    Console.WriteLine(words[i]);
        //}

        for (int i = 0; i < sentence.Length; i++)
        {
            if (wordBreaks.Contains(sentence[i]))
            {
                result.Append(words[wordsIndex--]);
                result.Append(sentence[i]);
            }
        }

        Console.WriteLine(result);
    }
}