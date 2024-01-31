using Xunit;
using Theater;
using System.Collections.Generic;

namespace TestTheaterSystem.TheaterLibTest
{
    public class TheaterTest
    {
        [Fact]
        public void ChangeConditionTest()
        {
            var place = new Place()
            {
                Condition_ = "free",
            };

            place.ChangeCondition(Place.Condition.occupied);

            Assert.Equal("occupied", place.Condition_);
        }

        [Fact]
        public void IsPlaceFreeTest()
        {
            var performance = new Performance()
            {
                Places = new List<Place>
                {
                    new Place() { Condition_ = "free" }
                }
            };

            var isPlaceFree = performance.IsPlaceFree(performance.Places[0].Condition_);

            Assert.True(isPlaceFree);
        }

        [Fact]
        public void IsNotPerformanceCompletedTest()
        {
            var theater = new Theaterl()
            {
                Performances = new List<Performance>()
                { 
                    new Performance() { Condition_ = "expected" }
                }
            };

            var isNotPerformanceCompleted = theater.IsNotPerformanceCompleted(theater.Performances[0].Condition_);

            Assert.True(isNotPerformanceCompleted);
        }
    }
}
