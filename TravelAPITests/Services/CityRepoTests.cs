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
            Assert.Equal(2, TheCities.Count);
        }
        [Fact]
        public async void GetCityByNameTest()
        {
            //Arrange
            IList<CityModel> cities = GenerateCities();
            var travelAPIContextMock = new Mock<TravelAPIContext>();
            travelAPIContextMock.Setup(c => c.Cities).ReturnsDbSet(cities);

            var logger = Mock.Of<ILogger<CityRepo>>();
            var citiesRepository = new CityRepo(travelAPIContextMock.Object, logger);
            //Act
            var TheCity = await citiesRepository.GetCityByName("Gothenburg");

            //Assert
            Assert.Equal("Gothenburg", TheCity.Name);
        }

        [Fact]
        public async void GetCityByIdTest()
        {
            //Arrange
            IList<CityModel> cities = GenerateCities();
            var travelAPIContextMock = new Mock<TravelAPIContext>();
            travelAPIContextMock.Setup(c => c.Cities).ReturnsDbSet(cities);

            var logger = Mock.Of<ILogger<CityRepo>>();
            var citiesRepository = new CityRepo(travelAPIContextMock.Object, logger);
            //Act
            var TheCity = await citiesRepository.GetCityById(1);

            //Assert
            Assert.Equal(1, TheCity.CityId);
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
                },



                new CityModel
                {
                    CityId = 2,
                    Name = "Oslo",
                    Country = new CountryModel
                    {
                        CountryId = 2,
                        Name = "Norway",
                        CountryInfo = new CountryInfoModel
                        {
                            CountryInfoId = 2,
                            Population = 60000000,
                            Governance = "communism",
                            BNP = 100000,
                            CapitalCity = "Oslo",
                            Area = 10000,
                            TimeZone = "GMT+1",
                            NationalDay = "Oktober 27",
                            RightHandTraffic = false,
                            Language = "WeirdSwedish"
                        },
                        TravelRestriction = new TravelRestrictionModel
                        {
                            TravelRestrictionId = 2,
                            IsWorkTravelAllowed = false,
                            IsTourismAllowed = false,
                            IsImmigrationAllowed = false,
                            IsCitizenshipAllowed = true,
                            IsFamilyVisitAllowed = true,
                            IsVisaNeeded = true,
                            RiskLevel = 5
                        },
                    },
                    Attractions = new List<AttractionModel>
                    {
                        new AttractionModel
                        {
                            AttractionId = 2,
                            Name = "The Bar",
                            Location = "Oslo",
                            IsChildFriendly = false,
                            Information = "Contains alcohol",
                            Rating = 10
                        }
                    }
                }
            };
        }

    }
}