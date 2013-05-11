using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Animals
{
    class Cat: Animal
    {
        public Cat(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Cat: mrrrr... mrr...");
        }
    }
}
