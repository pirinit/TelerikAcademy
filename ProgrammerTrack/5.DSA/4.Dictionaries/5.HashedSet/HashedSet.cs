using System.Collections;
using System.Collections.Generic;
using System.Text;
using _4.HashTable;

namespace _5.HashedSet
{
    public class HashedSet<T> : IEnumerable<T>
    {
        private HashTable<T, int> hashTable;

        public int Count
        {
            get
            {
                return this.hashTable.Count;
            }
        }

        public HashedSet()
        {
            this.hashTable = new HashTable<T, int>(17);
        }

        public void Add(T value)
        {
            this.hashTable.Add(value, 0);
        }

        // implementig Find(T) is useless, so I implemented Contains(T)
        public bool Contains(T value)
        {
            return this.hashTable.Contains(value);
        }

        public void Remove(T value)
        {
            this.hashTable.Remove(value);
        }

        public void Clear()
        {
            this.hashTable.Clear();
        }

        public void UniontWith(IEnumerable<T> other)
        {
            foreach (var item in other)
            {
                this.hashTable.TryAdd(item, 0);
            }
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            HashTable<T, int> newHashTable = new HashTable<T, int>();

            foreach (var item in other)
            {
                if(this.hashTable.Contains(item))
                {
                    newHashTable.Add(item, 0);
                }
            }

            this.hashTable = newHashTable;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var value in this.hashTable.Keys)
            {
                yield return value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            foreach (var item in this.hashTable.Keys)
            {
                sb.AppendFormat(" {0},", item);
            }
            sb.Length--;
            sb.Append(" }");

            return sb.ToString();
        }
    }
}
