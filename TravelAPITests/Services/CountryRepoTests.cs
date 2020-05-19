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
                },
                new CountryModel
                {
                    CountryId = 3,
                    Name = "Serbia",
                    CountryInfo = new CountryInfoModel
                    {
                        CountryInfoId = 3,
                        Population = 80000,
                        Governance = "Parliamentary Republic",
                        CapitalCity = "Belgrad",
                        BNP = 7246,
                        Area = 88361,
                        TimeZone = "GMT+2",
                        NationalDay = "15/02",
                        Language = "Serbian",
                        RightHandTraffic = true
                    },
                    TravelRestriction = new TravelRestrictionModel
                    {
                        TravelRestrictionId = 3,
                        IsWorkTravelAllowed = false,
                        IsTourismAllowed = false,
                        IsImmigrationAllowed = false,
                        IsCitizenshipAllowed = false,
                        IsFamilyVisitAllowed = false,
                        IsVisaNeeded = true,
                        RiskLevel = 4
                    },
                    Cities = new List<CityModel>
                    {
                        new CityModel
                        {
                            CityId = 3,
                            Name = "Belgrade",
                            Population = 1397939,
                            Country = new CountryModel(),
                            Attractions = new List<AttractionModel>
                            {
                                new AttractionModel
                                {
                                    AttractionId = 4,
                                    Name = "Kalemegdan Fortress",
                                    Location = "Belgrad",
                                    Information = "Kalemegdan is the most popular park among Belgraders and for many tourists visiting Belgrade because of the park's numerous winding walking paths, shaded benches, picturesque fountains, statues, historical architecture and scenic river views (Sahat kula – the clock tower; closed in 2007 for the reconstruction, reopened in April 2014,[6] Zindan kapija – Zindan gate, etc). The former canal which was used for city supplying in the Middle Ages is completely covered by earth but the idea of recreating it resurfaced in the early 2000s. Belgrade Fortress is known for its kilometers-long tunnels, underground corridors and catacombs, which are still largely unexplored. In the true sense, fortress is today the green oasis in the Belgrade's urban area. ",
                                    IsChildFriendly = true,
                                    Rating = 5,
                                    CityId = 3
                                }                                
                            }
                        },
                        new CityModel
                        {
                            CityId = 4,
                            Name = "Novi Sad",
                            Population = 289128,
                            Country = new CountryModel(),
                            Attractions = new List<AttractionModel>
                            {
                                new AttractionModel
                                {
                                    AttractionId = 5,
                                    Name = "Petrovaradin Clock Tower",
                                    Location = "Novi Sad",
                                    Information = "THE CLOCK TOWER is at the upper town of the fortress. On this site, it used to be an older one which was demolished in 18th century. The radius of the clock is more than two metres long, the four clock faces are directed toward all four cardinal directions, numbers are in roman numerals and the main characteristics of this clock is that the longer hand tells the hours and shorter tells the minutes. This type of a clock needs daily winding up. On the top of the tower there are a vane and a compass. Near the clock tower is, so called, the long barrack i.e. two storey building from the second half of 18th century. At this building, in 1926 was the Aviation NCO school of Kingdom of Serbs, Croats and Slovenians. The bestknown pupil was Franjo Kluz, the aviation pioneer in WWII. One of the most prominent buildings of the upper town is the Leopold’s gate with baroque foreground and suspension bridge, but also with a coat of arms and a motto of the Habsburg monarchy ‘’Viribusunitis’’(by the united forces).",
                                    IsChildFriendly = true,
                                    Rating = 5,
                                    CityId = 4
                                }
                            }
                        },
                        new CityModel
                        {
                            CityId = 5,
                            Name = "Niš",
                            Population = 185987,
                            Country = new CountryModel(),
                            Attractions = new List<AttractionModel>
                            {
                                new AttractionModel
                                {
                                    AttractionId = 6,
                                    Name = "Grimace at the grisly Skull Tower",
                                    Location = "Niš",
                                    Information = "The Skull Tower was every bit as grim as the name suggests, and was constructed to warn the local Serbs against another rebellion. The tower was built in 1809 using the skulls of 952 fallen Serbian rebels, but less than 100 of the heads remain today.",
                                    IsChildFriendly = true,
                                    Rating = 4,
                                    CityId = 5
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}