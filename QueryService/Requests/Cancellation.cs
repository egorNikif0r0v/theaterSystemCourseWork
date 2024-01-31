using QueryService.Exaption;
using System;
using System.Collections.Generic;
using Theater;

namespace QueryService.Requests
{
    public class Cancellation : IRequest
    {
        public struct ResponseRequest : IResponseRequest
        {
            public int Id { get; set; }
            public IResponseRequest.Action_ Action { get; set; }
            public string NameTheater { get; set; }
            public string NamePerformance { get; set; }
            public List<int> PlaceNumber { get; set; }
        }
        Cancellation() 
        {
        }
        static public ResponseRequest GetResponseRequest(Request request, ThSy dataBase)
        {
            

            for (var _ = 0; _ < dataBase.Theaters.Count; _++)
            {
                if (request.NameTheater == dataBase.Theaters[_].NameTheater)
                {
                    ChangeCondition(dataBase.Theaters[_], request);
                    return new ResponseRequest()
                    {
                        Id = string.GetHashCode(request.Name + request.NameTheater + request.NamePerformance),
                        NameTheater = request.NameTheater,
                        NamePerformance = request.NamePerformance,
                        PlaceNumber = request.PlaceNumber,
                    };
                }
            }
            throw new NotFoundTheaterExaption("no found theater");
        }

        static private void ChangeCondition(Theaterl theater, Request request)
        {
            foreach (var perforamnce in theater?.Performances)
            {
                if (perforamnce?.NamePerformance == request.NamePerformance)
                {
                    foreach (var item in request.PlaceNumber)
                    {
                        perforamnce?.Places[item - 1]?.ChangeCondition(Place.Condition.free);
                    }
                    perforamnce.TotalPlace -= request.PlaceNumber.Count;
                    return;
                }
            }
            throw new NotFoundPerformanceExaption("no found performance");
        }
    }
}
