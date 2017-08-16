using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionary
{
    public class Dictnry<K,V>: IEnumerable<KeyValuePair<K,V>>
    {
        private int INITIAL_SIZE = 16;

        private LinkedList<KeyValuePair<K, V>>[] values;

        public Dictnry()
        {
            this.values = new LinkedList<KeyValuePair<K, V>>[this.INITIAL_SIZE];
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return this.values.Length;
            }
        }

        public void Add(K key, V value)
        {
            var hash = HashKey(key);
            if(this.values[hash] == null)
            {
                this.values[hash] = new LinkedList<KeyValuePair<K, V>>();
            }

            var keyExistsAlready = this.values[hash].Any(p => p.Key.Equals(key));
            if (keyExistsAlready)
            {
                throw new InvalidOperationException("Key already exisits");
            }

            var pair = new KeyValuePair<K, V>(key, value);
            this.values[hash].AddLast(pair);
            this.Count++;

            if(this.Count >= this.Capacity * 0.75)
            {
                this.ResizeAndReAddValues();
            }

        }

        public V Find(K key)
        {
            var hash = this.HashKey(key);
            if(this.values[hash] == null)
            {
                return default(V);
            }

            return this.values[hash].First(kvp => kvp.Key.Equals(key)).Value;
        }

        public bool ContainsKey(K key)
        {
            var hash = this.HashKey(key);
            if (this.values[hash] == null)
            {
                return false;
            }

            return this.values[hash].Any(kvp => kvp.Key.Equals(key));
        }

        private int HashKey(K key)
        {
            var hash = Math.Abs(key.GetHashCode()) % this.Capacity;
            return hash;
        }

        private void ResizeAndReAddValues()
        {
            //cache values
            //increase size of collection
            //readd values

            var cachedValues = this.values;
            this.values = new LinkedList<KeyValuePair<K, V>>[this.Capacity * 2];
            this.Count = 0;
            foreach (var collection in cachedValues)
            {
                if (collection != null)
                {
                    foreach (var kvp in collection)
                    {
                        this.Add(kvp.Key, kvp.Value);
                    } 
                }
            }

        }



        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var collection in this.values)
            {
                if (collection != null)
                {
                    foreach (var kvp in collection)
                    {
                        yield return kvp;
                    } 
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
