using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* 3. Write a method that from a given array of students finds all students
 * whose first name is before its last name alphabetically. Use LINQ query operators.
 */
class Student
{
    private string firstName;
    private string lastName;

    public Student(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
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
    static void Main()
    {
        Student[] students = new Student[10];
        students[0] = new Student("Pesho", "Stoyanov");
        students[1] = new Student("Pesho", "Alexsandrov");
        students[2] = new Student("Pesho", "Boyanov");
        students[3] = new Student("Pesho", "Tyankov");
        students[4] = new Student("Pesho", "Zdravkov");

        var filteredStudents =
            from student in students
            where student != null && student.FirstName.CompareTo(student.LastName) < 0
            select student;

        foreach (var student in filteredStudents)
        {
            Console.WriteLine(student);
        }

    }
}