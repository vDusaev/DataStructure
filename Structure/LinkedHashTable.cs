namespace Structure
{
    public class LinkedHashTable<T>
    {
        private ItemHashTable<T>[] items;

        public LinkedHashTable(int size = 10)
        {
            items = new ItemHashTable<T>[size];
            for (int i = 0; i < size; i++)
            {
                items[i] = new ItemHashTable<T>(i);
            }
        }

        public void Add(T item)
        {
            var key = getHashCode(item);
            items[key].Nodes.Add(item);
        }
        public bool Search(T item)
        {
            var key = getHashCode(item);
            return items[key].Nodes.Contains(item);
        }

        private int getHashCode(T item)
        {
            return item.GetHashCode() % items.Length;
        }
    }
}
