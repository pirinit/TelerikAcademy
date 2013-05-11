using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Person
{
    class Person
    {
        private string name;
        private int? age;

        public Person(string name, int? age = null)
        {
            this.name = name;
            this.age = age;
        }

        public int? Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            string ageStr = this.age != null ? this.age.ToString() : "<no age>";
            string result = string.Format("Name: {0}\nAge: {1}", this.name ?? "<no name>", ageStr);
            return result;
        }
    }
}
