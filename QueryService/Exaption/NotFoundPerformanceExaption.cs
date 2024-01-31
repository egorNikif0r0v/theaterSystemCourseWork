using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace QueryService.Exaption
{
    public class NotFoundPerformanceExaption : Exception
    {
        public NotFoundPerformanceExaption()
        {
        }

        public NotFoundPerformanceExaption(string message)
        : base(message)
        {
        }

        public NotFoundPerformanceExaption(string message, Exception inner)
        : base(message, inner)
        {
        }

        protected NotFoundPerformanceExaption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
