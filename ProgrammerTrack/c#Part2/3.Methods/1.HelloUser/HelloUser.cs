using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 1. Write a method that asks the user for his name and prints “Hello, <name>”
 * (for example, “Hello, Peter!”). Write a program to test this method.
 */
class HelloUser
{
    static void Hello()
    {
        Console.Write("Please enter your name: "); ;
        string name = Console.ReadLine();
        Console.WriteLine("Hello, {0}!", name);
    }
    static void Main()
    {
        Hello();
    }
}