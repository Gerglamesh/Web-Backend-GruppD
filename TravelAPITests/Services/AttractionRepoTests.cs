using System.Collections.Generic;
using TravelAPI.Models;
using Moq;
using Moq.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Xunit;

namespace TravelAPI.Services.Tests
{
    public class AttractionRepoTests
    {
        [Fact]
        public void GetAttractionTest()
        {
            IList<AttractionModel> attractions = GenerateAttractions();
            var TravelAPIContextMock = new Mock<TravelAPIContext>();
            TravelAPIContextMock.Setup(e => e.Attractions).ReturnsDbSet(attractions);

            var logger = Mock.Of<ILogger<AttractionRepo>>();
            var attractionRepo = new AttractionRepo(TravelAPIContextMock.Object, logger);

            string attraction = "The Fun Thing";

            var theAttraction = attractionRepo.GetAttraction(attraction);

            Assert.Equal(1, theAttraction.Result.AttractionId);

        }

        [Theory]
        [InlineData(true, 1)]
        [InlineData(false, 1)]
        public async void GetIschildfriendlyTest(bool inlineBool, int expected)
        {
            IList<AttractionModel> attractions = GenerateAttractions();
            var TravelAPIContextMock = new Mock<TravelAPIContext>();
            TravelAPIContextMock.Setup(e => e.Attractions).ReturnsDbSet(attractions);

            var logger = Mock.Of<ILogger<AttractionRepo>>();
            var attractionRepo = new AttractionRepo(TravelAPIContextMock.Object, logger);
            //Act 
            var theAttractions = await attractionRepo.GetIschildfriendly(inlineBool);
            //Assert
            Assert.Equal(expected, theAttractions.Count);
        }

        [Theory]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        public async void GetRatingTest(int inlineNum, int expected)
        {
            //Arrange
            IList<AttractionModel> attractions = GenerateAttractions();
            var TravelAPIContextMock = new Mock<TravelAPIContext>();
            TravelAPIContextMock.Setup(e => e.Attractions).ReturnsDbSet(attractions);

            var logger = Mock.Of<ILogger<AttractionRepo>>();
            var attractionRepo = new AttractionRepo(TravelAPIContextMock.Object, logger);
            //Act 
            var theAttractions = await attractionRepo.GetRating(inlineNum);
            //Assert
            Assert.Equal(expected, theAttractions.Count);

        }

        private static IList<AttractionModel> GenerateAttractions()
        {
            return new List<AttractionModel>
            {
                new AttractionModel
                {
                    AttractionId= 1,
                    Name = "The Fun Thing",
                    Location = "hollywud",
                    IsChildFriendly = true,
                    Information = "yes yes yes",
                    Rating = 4,
                    City= new CityModel
                    {
                        CityId = 1,
                        Name = "Någonting",
                    }
                }

            };
        }
    }
}