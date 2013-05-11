using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 3. Write a program that enters file name along with its
 * full file path (e.g. C:\WINDOWS\win.ini), reads its contents
 * and prints it on the console. Find in MSDN how to use
 * System.IO.File.ReadAllText(…). Be sure to catch all possible
 * exceptions and print user-friendly error messages.
 */
class ReadFile
{
    static void Main()
    {
        Console.WriteLine("Enter the full path and name of the file to be printed:");
        string path = Console.ReadLine();
        try
        {
            Console.WriteLine(File.ReadAllText(path));
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("The path name can't be NULL. Do not press CTRL-Z, PLEASE!");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Invalid path name!");
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("Path too long! Either path exceeds 248 characters of file name exceeds 260 characters.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("No such directory.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("No such file.");
        }
        catch (IOException)
        {
            Console.WriteLine("General input/output error. Check if the file is still available.");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Path is in invalid format.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Acsess denied!");
        }
    }
} 