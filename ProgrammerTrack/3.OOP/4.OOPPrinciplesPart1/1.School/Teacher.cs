using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.School
{
    class Teacher : Person
    {
        public List<Discipline> Disciplines { get; set; }

        public Teacher(string name, string comments = null)
            : base(name, comments)
        {
            this.Disciplines = new List<Discipline>();
        }

        internal void AddDiscipline(Discipline discipline)
        {
            this.Disciplines.Add(discipline);
            discipline.LecturesCount++;
        }

        internal void RemoveDiscipline(Discipline discipline)
        {
            if (!this.Disciplines.Remove(discipline))
            {
                throw new ArgumentException("No such discipline.");
            }
            discipline.LecturesCount--;
        }
    }
}
