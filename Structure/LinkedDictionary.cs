using System;
using System.Collections;
using System.Collections.Generic;

namespace Structure
{
    public class LinkedDictionary<TKey, TValue> : IEnumerable
    {
        private ItemMap<TKey, TValue>[] items;
        private List<TKey> keys = new List<TKey>();
        private int size;

        public LinkedDictionary(int size = 100)
        {
            this.size = size;
            items = new ItemMap<TKey, TValue>[this.size];
        }

        public void Add(TKey key, TValue value)
        {
            if (keys.Contains(key))
            {
                return;
            }

            var hashCode = getHash(key);

            var flag = false;
            for (int i = hashCode; i < size; i++)
            {
                if (items[i] == null)
                {
                    items[i] = new ItemMap<TKey, TValue>(key, value);
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                for (int i = 0; i < hashCode; i++)
                {
                    if (items[hashCode] == null)
                    {
                        items[hashCode] = new ItemMap<TKey, TValue>(key, value);
                        break;
                    }
                }
            }
        }

        public void Remove(TKey key)
        {
            if (keys.Contains(key))
            {
                return;
            }

            var hashCode = getHash(key);

            var flag = false;
            for (int i = hashCode; i < size; i++)
            {
                if (items[i] != null && items[i].Key.Equals(key))
                {
                    items[i] = null;
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                for (int i = 0; i < hashCode; i++)
                {
                    if (items[i] != null && items[i].Key.Equals(key))
                    {
                        items[i] = null;
                        break;
                    }
                }
            }
        }

        public TValue Search(TKey key)
        {
            if (keys.Contains(key))
            {
                return default(TValue);
            }

            var hashCode = getHash(key);

            var flag = false;
            for (int i = hashCode; i < size; i++)
            {
                if (items[i] != null && items[i].Key.Equals(key))
                {
                    return items[i].Value;
                }
            }
            if (!flag)
            {
                for (int i = 0; i < hashCode; i++)
                {
                    if (items[i] != null && items[i].Key.Equals(key))
                    {
                        return items[i].Value;
                    }
                }
            }

            return default(TValue);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in items)
            {
                if (item != null)
                {
                    yield return item;
                }
            }
        }

        private int getHash(TKey key)
        {
            return key.GetHashCode() % size;
        }
    }
}
