using System;

namespace Structure
{
    public class ItemPrevious<T>
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
        public ItemPrevious<T> Previous { get; set; }

        public ItemPrevious(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
