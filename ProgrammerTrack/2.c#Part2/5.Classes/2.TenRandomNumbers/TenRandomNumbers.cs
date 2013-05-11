using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 2. Write a program that generates and prints to the console
 * 10 random values in the range [100, 200].
 */
class TenRandomNumbers
{
    static void Main()
    {
        Random random = new Random();
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("{0,2} random number between 100 and 200 is: {1}.", i+1, random.Next(100,201));
        }
    }
}