using System;

namespace _5.HashedSet
{
    public class HashedSetDemo
    {
        public static void Main()
        {
            HashedSet<int> hashSet = new HashedSet<int>();
            HashedSet<int> otherSet = new HashedSet<int>();

            for (int i = 0; i < 20; i++)
            {
                hashSet.Add(i);
                otherSet.Add(i + 10);
            }

            Console.WriteLine("Test intersect:");
            otherSet.IntersectWith(hashSet);
            Console.WriteLine(otherSet);

            otherSet.Add(-4);
            otherSet.Add(1015);
            Console.WriteLine("Test union:");
            otherSet.UniontWith(hashSet);
            Console.WriteLine(otherSet);
        }
    }
}
