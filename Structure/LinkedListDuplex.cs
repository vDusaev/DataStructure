using System.Collections;

namespace Structure
{
    public class LinkedListDuplex<T> : IEnumerable
    {
        public ItemDuplex<T> Head { get; set; }
        public ItemDuplex<T> Tail { get; set; }
        public int Count { get; private set; }

        public LinkedListDuplex() { }
        public LinkedListDuplex(T data)
        {
            SetHeadAndTail(data);
        }

        public void Add(T data)
        {
            if (Count == 0)
            {
                SetHeadAndTail(data);
            }
            else
            {
                var item = new ItemDuplex<T>(data);
                Tail.Next = item;
                item.Previous = Tail;
                Tail = item;
                Count++;
            }
        }
        public void Delete(T data)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (Count == 1)
                    {
                        current.Next = null;
                        current.Previous = null;
                        Head = null;
                        Tail = null;
                    }
                    else if (Head == current)
                    {
                        current.Next.Previous = null;
                        Head = current.Next;
                    }
                    else if (Tail == current)
                    {
                        current.Previous.Next = null;
                        Tail = current.Previous;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                    }
                    Count--;
                }
                current = current.Next;
            }
        }
        public LinkedListDuplex<T> Reverse()
        {
            var result = new LinkedListDuplex<T>();

            var current = Tail;
            while (current != null)
            {
                result.Add(current.Data);
                current = current.Previous;
            }

            return result;
        }

        private void SetHeadAndTail(T data)
        {
            Head = new ItemDuplex<T>(data);
            Tail = Head;
            Count = 1;
        }

        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
