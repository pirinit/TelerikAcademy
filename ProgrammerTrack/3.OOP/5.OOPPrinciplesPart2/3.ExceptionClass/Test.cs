using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.ExceptionClass
{
    class Test
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Exception handling test with \"int\".");
            try
            {
                SampleMethodInt();
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine("Error message: {0}\nRange lower boundry: {1}\nRange upper boundry: {2}\nArgument actual value: {3}", ex.Message, ex.RangeStart, ex.RangeEnd, ex.InvalidParameter);
            }


            Console.WriteLine("\n\n\nException handling test with \"DateTime\".");
            try
            {
                SampleMethodDT();
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine("Error message: {0}\nRange lower boundry: {1}\nRange upper boundry: {2}\nArgument actual value: {3}", ex.Message, ex.RangeStart, ex.RangeEnd, ex.InvalidParameter);
            }
        }

        static void SampleMethodInt()
        {
            int lowBoundryInt = 0;
            int upperBoundryInt = 100;

            Console.Write("Please enter int between {0} and {1}:", lowBoundryInt, upperBoundryInt);
            int sampleInt = int.Parse(Console.ReadLine());

            //sampleInt = -100;
            if (lowBoundryInt > sampleInt || sampleInt > upperBoundryInt)
            {
                throw new InvalidRangeException<int>( lowBoundryInt, upperBoundryInt, sampleInt, "Invalid int argument.");
            }
            Console.WriteLine("Entered value is: {0}", sampleInt);
        }

        static void SampleMethodDT()
        {
            DateTime lowBoundryDT = new DateTime(1980, 1, 1);
            DateTime upperBoundryDT = new DateTime(2013, 12, 31);

            DateTime sampleDT = new DateTime(2015, 10, 10);

            if (lowBoundryDT > sampleDT || sampleDT > upperBoundryDT)
            {
                throw new InvalidRangeException<DateTime>(lowBoundryDT, upperBoundryDT, sampleDT, "Invalid DateTime argument.");
            }
            Console.WriteLine("Entered value is: {0}", sampleDT);
        }
    }
}