using System.Collections.Generic;
using TravelAPI.Models;
using Moq.EntityFrameworkCore;
using Moq;
using Microsoft.Extensions.Logging;
using Xunit;

namespace TravelAPI.Services.Tests
{
    public class CityRepoTests
    {
        [Fact]
        public async void GetCitiesTest()
        {
            //Arrange
            IList<CityModel> cities = GenerateCities();
            var travelAPIContextMock = new Mock<TravelAPIContext>();
            travelAPIContextMock.Setup(c => c.Cities).ReturnsDbSet(cities);

            var logger = Mock.Of<ILogger<CityRepo>>();
            var citiesRepository = new CityRepo(travelAPIContextMock.Object, logger);
            //Act
            var TheCities = await citiesRepository.GetCities();
            //Assert
            Assert.Equal(1, TheCities.Count);
        }
        private static IList<CityModel> GenerateCities()
        {
            return new List<CityModel>
            {
                new CityModel
                {
                    CityId = 1,
                    Name = "Gothenburg",
                    Country = new CountryModel
                    {
                        CountryId = 1,
                        Name = "Sweden",
                        CountryInfo = new CountryInfoModel
                        {
                            CountryInfoId = 1,
                            Population = 10000000,
                            Governance = "Republic",
                            BNP = 500000,
                            CapitalCity = "Stockholm",
                            Area = 30000,
                            TimeZone = "GMT+1",
                            NationalDay = "Oktober 12",
                            RightHandTraffic = true,
                            Language = "Swedish"
                        },
                        TravelRestriction = new TravelRestrictionModel
                        {
                            TravelRestrictionId = 1,
                            IsWorkTravelAllowed = true,
                            IsTourismAllowed = true,
                            IsImmigrationAllowed = true,
                            IsCitizenshipAllowed = false,
                            IsFamilyVisitAllowed = false,
                            IsVisaNeeded = false,
                            RiskLevel = 2
                        },
                    },
                    Attractions = new List<AttractionModel>
                    { 
                        new AttractionModel
                        {
                            AttractionId = 1,
                            Name = "Liseberg",
                            Location = "Gothenburg",
                            IsChildFriendly = true,
                            Information = "Rollercosters",
                            Rating = 8
                        }
                    }


                }

            };
        }
    }
}