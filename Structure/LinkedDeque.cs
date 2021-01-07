using System;

namespace Structure
{
    public class LinkedDeque<T>
    {
        private ItemDuplex<T> head;
        private ItemDuplex<T> tail;
        public int Count { get; private set; }

        public LinkedDeque() { }
        public LinkedDeque(T data)
        {
            NewHeadAndTail(data);
        }

        public void PushFront(T data)
        {
            if (data == null)
            {
                return;
            }
            if (Count == 0)
            {
                NewHeadAndTail(data);
            }

            var item = new ItemDuplex<T>(data);
            head.Next = item;
            item.Previous = head;
            head = item;
        }
        public void PushBack(T data)
        {
            if (data == null)
            {
                return;
            }
            if (Count == 0)
            { 
                NewHeadAndTail(data);
            }

            var item = new ItemDuplex<T>(data);
            tail.Previous = item;
            item.Next = tail;
            tail = item;
        }
        public T PopFront()
        {
            if (Count == 0)
            {
                throw new ArgumentNullException("Deque is null");
            }

            var item = head;
            head.Previous.Next = null;
            head = item.Previous;
            return item.Data;
        }
        public T PopBack()
        {
            if (Count == 0)
            {
                throw new ArgumentNullException("Deque is null");
            }

            var item = tail;
            tail.Next.Previous = null;
            tail = item.Next;
            return item.Data;
        }
        public T PeekFront()
        {
            return head.Data;
        }
        public T PeekBack()
        {
            return tail.Data;
        }

        private void NewHeadAndTail(T data)
        {
            if (data == null)
            {
                return;
            }

            head = new ItemDuplex<T>(data);
            tail = head;
            Count = 1;
        }
    }
}
