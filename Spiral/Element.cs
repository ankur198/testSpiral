namespace Spiral
{
    class Element<T>
    {
        public bool Visited { get; set; }
        public T Value { get; set; }

        public Element(T value)
        {
            Value = value;
        }
    }
}
