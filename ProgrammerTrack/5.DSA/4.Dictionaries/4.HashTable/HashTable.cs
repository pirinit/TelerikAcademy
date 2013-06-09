using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _4.HashTable
{
    public class HashTable<K, T> : IEnumerable<KeyValuePair<K,T>>
    {
        private const double MaxCapacityCoefficent = 0.75;
        private LinkedList<KeyValuePair<K, T>>[] array;
        private int count;
        private int listsCount;

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public T this[K key]
        {
            get
            {
                return Find(key);
            }
            set
            {
                Remove(key);
                Add(key, value);
            }
        }

        public IEnumerable<K> Keys
        {
            get
            {
                foreach (var list in this.array)
                {
                    if (list != null)
                    {
                        foreach (var pair in list)
                        {
                            yield return pair.Key;
                        }
                    }
                }
            }
        }

        public IEnumerable<T> Values
        {
            get
            {
                foreach (var list in this.array)
                {
                    if (list != null)
                    {
                        foreach (var pair in list)
                        {
                            yield return pair.Value;
                        }
                    }
                }
            }
        }

        public HashTable(int initialArraySize = 16)
        {
            this.array = new LinkedList<KeyValuePair<K, T>>[initialArraySize];
            this.count = 0;
            this.listsCount = 0;
        }

        public bool Contains(K key)
        {
            int index = CalcIndex(key);

            if (this.array[index] != null)
            {
                foreach (var pair in this.array[index])
                {
                    if (pair.Key.Equals(key))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void Clear()
        {
            this.array = new LinkedList<KeyValuePair<K, T>>[this.array.Length];
            this.count = 0;
        }

        public void Remove(K key)
        {
            if (TryRemove(key))
            {
                return;
            }

            string message = string.Format("Hash table does not contain '{0}' key.", key);
            throw new ArgumentException(message);
        }

        public bool TryRemove(K key)
        {
            int index = CalcIndex(key);

            KeyValuePair<K, T> pairToRemove = new KeyValuePair<K, T>();
            if (this.array[index] != null)
            {
                bool pairFound = false;
                foreach (var pair in this.array[index])
                {
                    if (pair.Key.Equals(key))
                    {
                        pairToRemove = pair;
                        pairFound = true;
                        break;
                    }
                }

                if (pairFound)
                {
                    this.array[index].Remove(pairToRemove);
                    this.count--;
                    return true;
                }
            }

            return false;
        }
        
        public T Find(K key)
        {
            var pair = FindPair(key);

            return pair.Value;
        }

        public void Add(K key, T value)
        {
            if (this.listsCount >= this.array.Length * MaxCapacityCoefficent)
            {
                Grow();
            }

            KeyValuePair<K, T> pairToAdd = new KeyValuePair<K, T>(key, value);
            int pairIndex = CalcIndex(key);

            // lazy initialization of the linked lists
            if (this.array[pairIndex] == null)
            {
                this.array[pairIndex] = new LinkedList<KeyValuePair<K, T>>();
                this.listsCount++;
            }

            // check for matching keys
            foreach (var pair in this.array[pairIndex])
            {
                if (pair.Key.Equals(key))
                {
                    string message = string.Format("Hash table already contains '{0}' key.", key);
                    throw new ArgumentException(message);
                }
            }

            this.array[pairIndex].AddLast(pairToAdd);
            this.count++;
        }

        public bool TryAdd(K key, T value)
        {
            if (this.listsCount >= this.array.Length * MaxCapacityCoefficent)
            {
                Grow();
            }

            KeyValuePair<K, T> pairToAdd = new KeyValuePair<K, T>(key, value);
            int pairIndex = CalcIndex(key);

            // lazy initialization of the linked lists
            if (this.array[pairIndex] == null)
            {
                this.array[pairIndex] = new LinkedList<KeyValuePair<K, T>>();
                this.listsCount++;
            }

            // check for matching keys
            foreach (var pair in this.array[pairIndex])
            {
                if (pair.Key.Equals(key))
                {
                    return false;
                }
            }

            this.array[pairIndex].AddLast(pairToAdd);
            this.count++;

            return true;
        }

        private void Grow()
        {
            LinkedList<KeyValuePair<K, T>>[] oldArray = this.array;
            this.array = new LinkedList<KeyValuePair<K, T>>[oldArray.Length * 2];
            this.listsCount = 0;

            foreach (var list in oldArray)
            {
                if (list != null)
                {
                    foreach (var pair in list)
                    {
                        AddPairGrow(pair);
                    }
                }
            }
        }

        private void AddPairGrow(KeyValuePair<K, T> pair)
        {
            int pairIndex = CalcIndex(pair.Key);
            // lazy initialization of the linked lists
            if (this.array[pairIndex] == null)
            {
                this.array[pairIndex] = new LinkedList<KeyValuePair<K, T>>();
                this.listsCount++;
            }

            this.array[pairIndex].AddLast(pair);
        }

        private int CalcIndex(K key)
        {
            int index = Math.Abs(key.GetHashCode()) % this.array.Length;
            return index;
        }

        private KeyValuePair<K, T> FindPair(K key)
        {
            int index = CalcIndex(key);

            if (this.array[index] != null)
            {
                foreach (var pair in this.array[index])
                {
                    if (pair.Key.Equals(key))
                    {
                        return pair;
                    }
                }
            }

            string message = string.Format("Hash table does not contain '{0}' key.", key);
            throw new ArgumentException(message);
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            foreach (var list in this.array)
            {
                if (list != null)
                {
                    foreach (var pair in list)
                    {
                        yield return pair;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}