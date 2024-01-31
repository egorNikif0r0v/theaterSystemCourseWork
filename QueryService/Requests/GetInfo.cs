using QueryService.Exaption;
using System.Collections.Generic;
using Theater;

namespace QueryService.Requests
{
    public class GetInfo : IRequest
    {
        public struct ResponseRequest<T> : IResponseRequest
        {
            public int Id { get; set; }
            public IResponseRequest.Action_ Action { get; set; }
            public string NameTheater { get; set; }
            public string NamePerformance { get; set; }
            public List<int> PlaceNumber { get; set; }
            public T Object { get; set; }
        }
        GetInfo()
        {
        }
        static public ResponseRequest<Theaterl> GetResponseRequest(Request request, ThSy database)
        {
            for (var theaterIndex = 0;
                theaterIndex < database.Theaters.Count; 
                theaterIndex++)
            {
                if (database.Theaters[theaterIndex].NameTheater == request.NameTheater)
                {
                    for (var performancesIndex = 0; 
                        performancesIndex < database.Theaters[theaterIndex].Performances.Count;
                        performancesIndex++)
                    {
                        if (database.Theaters[theaterIndex].Performances[performancesIndex].NamePerformance == request.NamePerformance)
                        {
                            return  new ResponseRequest<Theaterl>()
                            {
                                    Id = string.GetHashCode(request.Name + request.NameTheater + request.NamePerformance),
                                    NameTheater = request.NameTheater,
                                    NamePerformance = request.NamePerformance,
                                    PlaceNumber = request.PlaceNumber,
                                    Object = new Theaterl(new List<Performance>()
                                    {
                                        database.Theaters[theaterIndex].Performances[performancesIndex]
                                    })
                            };
                        }
                    }
                    throw new NotFoundPerformanceExaption("no found performance");
                }
            }
            throw new NotFoundTheaterExaption("no found theater");
        }
    }
}
