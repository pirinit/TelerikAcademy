using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* 5. Using the extension methods OrderBy() and ThenBy() with lambda expressions sort
 * the students by first name and last name in descending order. Rewrite the same with LINQ.
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

class StudentsSort
{
    static void Main()
    {
        Student[] students = new Student[5];
        students[0] = new Student("Alex", "Stoyanov", 15);
        students[1] = new Student("Pesho", "Alexsandrov", 27);
        students[2] = new Student("Sasho", "Boyanov", 21);
        students[3] = new Student("Pesho", "Tyankov", 24);
        students[4] = new Student("Pesho", "Zdravkov", 19);

        //lambda
        var filteredStudents = students.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName);

        //LINQ
        var filteredStudentsLinq =
            from student in students
            where student != null
            orderby student.FirstName descending, student.LastName descending
            select student;


        Console.WriteLine("Sorted with lambda expression");
        foreach (var student in filteredStudents)
        {
            Console.WriteLine(student);
        }

        Console.WriteLine("Sorted with LINQ expression");
        foreach (var student in filteredStudentsLinq)
        {
            Console.WriteLine(student);
        }
    }
}