using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.School
{
    class Student : Person
    {
        public int ClassNumber { get; internal set; }

        public Student(string name,string comments = null)
            : base(name, comments)
        {
        }
    }
}
