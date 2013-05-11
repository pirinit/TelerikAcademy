using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.School
{
    class Discipline : SchoolObject
    {
        public int LecturesCount { get; set; }
        public int ExcercisesCount { get; set; }

        public Discipline(string name, int excercisesCount, string comments = null)
            : base(name, comments)
        {
            this.ExcercisesCount = excercisesCount;
        }
    }
}
