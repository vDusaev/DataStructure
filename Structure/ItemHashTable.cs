using System.Collections.Generic;

namespace Structure
{
    public class ItemHashTable<T>
    {
        public int Key { get; set; }
        public List<T> Nodes { get; set; }

        public ItemHashTable(int key)
        {
            Key = key;
            Nodes = new List<T>();
        }
    }
}
