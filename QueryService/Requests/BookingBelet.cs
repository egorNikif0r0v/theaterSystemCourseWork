using Theater;
using QueryService.Exaption;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QueryService.Requests
{
    public class BookingBelet : IRequest
    {
        public struct ResponseRequest : IResponseRequest
        {
            public int  Id { get; set; }
            public IResponseRequest.Action_ Action { get; set; }
            public string NameTheater { get; set; }
            public string NamePerformance { get; set; }
            public List<int> PlaceNumber { get; set; }
        }

        BookingBelet() 
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
                        PlaceNumber = request.PlaceNumber
                    };
                }
            }
            throw new NotFoundTheaterExaption("no found theater");
        }

        static private void ChangeCondition(Theaterl theater, Request request)
        {
            foreach (var perforamnce in theater.Performances)
            {
                if (perforamnce?.NamePerformance == request.NamePerformance)
                {
                    foreach (var item in request.PlaceNumber)
                    {
                        if (perforamnce.IsPlaceFree(perforamnce.Places[item - 1].Condition_))
                            perforamnce?.Places[item - 1]?.ChangeCondition(Place.Condition.occupied);
                        else
                            throw new PlaceIsOcupiedExaption("place is occupied");
                    }
                    perforamnce.TotalPlace -= request.PlaceNumber.Count;
                    return;
                }
            }
            throw new NotFoundPerformanceExaption("no found performance");
        }

        static async public Task<ResponseRequest> GetResponseRequestAsync(Request request, ThSy dataBase)
        {
            for (var _ = 0; _ < dataBase.Theaters.Count; _++)
            {
                if (request.NameTheater == dataBase.Theaters[_].NameTheater)
                {
                    await ChangeConditionAsync(dataBase.Theaters[_], request);
                    return new ResponseRequest()
                    {
                        Id = string.GetHashCode(request.Name + request.NameTheater + request.NamePerformance),
                        NameTheater = request.NameTheater,
                        NamePerformance = request.NamePerformance,
                        PlaceNumber = request.PlaceNumber
                    };
                }
            }
            throw new NotFoundTheaterExaption("no found theater");
        }

        static async private Task ChangeConditionAsync(Theaterl theater, Request request)
        {
            await Task.Run(() => { 
                foreach (var perforamnce in theater.Performances)
                {
                    if (perforamnce?.NamePerformance == request.NamePerformance)
                    {
                        foreach (var item in request.PlaceNumber)
                        {
                            if (perforamnce.IsPlaceFree(perforamnce.Places[item - 1].Condition_))
                                perforamnce?.Places[item - 1]?.ChangeCondition(Place.Condition.occupied);
                            else
                                throw new PlaceIsOcupiedExaption("place is occupied");
                        }
                        perforamnce.TotalPlace -= request.PlaceNumber.Count;
                        return;
                    }
                }
                throw new NotFoundPerformanceExaption("no found performance");
            });
        }

    }
}

