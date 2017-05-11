using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class HashTable : IHashTable
    {
        private class Entry
        {
            public object Key { get; set; }
            public object Value { get; set; }
        }

        private LinkedList<Entry>[] _buckets;

        private static int INIT_CAPACITY = 8;

        private int _capacity;
        private int _size;

        public HashTable(int capacity)
        {
            _capacity = capacity;
       
            _buckets = new LinkedList<Entry>[capacity];
            for (int i = 0; i < _buckets.Length; i++)
            {
                _buckets[i] = new LinkedList<Entry>();
            }
        }

        public HashTable() : this(INIT_CAPACITY)
        { }

        private int Hash(object key)
        {
            return (key.GetHashCode() & 0x7fffffff) % _capacity;
        }

        public bool Contains(object key)
        {
            return GetValue(key) != null;
        }

        public void Add(object key, object value)
        {
            if (GetValue(key) == null)
            {
                _size++;

                if(_size > 10*_capacity)
                    Resize(2*_capacity);

                _buckets[Hash(key)].AddLast(new Entry
                {
                    Key = key,
                    Value = value
                });
            }
            else
            {
                throw new InvalidOperationException("Such key already exists");
            }
        }

        public object this[object key]
        {
            get
            {
                var value = GetValue(key);
                if (value != null)
                    return value;
                throw new InvalidOperationException("Invalid key");
            }
            set
            {
                var entryValue = GetValue(key);
                if (entryValue == null)
                {
                    Add(key, value);
                }
                else
                {
                    var bucket = _buckets[Hash(key)];
                    foreach (var entry in bucket)
                    {
                       if (entry.Key.Equals(key))
                       {
                           if (value == null)
                           {
                               _size--;
                               if(_capacity > INIT_CAPACITY && _size < 2*_capacity)
                                    Resize(_capacity/2);
                               bucket.Remove(entry);
                           }
                           else
                           {
                             entry.Value = value;
                           }
                           break;
                       }
                    }
                }
            }
        }

        public bool TryGet(object key, out object value)
        {
            value = GetValue(key);
            return value != null;
        }

        private object GetValue(object key)
        {
            var bucket = _buckets[Hash(key)];
            foreach (var entry in bucket)
            {
                if (entry.Key.Equals(key))
                    return entry.Value;
            }
            return null;
        }

        private void Resize(int capacity)
        {
            HashTable ht = new HashTable(capacity);
            for (int i = 0; i < _buckets.Length; i++)
            {
                foreach (var entry in _buckets[i])
                {
                    ht.Add(entry.Key, entry.Value);
                }
            }
            _capacity = ht._capacity;
            _buckets = ht._buckets;
            _size = ht._size;
        }
    }
}
