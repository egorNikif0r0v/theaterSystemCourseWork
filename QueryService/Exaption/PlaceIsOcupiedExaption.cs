using System;
using System.Collections.Generic;
using System.Text;

namespace QueryService.Exaption
{
    public class PlaceIsOcupiedExaption : Exception
    {
        public PlaceIsOcupiedExaption()
        {
        }

        public PlaceIsOcupiedExaption(string message)
        : base(message)
        {
        }

        public PlaceIsOcupiedExaption(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
