using System.Collections;

namespace Structure
{
    public class LinkedListCircular<T> : IEnumerable
    {
        public ItemDuplex<T> Head { get; set; }
        public int Count { get; set; }

        public LinkedListCircular() { }
        public LinkedListCircular(T data)
        {
            SetHeadItem(data);
        }

        private void SetHeadItem(T data)
        {
            Head = new ItemDuplex<T>(data);
            Head.Next = Head;
            Head.Previous = Head;
            Count = 1;
        }
        public void Add(T data)
        {
            if (Count == 0)
            {
                SetHeadItem(data);
                return;
            }

            var item = new ItemDuplex<T>(data);
            item.Next = Head;
            item.Previous = Head.Previous;
            Head.Previous.Next = item;
            Head.Previous = item;
            Count++;
        }
        public void Delete(T data)
        {
            if (Head.Data.Equals(data))
            {
                RemoveItem(Head);
                Head = Head.Next;
                return;
            }

            var current = Head.Next;
            for (int i = Count; i > 0; i--)
            {
                if (current != null && current.Data.Equals(data))
                {
                    RemoveItem(current);
                }

                current = current.Next;
            }
        }

        private void RemoveItem(ItemDuplex<T> current)
        {
            current.Next.Previous = current.Previous;
            current.Previous.Next = current.Next;
            Count--;
        }
        public IEnumerator GetEnumerator()
        {
            var current = Head;
            for (int i = 0; i < Count; i++)
            {
                yield return current;
                current = current.Next;
            }
        }
    }
}
