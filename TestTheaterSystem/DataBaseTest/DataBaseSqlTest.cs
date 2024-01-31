using DataBase;
using DataBase.Converters;
using QueryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theater;
using Xunit;

namespace TestTheaterSystem.DataBaseTest
{
    [Collection("Sequential")]
    public class DataBaseSqlTest
    {

        static public Place place = new Place()
        {
            Condition_ = "cacel",
            Number = 1,
            Position_ = "high",
            Cost = 1000,
            PerformanceId = 1,
            Performance = performance,
        };

        static public Address address = new Address()
        {
            City = "Novosibirsk",
            District = "Railway",
            PostalCode = "343435",
            House = 43,
            Theater = theater,
            TheaterId = 1,
        };

        static public Performance performance = new Performance()
        {
            NamePerformance = "Gore ot uma",
            TheaterId = 1,

            TotalPlace = 50,
            Condition_ = "begining",
            BeginningDate = "10",
            Theater = theater,
            Places = new List<Place>() { place },
        };

        static public Theaterl theater = new Theaterl()
        {
            NameTheater = "some teheater",
            PhoneNumber = "+79132368018",
            ThSy = thsy,
            ThSyId = 1,
            address = address,
            Performances = new List<Performance> { performance }
        };

        static public ThSy thsy = new ThSy()
        {
            Name = "thsy",
            Theaters = new List<Theaterl> { theater }
        };


        [Fact]
        private void LoadTheaterChainTest()
        {

            var nameTheater = theater.NameTheater;

            DBControllerSql.LoadTheaterCHain(thsy, "DbTest");

            var result = DBControllerSql.UnloadTheater(nameTheater, "DbTest");

            Assert.Equal(result.NameTheater, nameTheater);
        }

        [Fact]
        private void AddPerfromaceTest()
        {

            var context = new Context("DbTest");
            var sqlFuctory = new TheaterFuctory.SqlServer(context);
            var performanceName = "SomePerformance";
            sqlFuctory
                .WithTheaterChain(thsy)
                .WhithTheater(theater)
                .WhithAdress(address)
                .WhithPerformance(performance)
                .WhithPlace(place)
                .Build();

            DBControllerSql.AddPerformance(new Performance()
            { 
                NamePerformance = performanceName,
                Theater = theater
            }, "DbTest");

            var result  =  DBControllerSql.UnloadPerformance(performanceName, theater, "DbTest");

            DBControllerSql.ClearDB("DbTest");
            Assert.Equal(result.NamePerformance, performanceName);
        }


        


    }
}
