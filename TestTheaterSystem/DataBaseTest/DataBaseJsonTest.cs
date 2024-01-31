using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DataBase.Converters;
using QueryService;

namespace TestTheaterSystem.DataBaseTest
{
    public class DataBaseJsonTest
    {
        [Fact]
        private void LoadTest()
        {
            string filePath = "test1.json";
            var converterJson = new ConverterJson();
            var request = new Request()
            {
                Name = "user",
                Request_ = "ticket booking",
                NamePerformance = "Bohemia",
                NameTheater = "Theater",
                PlaceNumber = new List<int>() { 1, 3, 10 }
            };

            converterJson.Load(filePath, request);
            var result = converterJson.Unload<Request>(filePath);

            Assert.Equal(request.Name, result.Name);
            Assert.Equal(request.Request_, result.Request_);
            Assert.Equal(request.NamePerformance, result.NamePerformance);
            Assert.Equal(request.NameTheater, result.NameTheater);
            Assert.Equal(request.PlaceNumber, result.PlaceNumber);
        }

        [Fact]
        private void NotFoundFilePathExaptionLoadTest()
        {
        }

            [Fact]
        private void UnloadTest()
        {
            string filePath = "test2.json";
            var converterJson = new ConverterJson();
            var request = new Request()
            {
                Name = "user",
                Request_ = "ticket booking",
                NamePerformance = "Bohemia",
                NameTheater = "Theater",
                PlaceNumber = new List<int>() { 1, 3, 10 }
            };

            converterJson.Load(filePath, request);
            var result = converterJson.Unload<Request>(filePath);

            Assert.Equal(request.Name, request.Name);
            Assert.Equal(request.Request_, request.Request_);
            Assert.Equal(request.NamePerformance, request.NamePerformance);
            Assert.Equal(request.NameTheater, request.NameTheater);
            Assert.Equal(request.PlaceNumber, request.PlaceNumber);
        }
    }
}
