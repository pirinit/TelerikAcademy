using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.ExceptionClass
{
    class InvalidRangeException<T> : ApplicationException
    {
        public T RangeStart { get; private set; }
        public T RangeEnd { get; private set; }
        public T InvalidParameter { get; private set; }

        public InvalidRangeException(T rangeStart, T rangeEnd, T invalidParameter, string message = null, Exception innerException = null)
            : base(message, innerException)
        {
            this.RangeStart = rangeStart;
            this.RangeEnd = rangeEnd;
            this.InvalidParameter = invalidParameter;
        }
    }
}
