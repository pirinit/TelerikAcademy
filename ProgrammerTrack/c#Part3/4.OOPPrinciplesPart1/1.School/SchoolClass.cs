using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.School
{
    class SchoolClass : SchoolObject
    {
        public List<Student> Students { get; private set; }
        public List<Teacher> Teachers { get; private set; }
        private int lastClassNumber;

        public SchoolClass(string name, string comments = null)
            : base(name, comments)
        {
            this.lastClassNumber = 1;
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
        }

        internal void AddStudent(Student student)
        {
            student.ClassNumber = this.lastClassNumber;
            this.lastClassNumber++;
            this.Students.Add(student);
        }

        internal void RemoveStudent(Student student)
        {
            int studentIndex = this.Students.IndexOf(student);
            if (studentIndex < 0)
            {
                throw new ArgumentException("No such student.");
            }
            else
            {
                this.Students.RemoveAt(studentIndex);
                for (int i = studentIndex; i < this.Students.Count; i++)
                {
                    this.Students[i].ClassNumber--;
                }
                this.lastClassNumber--;
            }
        }

        internal void AddTeacher(Teacher teacher)
        {
            this.Teachers.Add(teacher);
        }

        internal void RemoveTeacher(Teacher teacher)
        {
            if (!this.Teachers.Remove(teacher))
            {
                throw new ArgumentException("No such teacher.");
            }
        }
    }
}
