using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.School
{
    abstract class Person : SchoolObject
    {
        public Person(string name, string comments = null)
            : base(name, comments)
        {
        }
    }
}
