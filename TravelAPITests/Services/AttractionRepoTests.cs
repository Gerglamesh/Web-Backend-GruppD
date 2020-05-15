using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using TravelAPI.Models;
using TravelAPI.Services;
using Moq;
using Moq.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace TravelAPI.Services.Tests
{
    [TestClass()]
    public class AttractionRepoTests
    {
        [TestMethod()]
        public void GetAttractionTest()
        {
            IList<AttractionModel> attractions = GenerateAttractions();
            var TravelAPIContextMock = new Mock<TravelAPIContext>();
            TravelAPIContextMock.Setup(e => e.Attractions).ReturnsDbSet(attractions);

            var logger = Mock.Of<ILogger<AttractionRepo>>();
            var attractionRepo = new AttractionRepo(TravelAPIContextMock.Object, logger);

            string attraction = "The Fun Thing";

            var theAttraction = attractionRepo.GetAttraction(attraction);

            Assert.Equals(1, theAttraction.Result.AttractionId);

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