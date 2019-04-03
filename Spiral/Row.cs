﻿using System.Collections.Generic;

namespace Spiral
{
    class Row<T>
    {
        public readonly int Size;

        private Element<T>[] Elements { get; set; }

        public Row(int NumberOfElements)
        {
            Elements = new Element<T>[NumberOfElements];
            this.Size = NumberOfElements;

            for (int i = 0; i < Elements.Length; i++)
            {
                Elements[i] = new Element<T>(default);
            }
        }

        public Element<T> this[int index] => Elements[index];
    }
}
