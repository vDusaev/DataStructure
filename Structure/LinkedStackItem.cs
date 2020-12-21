using System;

namespace Structure
{
    public class LinkedStackItem<T>
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
        public LinkedStackItem<T> Previous { get; set; }

        public LinkedStackItem(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
