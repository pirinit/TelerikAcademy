using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

/* 12. Write a program that reads a list of words from a file words.txt
 * and finds how many times each of the words is contained in another file
 * test.txt. The result should be written in the file result.txt and the words
 * should be sorted by the number of their occurrences in descending order.
 * Handle all possible exceptions in your methods.
 */
class WordsFrequency
{
    static List<string> ReadWords(string fileName)
    {
        List<string> words = new List<string>();
        StreamReader input = new StreamReader(fileName);
        using (input)
        {
            string currentWord = input.ReadLine();
            while (currentWord != null)
            {
                words.Add(currentWord.Trim());
                currentWord = input.ReadLine();
            }
        }
        return words;
    }

    static void Main()
    {
        string wordsFileName = "words.txt";
        string inputFileName = "input.txt";
        string outputFileName = "output.txt";
        StreamReader input = new StreamReader(inputFileName);
        StreamWriter output = new StreamWriter(outputFileName);

        try
        {
            List<string> words = ReadWords(wordsFileName);
            string line = input.ReadLine();
            Dictionary<string,int> wordsCount = new Dictionary<string,int>();
            while (line != null)
            {
                string[] lineWords = line.Split(' ', '.', ',', '!', '?', ';', ':');
                foreach (string word in lineWords)
                {
                    if (words.Contains(word))
                    {
                        if (wordsCount.ContainsKey(word))
                        {
                            wordsCount[word]++;
                        }
                        else
                        {
                            wordsCount.Add(word, 1);
                        }
                    }
                }
                line = input.ReadLine();
            }

            var sortedDictionary = (from d in wordsCount
                                    orderby d.Value descending
                                    select d)
                                    .ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (var pair in sortedDictionary)
            {
                output.WriteLine(pair.Key + " " + pair.Value);
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            input.Dispose();
            output.Dispose();
            Console.WriteLine("Done!");
        }
    }
}