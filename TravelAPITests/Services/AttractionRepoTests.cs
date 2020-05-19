using TravelAPI.Services;
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
        [Theory]
        [InlineData(true, 3)]
        [InlineData(false, 3)]
        public async void GetAttractionsTest(bool inlineBool, int expected)
        {
            //Arrange
            IList<AttractionModel> attractions = GenerateAttractions();
            var TravelAPIContextMock = new Mock<TravelAPIContext>();
            TravelAPIContextMock.Setup(e => e.Attractions).ReturnsDbSet(attractions);

            var logger = Mock.Of<ILogger<AttractionRepo>>();
            var attractionRepo = new AttractionRepo(TravelAPIContextMock.Object, logger);

            //Act
            var theAttractions = await attractionRepo.GetAttractions(inlineBool);

            //Assert
            Assert.Equal(expected, theAttractions.Count);
        }

        [Fact]
        public async void GetAttractionTest()
        {
            IList<AttractionModel> attractions = GenerateAttractions();
            var TravelAPIContextMock = new Mock<TravelAPIContext>();
            TravelAPIContextMock.Setup(e => e.Attractions).ReturnsDbSet(attractions);

            var logger = Mock.Of<ILogger<AttractionRepo>>();
            var attractionRepo = new AttractionRepo(TravelAPIContextMock.Object, logger);
            //Act 
            string attraction = "The Fun Thing";

            var theAttraction = await attractionRepo.GetAttraction(attraction);
            //Assert
            Assert.Equal(1, theAttraction.AttractionId);
        }

        [Theory]
        [InlineData(true, 2)]
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
                },
                new AttractionModel
                {
                    AttractionId= 2,
                    Name = "The danger thing ",
                    Location = "home",
                    IsChildFriendly = false,
                    Information = "no no no ",
                    Rating = 2,
                    City= new CityModel
                    {
                        CityId = 1,
                        Name = "Någonting",
                    }
                },
                new AttractionModel
                {
                    AttractionId= 3,
                    Name = "balder",
                    Location = "korsvägen",
                    IsChildFriendly = true,
                    Information = "ingen info",
                    Rating = 3,
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