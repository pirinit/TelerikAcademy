using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 4. Write a program that downloads a file from Internet
 * (e.g. http://www.devbg.org/img/Logo-BASD.jpg) and stores it the current directory.
 * Find in Google how to download files in C#.
 * Be sure to catch all exceptions and to free any used resources in the finally block.
 */
class FileDownloader
{
    static void Main()
    {
        WebClient wc = new WebClient();
        string address = "http://www.devbg.org/img/Logo-BASD.jpg";
        string fileName = "Logo.jpg";
        try
        {
            Console.WriteLine("Downloading {0}...", address);
            wc.DownloadFile(address, fileName);
            Console.WriteLine("File downloaded.");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("The address parameter can't be NULL.");
        }
        catch (WebException we)
        {
            Console.WriteLine(we.Message);
        }
        finally
        {
            wc.Dispose();
        }
    }
}