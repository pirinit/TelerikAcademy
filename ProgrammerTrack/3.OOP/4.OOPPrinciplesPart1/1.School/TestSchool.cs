using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 1. We are given a school. In the school there are classes of students.
 * Each class has a set of teachers. Each teacher teaches a set of disciplines.
 * Students have name and unique class number. Classes have unique text identifier.
 * Teachers have name. Disciplines have name, number of lectures and number of exercises.
 * Both teachers and students are people. Students, classes, teachers and disciplines
 * could have optional comments (free text block). Your task is to identify the classes
 * (in terms of  OOP) and their attributes and operations, encapsulate their fields,
 * define the class hierarchy and create a class diagram with Visual Studio.
 */
namespace _1.School
{
    class TestSchool
    {
        static void Main(string[] args)
        {
            School school = new School("Telerik", "A good place to educate yourselves");
            SchoolClass group = new SchoolClass("Group", "The best students are here");
            school.Classes.Add(group);
            Teacher nakov = new Teacher("Nakov", "Master teacher");
            Teacher george = new Teacher("George", "Ninja");
            group.Teachers.Add(nakov);
            group.Teachers.Add(george);

            Discipline oop = new Discipline("OOP", 9, "base discipline");
            Console.WriteLine("Lectures count in OOP: {0} ", oop.LecturesCount);
            nakov.AddDiscipline(oop);
            george.AddDiscipline(oop);
            //when adding discipline to a teacher LectureCount increments automatically
            Console.WriteLine("Lectures count in OOP: {0}", oop.LecturesCount);
            george.RemoveDiscipline(oop);

            Student baiIvan = new Student("Bai Ivan", "great guy");
            Student pesho = new Student("Pesho");

            //adding students and techers
            school.Classes[0].AddStudent(baiIvan);
            school.Classes[0].AddStudent(pesho);
            school.Classes[0].AddTeacher(nakov);
            school.Classes[0].AddTeacher(george);

            //every student receives unique class number
            foreach (Student student in school.Classes[0].Students)
            {
                Console.WriteLine("Student name: {0}, class number: {1}", student.Name, student.ClassNumber);
            }

            school.Classes[0].RemoveStudent(baiIvan);

            //after student is removed from a class the other student class numbers are updated automatically
            foreach (Student student in school.Classes[0].Students)
            {
                Console.WriteLine("Student name: {0}, class number: {1}", student.Name, student.ClassNumber);
            }
        }
    }
}
