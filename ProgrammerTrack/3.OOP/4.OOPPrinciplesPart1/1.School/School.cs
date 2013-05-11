using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.School
{
    class School : SchoolObject
    {
        public List<SchoolClass> Classes { get; private set; }
        public School(string name, string comment = null)
            : base(name, comment)
        {
            this.Classes = new List<SchoolClass>();
        }

        internal void AddClass(SchoolClass schoolClass)
        {
            this.Classes.Add(schoolClass);
        }

        internal void RemoveClass(SchoolClass schoolClass)
        {
            if (!this.Classes.Remove(schoolClass))
            {
                throw new ArgumentException("No such class.");
            }
        }
    }
}
