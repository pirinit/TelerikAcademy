using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 6. Write a program that prints from given array of integers all numbers
 * that are divisible by 7 and 3. Use the built-in extension methods and
 * lambda expressions. Rewrite the same with LINQ.
 * 
 * Additional ordering in ascending mode was intensional :)
 */

class Student
{
    private string firstName;
    private string lastName;
    private int age;

    public Student(string firstName, string lastName, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    public Student(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            this.age = value;
        }
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            this.lastName = value;
        }
    }

    public override string ToString()
    {
        return String.Format("{0} {1}", this.firstName, this.lastName);
    }
}

class DivisibleBy3And7
{
    static void Main()
    {
        int[] numbers = new int[] { 5, 840, 7, 9, 10, 111, -5454, 88721, 21, 84 };

        var divisible = numbers.Where(x => x % 3 == 0 && x%7 == 0).OrderBy(x=>x);

        var divisibleLinq =
            from number in numbers
            where number % 3 == 0 && number % 7 == 0
            orderby number
            select number;

        Console.WriteLine("Divisible by 3 AND 7, using lambda:");
        foreach (var number in divisible)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("Divisible by 3 AND 7, using LINQ:");
        foreach (var number in divisibleLinq)
        {
            Console.WriteLine(number);
        }
    }
}