using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public abstract class Course
    {
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Course name can not be null, empty string or contain only white spaces.");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public string TeacherName { get; set; }

        public IList<string> Students { get; set; }

        public Course(string courseName, string teacherName = null, IList<string> students = null)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            if (students != null)
            {
                this.Students = students;
            }
            else
            {
                this.Students = new List<string>();
            }
        }

        protected string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }
            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }
    }
}
