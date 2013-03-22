using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* 4. Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
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

class StudentFilter
{
    const int AgeDownBoundry = 18;
    const int AgeUpBoundry = 24;
    static void Main()
    {
        Student[] students = new Student[10];
        students[0] = new Student("Pesho", "Stoyanov", 15);
        students[1] = new Student("Pesho", "Alexsandrov", 27);
        students[2] = new Student("Pesho", "Boyanov", 21);
        students[3] = new Student("Pesho", "Tyankov", 24);
        students[4] = new Student("Pesho", "Zdravkov", 19);

        var filteredStudents =
            from student in students
            where student != null && AgeDownBoundry <= student.Age && student.Age <= AgeUpBoundry
            select new { firstName = student.FirstName, lastName = student.LastName };

        foreach (var student in filteredStudents)
        {
            Console.WriteLine("{0} {1}", student.firstName, student.lastName);
        }
    }
}