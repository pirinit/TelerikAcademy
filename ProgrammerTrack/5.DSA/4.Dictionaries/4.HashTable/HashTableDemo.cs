using System;

/* 4. Implement the data structure "hash table" in a class HashTable<K,T>.
 * Keep the data in array of lists of key-value pairs
 * (LinkedList<KeyValuePair<K,T>>[]) with initial capacity of 16.
 * When the hash table load runs over 75%, perform resizing to 2 times
 * larger capacity. Implement the following methods and properties:
 * Add(key, value), Find(key)value, Remove( key), Count, Clear(), this[], Keys.
 * Try to make the hash table to support iterating over its elements with foreach.
 */
namespace _4.HashTable
{
    public class HashTableDemo
    {
        public static void Main()
        {
            HashTable<string, int> ht = new HashTable<string, int>();

            ht.Add("five", 5);
            ht.Add("six", 6);

            Console.WriteLine(ht.Find("five"));
            // throws exception
            //Console.WriteLine(ht.Find("seven"));

            //test auto grow

            for (int i = 0; i < 16; i++)
            {
                ht.Add(i.ToString(), i);
                Console.WriteLine(ht.Count);
            }

            Console.WriteLine(ht.Find("five"));
            Console.WriteLine(ht.Find("9"));

            Console.WriteLine(ht.Count);
            ht.Remove("9");
            Console.WriteLine(ht.Count);

            Console.WriteLine("test indexator");
            Console.WriteLine(ht["10"]);
            ht["10"]++;
            Console.WriteLine(ht["10"]);
            // throws exception
            //Console.WriteLine(ht.Find("9"));

            Console.WriteLine("Test HashTable.Keys enumerator:");
            foreach (var key in ht.Keys)
            {
                Console.WriteLine(key);
            }

            Console.WriteLine("Test HashTable enumerator:");
            foreach (var pair in ht)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }
    }
}
