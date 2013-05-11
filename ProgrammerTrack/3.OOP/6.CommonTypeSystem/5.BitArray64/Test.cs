using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.ClassBitArray64
{
    class Test
    {
        static void Main(string[] args)
        {

            BitArray64 arr = new BitArray64();
            
            //indexator test - getter and setter
            arr[5] = true;
            Console.WriteLine(arr[5]);
            Console.WriteLine(arr[6]);
            for (int i = 0; i < 64; i++)
            {
                Console.WriteLine(arr[i]);
            }

            // equals test

            Console.WriteLine();
            BitArray64 arr1 = new BitArray64();

            arr1[4] = true;
            // arr and arr1 holds the same information, the value of arr.bits == arr1.bits
            // so they are equal
            Console.WriteLine(arr.Equals(arr1));

            //hashcode test - the hashcode of BitArray64 is the value of the 'bits' ulong number
            arr1[0] = true;
            Console.WriteLine(arr.GetHashCode());
            Console.WriteLine(arr1.GetHashCode());

            //IEnumerator test

            foreach (var bit in arr1)
            {
                Console.WriteLine(bit);
            }

            Console.WriteLine();
        }
    }
}
