using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 12. Write a program that parses an URL address given in the format:
 * [protocol]://[server]/[resource]
 * and extracts from it the [protocol], [server] and [resource] elements.
 * For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
 * [protocol] = "http"
 * [server] = "www.devbg.org"
 * [resource] = "/forum/index.php"
 */
class ParseURL
{
    static void Main()
    {
        string input = "http://www.devbg.org/forum/index.php";
        int firstSeparator = input.IndexOf("://");
        int secondSeparator = input.IndexOf('/',firstSeparator+3);

        string protocol = input.Substring(0, firstSeparator);
        string server = input.Substring(firstSeparator + 3, secondSeparator - (firstSeparator + 3));
        string resourse = input.Substring(secondSeparator);

        Console.WriteLine(protocol);
        Console.WriteLine(server);
        Console.WriteLine(resourse);
    }
}