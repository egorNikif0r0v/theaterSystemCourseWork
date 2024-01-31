using System;
using System.Collections.Generic;
using System.Text;
using Theater;

namespace QueryService
{
    public interface IResponseRequest
    {
        public enum Action_ : byte
        {
            booking,
            cancellation,
            getInfo,
        }

        public int Id { get; set; }
        public Action_ Action { get; set; }
        public string NameTheater { get; set; }
        public string NamePerformance { get; set; }
        public List<int> PlaceNumber { get; set; }
    }
}
