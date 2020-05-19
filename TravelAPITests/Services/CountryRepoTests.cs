using System.Collections.Generic;
using TravelAPI.Models;
using Moq.EntityFrameworkCore;
using Moq;
using Microsoft.Extensions.Logging;
using Xunit;

namespace TravelAPI.Services.Tests
{
    public class CountryRepoTests
    {
        [Fact]
        public async void GetCountriesTest_CheckIfReturnedListContains2Objects()
        {
            //Arrange
            IList<CountryModel> countries = GenerateCountries();
            var travelAPIContextMock = new Mock<TravelAPIContext>();
            travelAPIContextMock.Setup(c => c.Countries).ReturnsDbSet(countries);

            var logger = Mock.Of<ILogger<CountryRepo>>();
            var countriesRepository = new CountryRepo(travelAPIContextMock.Object, logger);

            //Act 
            var theCountries = await countriesRepository.GetCountries();

            //Assert
            Assert.Equal(2, theCountries.Count);
        }

        [Theory]
        [InlineData(1, "Wakanda")]
        [InlineData(2, "Långtbortistan")]
        public async void GetCountryByIdTest_CheckIfReturnedObjectContainsCorrectName(int inlineInt, string expected)
        {
            //Arrange
            IList<CountryModel> countries = GenerateCountries();
            var travelAPIContextMock = new Mock<TravelAPIContext>();
            travelAPIContextMock.Setup(c => c.Countries).ReturnsDbSet(countries);

            var logger = Mock.Of<ILogger<CountryRepo>>();
            var countriesRepository = new CountryRepo(travelAPIContextMock.Object, logger);

            //Act 
            var theCountry = await countriesRepository.GetCountry(inlineInt);

            //Assert
            Assert.Equal(expected, theCountry.Name);
        }

        [Theory]
        [InlineData("Wakanda", "Wakanda")]
        [InlineData("Långtbortistan", "Långtbortistan")]
        public async void GetCountryByNameTest(string inlineName, string expected)
        {
            //Arrange
            IList<CountryModel> countries = GenerateCountries();
            var travelAPIContextMock = new Mock<TravelAPIContext>();
            travelAPIContextMock.Setup(c => c.Countries).ReturnsDbSet(countries);

            var logger = Mock.Of<ILogger<CountryRepo>>();
            var countriesRepository = new CountryRepo(travelAPIContextMock.Object, logger);

            //Act 
            var theCountry = await countriesRepository.GetCountry(inlineName);

            //Assert
            Assert.Equal(expected, theCountry.Name);
        }

        [Theory]
        [InlineData(true, 2)]
        public async void GetRightHandTrafficTest(bool inlineBool, int expected)
        {

            //Arrange
            IList<CountryModel> countries = GenerateCountries();
            var travelAPIContextMock = new Mock<TravelAPIContext>();
            travelAPIContextMock.Setup(c => c.Countries).ReturnsDbSet(countries);

            var logger = Mock.Of<ILogger<CountryRepo>>();
            var countriesRepository = new CountryRepo(travelAPIContextMock.Object, logger);

            //Act 
            var theCountries = await countriesRepository.GetRightHandTraffic(inlineBool);

            //Assert
            Assert.Equal(expected, theCountries.Count);

        }

        [Theory]
        [InlineData("English", 2)]
        [InlineData("Swenglish", 1)]
        public async void GetCountriesByLanguageTest_ReturnListOfCountriesSpeakingCertainLanguage(string inlineLanguage, int expected)
        {
            //Arrange
            IList<CountryModel> countries = GenerateCountries();
            var travelAPIContextMock = new Mock<TravelAPIContext>();
            travelAPIContextMock.Setup(c => c.Countries).ReturnsDbSet(countries);

            var logger = Mock.Of<ILogger<CountryRepo>>();
            var countriesRepository = new CountryRepo(travelAPIContextMock.Object, logger);

            //Act 
            var theCountries = await countriesRepository.GetCountriesByLanguage(inlineLanguage);

            //Assert
            Assert.Equal(expected, theCountries.Count);
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
                },

                new CountryModel
                {
                    CountryId = 2,
                    Name = "Långtbortistan",
                    CountryInfo = new CountryInfoModel
                    {
                        CountryInfoId = 2,
                        Population = 10000,
                        Governance = "Constitutional matriarchy",
                        BNP = 992384001,
                        CapitalCity = "Storstan",
                        Area = 100000,
                        TimeZone = "GMT + 78",
                        NationalDay = "5/1",
                        RightHandTraffic = true,
                        Language = "English/Swenglish/Swedish"
                    },
                    TravelRestriction = new TravelRestrictionModel
                    {
                        TravelRestrictionId = 2,
                        IsWorkTravelAllowed = true,
                        IsTourismAllowed = true,
                        IsImmigrationAllowed = true,
                        IsCitizenshipAllowed = true,
                        IsFamilyVisitAllowed = true,
                        IsVisaNeeded = false,
                        RiskLevel = 0
                    },
                    Cities = new List<CityModel>
                    {
                        new CityModel
                        {
                            CityId = 2,
                            Name = "Storstan",
                            Country = new CountryModel(),
                            Attractions = new List<AttractionModel>
                            {
                                new AttractionModel
                                {
                                    AttractionId = 3,
                                    Name = "Architecture",
                                    Location = "Storstan old district",
                                    IsChildFriendly = true,
                                    Information = "This is the information on architecture",
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