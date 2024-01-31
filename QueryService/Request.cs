using System;
using System.Collections.Generic;
using System.Text;

namespace QueryService
{
    public struct Request
    {
        public string Name { get; set; }

        // get info
        // ticket booking
        // cancellation
        public string Request_ { get; set; }
        public string NameTheater { get; set; }
        public string NamePerformance { get; set; }
        public List<int> PlaceNumber { get; set; }

        
    }
}
