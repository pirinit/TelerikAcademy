using System.Collections;
using System.Collections.Generic;
using System.Text;
using _4.HashTable;

namespace _5.HashedSet
{
    public class HashedSet<T> : IEnumerable<T>
    {
        private HashTable<int, T> hashTable;

        public int Count
        {
            get
            {
                return this.hashTable.Count;
            }
        }

        public HashedSet()
        {
            this.hashTable = new HashTable<int, T>(17);
        }

        public void Add(T value)
        {
            this.hashTable.Add(value.GetHashCode(), value);
        }

        // implementig Find(T) is useless, so I implemented Contains(T)
        public bool Contains(T value)
        {
            return this.hashTable.Contains(value.GetHashCode());
        }

        public void Remove(T value)
        {
            this.hashTable.Remove(value.GetHashCode());
        }

        public void Clear()
        {
            this.hashTable.Clear();
        }

        public void UniontWith(IEnumerable<T> other)
        {
            foreach (var item in other)
            {
                this.hashTable.TryAdd(item.GetHashCode(), item);
            }
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            HashTable<int, T> newHashTable = new HashTable<int, T>();

            foreach (var item in other)
            {
                int currentItemHashCode = item.GetHashCode();
                if(this.hashTable.Contains(currentItemHashCode))
                {
                    newHashTable.Add(currentItemHashCode, item);
                }
            }

            this.hashTable = newHashTable;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var value in this.hashTable.Values)
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
            foreach (var item in this.hashTable.Values)
            {
                sb.AppendFormat(" {0},", item);
            }
            sb.Length--;
            sb.Append(" }");

            return sb.ToString();
        }
    }
}
