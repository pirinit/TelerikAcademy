using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

/* 12. Write a program that removes from a text file all words listed in given
 * another text file. Handle all possible exceptions in your methods.
 */
class RemoveWordsFromFile
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

    static string CreateRegExPattern(List<string> words)
    {
        StringBuilder regExPattern = new StringBuilder();
        for (int i = 0; i < words.Count-1; i++)
        {
            regExPattern.AppendFormat(@"\b{0}\b|", words[i]);
        }
        regExPattern.AppendFormat(@"\b{0}\b|", words[words.Count-1]);
        return @regExPattern.ToString();
    }
    static void Main()
    {
        string wordsFileName = "words.txt";
        string inputFileName = "input.txt";
        string outputFileName = "temp.txt";
        StreamReader input = new StreamReader(inputFileName);
        StreamWriter output = new StreamWriter(outputFileName);

        try
        {
            List<string> words = ReadWords(wordsFileName);
            string regexPattern = @CreateRegExPattern(words);
            string line = input.ReadLine();
            while (line != null)
            {
                string result = Regex.Replace(line, regexPattern, "");
                output.WriteLine(result);
                line = input.ReadLine();
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

        File.Delete(inputFileName);
        File.Move("temp.txt", inputFileName);
    }
}