using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TravelAPI.Models;
using Moq.EntityFrameworkCore;
using Moq;
using Microsoft.Extensions.Logging;

namespace TravelAPI.Services.Tests
{
    [TestClass()]
    public class CountryRepoTests
    {
        [TestMethod()]
        public void GetCountriesTest()
        {
            //Arrange
            IList<CountryModel> countries = GenerateCountries();
            var travelAPIContextMock = new Mock<TravelAPIContext>();
            travelAPIContextMock.Setup(c => c.Countries).ReturnsDbSet(countries);

            var logger = Mock.Of<ILogger<CountryRepo>>();
            var countriesRepository = new CountryRepo(travelAPIContextMock.Object, logger);

            //Act 
            var theCountries = countriesRepository.GetCountries();

            //Assert
            Assert.AreEqual(1, theCountries.Result.Count);
        }

        [TestMethod()]
        public void GetCountryTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCountryTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetRightHandTrafficTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCountriesByLanguageTest()
        {
            Assert.Fail();
        }

        private static IList<CountryModel> GenerateCountries()
        {
            return new List<CountryModel>
            {
                new CountryModel
                {
                    CountryId = 1,
                    Name = "Wakanda",
                    CountryInfo = new CountryInfoModel
                    {
                        CountryInfoId = 1,
                        Population = 50000,
                        Governance = "Monarchy",
                        BNP = 500000000,
                        CapitalCity = "Birnin Zana",
                        Area = 50000,
                        TimeZone = "GMT + 3",
                        NationalDay = "31/3",
                        RightHandTraffic = true,
                        Language = "Wakandan/Yoruba/Hausa/English"
                    },
                    TravelRestriction = new TravelRestrictionModel
                    {
                        TravelRestrictionId = 1,
                        IsWorkTravelAllowed = false,
                        IsTourismAllowed = false,
                        IsImmigrationAllowed = false,
                        IsCitizenshipAllowed = true,
                        IsFamilyVisitAllowed = true,
                        IsVisaNeeded = true,
                        RiskLevel = 5
                    },
                    Cities = new List<CityModel>
                    {
                        new CityModel
                        {
                            CityId = 1,
                            Name = "Birnin Zana",
                            Country = new CountryModel(),
                            Attractions = new List<AttractionModel>
                            {
                                new AttractionModel
                                {
                                    AttractionId = 1,
                                    Name = "Nature",
                                    Location = "Outside all cities",
                                    IsChildFriendly = false,
                                    Information = "This is the information on Nature",
                                    Rating = 4,
                                    City = new CityModel()
                                },
                                new AttractionModel
                                {
                                    AttractionId = 2,
                                    Name = "The Golden City",
                                    Location = "Birnin Zana",
                                    IsChildFriendly = true,
                                    Information = "This is the information on Golden City",
                                    Rating = 5,
                                    City = new CityModel()
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}