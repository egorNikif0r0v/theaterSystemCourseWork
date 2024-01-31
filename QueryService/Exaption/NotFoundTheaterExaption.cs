using System;
using System.Collections.Generic;
using System.Text;

namespace QueryService.Exaption
{
    public class NotFoundTheaterExaption : Exception
    {
        public NotFoundTheaterExaption()
        {
        }

        public NotFoundTheaterExaption(string message)
        : base(message)
        {
        }

        public NotFoundTheaterExaption(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
