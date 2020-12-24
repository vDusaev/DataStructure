using System;

namespace Structure
{
    public class LinkedListDuplexItem<T>
    {
        private T data = default(T);
        public T Data
        {
            get => data;
            set
            {
                if (value != null)
                    data = value;
                else
                    throw new ArgumentNullException(nameof(value));
            }
        }
        public LinkedListDuplexItem<T> Previous { get; set; }
        public LinkedListDuplexItem<T> Next { get; set; }

        public LinkedListDuplexItem(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
