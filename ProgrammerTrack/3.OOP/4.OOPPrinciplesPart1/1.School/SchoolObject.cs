using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.School
{
    abstract class SchoolObject
    {
        public string Name { get; private set; }
        public string Comment { get; set; }

        public SchoolObject(string name, string comment=null)
        {
            this.Name = name;
            this.Comment = comment;
        }
    }
}
