using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 4. Create a class Person with two fields – name and age. Age can be left
 * unspecified (may contain null value. Override ToString() to display
 * the information of a person and if age is not specified – to say so.
 * Write a program to test this functionality.
 */ 
namespace _4.Person
{
    class TestPerson
    {
        static void Main(string[] args)
        {
            Person ivan = new Person("Ivan");
            Person dragan = new Person("Dragan", 20);

            Console.WriteLine(ivan);
            Console.WriteLine(dragan);

            Person petkan = new Person(null);
            Console.WriteLine(petkan);
        }
    }
}
