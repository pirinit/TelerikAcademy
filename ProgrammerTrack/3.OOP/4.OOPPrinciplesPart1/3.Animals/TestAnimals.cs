using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 3. Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors
 * and methods. Dogs, frogs and cats are Animals. All animals can produce sound
 * (specified by the ISound interface). Kittens and tomcats are cats.
 * All animals are described by age, name and sex. Kittens can be only female and tomcats
 * can be only male. Each animal produces a specific sound. Create arrays of different
 * kinds of animals and calculate the average age of each kind of animal
 * using a static method (you may use LINQ).
 */
namespace _3.Animals
{
    class TestAnimals
    {
        static void Main(string[] args)
        {
            Dog[] dogs = new Dog[]
            {
                new Dog("pesho",155,Gender.Male),
                new Dog("minka", 8, Gender.Female),
                new Dog("penka", 11, Gender.Female),
                new Dog("jessy", 15, Gender.Female),
                new Dog("sonya", 3, Gender.Female),
            };

            Tomcat[] tomcats = new Tomcat[]
            {
                new Tomcat("pisancho",4),
                new Tomcat("debeliq",9),
                new Tomcat("oshte po-debeliq",11),
                new Tomcat("pisancho",6),
                new Tomcat("pisancho",99)
            };

            Console.WriteLine("Dogs average age is: {0}", AverageAge(dogs));
            Console.WriteLine("Tomcats average age is: {0}", AverageAge(tomcats));
        }

        static int AverageAge(Animal[] animals)
        {
            int averageAge = (int)animals.Average<Animal>(x => x.Age);
            return averageAge;
        }
    }
}
