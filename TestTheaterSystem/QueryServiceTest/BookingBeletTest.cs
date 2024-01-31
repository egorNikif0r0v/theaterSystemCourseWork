using QueryService;
using System;
using System.Collections.Generic;
using System.Text;
using Theater;
using Xunit;
using QueryService.Requests;
using QueryService.Exaption;

namespace TestTheaterSystem.QueryServiceTest
{
    public class BookingBeletTest
    {
        [Fact]
        public void ResponseTest()
        {
            
            var dataBase = new TheaterFuctory.JsonServer().GetTheaterSystem("Theater");
            var request = new Request()
            {
                Name = "user",
                Request_ = "ticket booking",
                NamePerformance = "Bohemia",
                NameTheater = "Theater",
                PlaceNumber = new List<int>() { 1, 3, 10 }
            };

            var response = BookingBelet.GetResponseRequest(request, dataBase);

            
            Assert.Equal(string.GetHashCode(request.Name + request.NameTheater + request.NamePerformance), response.Id);
            Assert.Equal(request.NameTheater, response.NameTheater);
            Assert.Equal(request.NamePerformance, response.NamePerformance);
            Assert.Equal(request.PlaceNumber, response.PlaceNumber);
        }
        [Fact]
        public void NotFoundTheaterExaptionTest()
        {
            var dataBase = new TheaterFuctory.JsonServer().GetTheaterSystem("Theater");

            var request = new Request()
            {
                Name = "user",
                Request_ = "ticket booking",
                NamePerformance = "Bohemia",
                NameTheater = "some name",
                PlaceNumber = new List<int>() { 1, 3, 10 }
            };

            Assert.Throws<NotFoundTheaterExaption > (() => BookingBelet.GetResponseRequest(request, dataBase));
        }

        [Fact]
        public void PlaceIsOcupiedExaptionTest()
        {
            var theaterFuctory = new TheaterFuctory.JsonServer();
            theaterFuctory
                .WithPlace(0, Place.Position.centralLodge, Place.Condition.occupied)
                .WithPerformance("some performance", Performance.Condition.expected)
                .WithTheater("some theater")
                .Build();

            var dataBase = theaterFuctory.TheaterSystem; 

            var request = new Request()
            {
                Name = "user",
                Request_ = "ticket booking",
                NamePerformance = "some performance",
                NameTheater = "some theater",
                PlaceNumber = new List<int>() { 1 }
            };

            Assert.Throws<PlaceIsOcupiedExaption>(() => BookingBelet.GetResponseRequest(request, dataBase));
        }

        [Fact]
        public void NotFoundPerformanceExaptionTest()
        {
            var dataBase = new TheaterFuctory.JsonServer().GetTheaterSystem("Theater");

            var request = new Request()
            {
                Name = "user",
                Request_ = "ticket booking",
                NamePerformance = "wrong performance",
                NameTheater = "Theater",
                PlaceNumber = new List<int>() { 1, 3, 10 }
            };

            Assert.Throws<NotFoundPerformanceExaption>(() => BookingBelet.GetResponseRequest(request, dataBase));
        }
    }
}
