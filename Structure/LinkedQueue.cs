using System;

namespace Structure
{
    public class LinkedQueue<T>
    {
        private ItemDuplex<T> head;
        private ItemDuplex<T> tail;
        public int Count { get; private set; }

        public LinkedQueue() { }
        public LinkedQueue(T data)
        {
            SetNewHeadAndTail(data);
        }

        public void Enqueue(T data)
        {
            if (Count == 0)
            {
                SetNewHeadAndTail(data);
                return;
            }

            var item = new ItemDuplex<T>(data);
            tail.Previous = item;
            tail = item;
            Count++;
        }
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new ArgumentNullException("Queue is null");
            }

            var item = head;
            head.Previous.Next = null;
            head = item.Previous;
            return item.Data;
        }
        public T Peek()
        {
            return head.Data;
        }

        private void SetNewHeadAndTail(T data)
        {
            head = new ItemDuplex<T>(data);
            tail = head;
            Count = 1;
        }
    }
}
