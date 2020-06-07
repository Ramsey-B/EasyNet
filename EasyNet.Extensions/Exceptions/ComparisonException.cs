using System;

namespace EasyNet.Extensions.Exceptions
{
    public class ComparisonException : Exception
    {
        public ComparisonException()
        {
        }

        public ComparisonException(string message)
            : base(message)
        {
        }

        public ComparisonException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
