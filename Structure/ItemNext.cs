using System;

namespace Structure
{
    public class ItemNext<T>
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
        public ItemNext<T> Next { get; set; }

        public ItemNext(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
