using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    class MultiDictionary<K, V> : IMultiDictionary<K, V>, IEnumerable<KeyValuePair<K, V>>
    {
        public Dictionary<K, LinkedList<V>> Dictionary { get; set; }

        public MultiDictionary()
        {
            Dictionary = new Dictionary<K, LinkedList<V>>();
        }

        public int Count
        {
            get
            {
                return Values.Count;
            }
        }

        public ICollection<K> Keys
        {
            get
            {
                return Dictionary.Keys;
            }
        }

        public ICollection<V> Values
        {
            get
            {
                List<V> values = new List<V>();

                foreach(K key in Keys)
                {
                    foreach(V value in Dictionary[key])
                    {
                        values.Add(value);
                    }
                }

                return values;
            }
        }

        public void Add(K key, V value)
        {
            if(!Dictionary.ContainsKey(key))
            {
                Dictionary[key] = new LinkedList<V>();
            }

            Dictionary[key].AddLast(value);
        }

        public void Clear()
        {
            Dictionary.Clear();
        }

        public bool Contains(K key, V value)
        {
            return ContainsKey(key) && Dictionary[key].Contains(value);
        }

        public bool ContainsKey(K key)
        {
            return Dictionary.ContainsKey(key);
        }

        public bool Remove(K key)
        {
            return Dictionary.Remove(key);
        }

        public bool Remove(K key, V value)
        {
            return Dictionary[key].Remove(value);
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            HashSet<KeyValuePair<K, V>> enumerator = new HashSet<KeyValuePair<K, V>>();

            foreach(K key in Keys)
            {
                foreach(V value in Dictionary[key])
                {
                    enumerator.Add(new KeyValuePair<K, V>(key, value));
                }
            }

            return enumerator.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
