﻿using System;

namespace Structure
{
    public class ItemDuplex<T>
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
        public ItemDuplex<T> Previous { get; set; }
        public ItemDuplex<T> Next { get; set; }

        public ItemDuplex(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
