using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Structure
{
    public class LinkedSet<T> : IEnumerable
    {
        private List<T> set = new List<T>();
        public int Count => set.Count;

        public LinkedSet() { }
        public LinkedSet(T data) : this()
        {
            Add(data);
        }
        public LinkedSet(IEnumerable<T> data)
        {
            this.set = data.ToList();
        }

        public void Add(T data)
        {
            if (!set.Contains(data))
            {
                set.Add(data);
            }
        }
        public void Remove(T data)
        {
            set.Remove(data);
        }

        public LinkedSet<T> Union(LinkedSet<T> set, bool UseLinq = false)
        {
            if (UseLinq)
            {
                return new LinkedSet<T>(this.set.Union(set.set));
            }
            else
            {
                LinkedSet<T> result = new LinkedSet<T>(this.set);
                foreach (var item in set.set)
                {
                    result.Add(item);
                }

                return result;
            }
        }
        public LinkedSet<T> Intersection(LinkedSet<T> set, bool UseLinq = false)
        {
            if (UseLinq)
            {
                return new LinkedSet<T>(this.set.Intersect(set.set));
            }
            else
            {
                LinkedSet<T> result = new LinkedSet<T>();
                List<T> smallSet;
                List<T> bigSet;

                if (Count < set.Count)
                {
                    smallSet = this.set;
                    bigSet = set.set;
                }
                else
                {
                    smallSet = set.set;
                    bigSet = this.set;
                }

                foreach (var itemSmall in smallSet)
                {
                    foreach (var itemBig in bigSet)
                    {
                        if (itemSmall.Equals(itemBig))
                        {
                            result.Add(itemSmall);
                            break;
                        }
                    }
                }

                return result;
            }
        }
        public LinkedSet<T> Difference(LinkedSet<T> set, bool UseLinq = false)
        {
            if (UseLinq)
            {
                return new LinkedSet<T>(this.set.Except(set.set));
            }
            else
            {
                var result = new LinkedSet<T>(this.set);
                foreach (var item in set.set)
                {
                    result.Remove(item);
                }
                return result;
            }
        }
        public bool Subset(LinkedSet<T> set, bool UseLinq = false)
        {
            if (UseLinq)
            {
                return this.set.All(i => set.set.Contains(i));
            }
            else
            {
                foreach (var thisItem in this.set)
                {
                    var equals = false;

                    foreach (var setItem in set.set)
                    {
                        if (thisItem.Equals(setItem))
                        {
                            equals = true;
                            break;
                        }
                    }

                    if (!equals)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
        public LinkedSet<T> SymmetricDifference(LinkedSet<T> set, bool UseLinq = false)
        {
            if (UseLinq)
            {
                return new LinkedSet<T>(this.set.Except(set.set).Union(set.set.Except(this.set)));
            }
            else
            {
                return this.Difference(set).Union(set.Difference(this));
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in set)
            {
                yield return item;
            }
        }
        public override string ToString()
        {
            string result = "";

            foreach (var item in set)
            {
                result += item.ToString() + " ";
            }

            return result;
        }
    }
}
