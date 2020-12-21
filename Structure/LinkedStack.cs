using System;

namespace Structure
{
    public class LinkedStack<T>
    {
        public LinkedStackItem<T> Head { get; set; } = null;
        public int Count { get; set; } = 0;

        public LinkedStack() { }
        public LinkedStack(T data) 
        {
            Head = new LinkedStackItem<T>(data);
            Count = 1;
        }

        public void Push(T data)
        {
            var newItem = new LinkedStackItem<T>(data);
            newItem.Previous = Head;
            Head = newItem;
            Count++;
        }
        public T Pop()
        {
            if (Count > 0)
            {
                var currentHead = Head;
                Head = currentHead.Previous;
                Count--;

                return currentHead.Data;
            }
            else
            {
                throw new NullReferenceException("Stack is empty");
            }
        }
        public T Peek()
        {
            if (Count > 0)
            {
                return Head.Data;
            }
            else
            {
                throw new NullReferenceException("Stack is empty");
            }
        }
    }
}
