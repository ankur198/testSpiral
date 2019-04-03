using System.Collections.Generic;

namespace Spiral
{
    class Row<T>
    {
        private List<Element<T>> Elements { get; set; }

        public Row(int NumberOfElements)
        {
            Elements = new List<Element<T>>();
        }

        public Element<T> this[int index] => Elements[index];
    }
}
