namespace RangeExceptions.Exceptions
{
    using System;

    public class InvalidRangeException<T> : ApplicationException where T : struct, IFormattable
    {
        private T rangeStart;
        private T rangeEnd;

        public InvalidRangeException(string message, T start, T end) 
            : base(message)
        {
            this.RangeStart = start;
            this.RangeEnd = end;
        }

        public T RangeStart { get; private set; }

        public T RangeEnd { get; private set; }
    }
}
