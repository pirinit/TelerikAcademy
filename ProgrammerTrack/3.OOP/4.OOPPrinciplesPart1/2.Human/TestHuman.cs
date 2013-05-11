using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 2. Define abstract class Human with first name and last name.
 * Define new class Student which is derived from Human and has new field – grade.
 * Define class Worker derived from Human with new property WeekSalary
 * and WorkHoursPerDay and method MoneyPerHour() that returns money earned
 * by hour by the worker. Define the proper constructors and properties for this hierarchy.
 * Initialize a list of 10 students and sort them by grade in ascending order
 * (use LINQ or OrderBy() extension method). Initialize a list of 10 workers
 * and sort them by money per hour in descending order.
 * Merge the lists and sort them by first name and last name.
 */
namespace _2.Human
{
    class TestHuman
    {
        static void Main(string[] args)
        {
            Random random = new Random(555);

            //student test
            List<Student> students = new List<Student>();

            for (int i = 0; i < 10; i++)
            {
                string firstName = String.Format("FirstName-{0}", random.Next(1000));
                string lastName = String.Format("LastName-{0}", random.Next(1000));
                int grade = random.Next(10);
                students.Add(new Student(firstName, lastName, grade));
            }

            Console.WriteLine("Unsorted students:");
            PrintStudents(students);
            var sortedStudents =
                from student in students
                orderby student.Grade
                select student;
            Console.WriteLine("Sorted with LINQ:");
            PrintStudents(sortedStudents.ToList<Student>());
            ;
            Console.WriteLine("Sorted with extension methods and lambda:");
            PrintStudents(students.OrderBy(x => x.Grade).ToList<Student>());

            //worker test
            List<Worker> workers= new List<Worker>();

            for (int i = 0; i < 10; i++)
            {
                string firstName = String.Format("FirstName-{0}", random.Next(1000));
                string lastName = String.Format("LastName-{0}", random.Next(1000));
                decimal weekSalary = (decimal)(random.Next(1000));
                double workHoursPerDay = ((double)random.Next(1,1200))/100;
                int workDaysPerWeek = random.Next(1,7);
                workers.Add(new Worker(firstName, lastName, weekSalary, workHoursPerDay, workDaysPerWeek));
            }

            Console.WriteLine("Unsorted workers:");
            PrintWorkers(workers);

            var sortedWorkers =
                from worker in workers
                orderby worker.MoneyPerHour() descending
                select worker;
            Console.WriteLine("Sorted workers with LINQ:");
            PrintWorkers(sortedWorkers.ToList<Worker>());

            Console.WriteLine("Sorted workers with extension methods and lambda:");
            PrintWorkers(workers.OrderByDescending(x=> x.MoneyPerHour()).ToList<Worker>());

            List<Human> humans = new List<Human>(students);
            humans.AddRange(workers);

            var sortedHumans =
                from human in humans
                orderby human.FirstName, human.LastName
                select human;
            Console.WriteLine("Sorted humans with LINQ:");
            PrintHumans(humans);
        }

        static void PrintStudents(List<Student> students)
        {
            Console.WriteLine("Students:");
            foreach (var student in students)
            {
                Console.WriteLine("{0} {1}, grade: {2}", student.FirstName, student.LastName, student.Grade);
            }
        }

        static void PrintWorkers(List<Worker> workers)
        {
            Console.WriteLine("Workers:");
            foreach (var worker in workers)
            {
                Console.WriteLine("{0} {1}, moneyPerHour: {2:f2}", worker.FirstName, worker.LastName, worker.MoneyPerHour());
            }
        }

        static void PrintHumans(List<Human> humans)
        {
            Console.WriteLine("Humans:");
            foreach (var human in humans)
            {
                Console.WriteLine("{0} {1}", human.FirstName, human.LastName);
            }
        }
    }
}
