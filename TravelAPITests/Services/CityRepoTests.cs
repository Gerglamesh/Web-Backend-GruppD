//using System.Collections.Generic;
//using TravelAPI.Models;
//using Moq.EntityFrameworkCore;
//using Moq;
//using Microsoft.Extensions.Logging;
//using Xunit;

//namespace TravelAPI.Services.Tests
//{
//    public class CityRepoTests
//    {
//        [Fact]
//        public async void GetCitiesTest()
//        {
//            //Arrange
//            IList<CityModel> cities = GenerateCities();
//            var travelAPIContextMock = new Mock<TravelAPIContext>();
//            travelAPIContextMock.Setup(c => c.Cities).ReturnsDbSet(cities);

//            var logger = Mock.Of<ILogger<CityRepo>>();
//            var citiesRepository = new CityRepo(travelAPIContextMock.Object, logger);
//            //Act
//            var theCities = await citiesRepository.GetCities();
//            //Assert
//            Assert.Equal(5, theCities.Count);
//        }

//        [Fact]
//        public async void GetCityByNameTest()
//        {
//            //Arrange
//            IList<CityModel> cities = GenerateCities();
//            var travelAPIContextMock = new Mock<TravelAPIContext>();
//            travelAPIContextMock.Setup(c => c.Cities).ReturnsDbSet(cities);

//            var logger = Mock.Of<ILogger<CityRepo>>();
//            var citiesRepository = new CityRepo(travelAPIContextMock.Object, logger);
//            //Act
//            var theCity = await citiesRepository.GetCityByName("Gothenburg");

//            //Assert
//            Assert.Equal("Gothenburg", theCity.Name);
//        }

//        [Fact]
//        public async void GetCityByIdTest()
//        {
//            //Arrange
//            IList<CityModel> cities = GenerateCities();
//            var travelAPIContextMock = new Mock<TravelAPIContext>();
//            travelAPIContextMock.Setup(c => c.Cities).ReturnsDbSet(cities);

//            var logger = Mock.Of<ILogger<CityRepo>>();
//            var citiesRepository = new CityRepo(travelAPIContextMock.Object, logger);
//            //Act
//            var theCity = await citiesRepository.GetCityById(1);

//            //Assert
//            Assert.Equal(1, theCity.CityId);
//        }

//        [Theory]
//        [InlineData("Gothenburg", 700000)]
//        [InlineData("Oslo", 5000000)]
//        public async void GetCityPopulationByName(string inlineName, int expected)
//        {
//            //Arrange
//            IList<CityModel> cities = GenerateCities();
//            var travelAPIContextMock = new Mock<TravelAPIContext>();
//            travelAPIContextMock.Setup(c => c.Cities).ReturnsDbSet(cities);

//            var logger = Mock.Of<ILogger<CityRepo>>();
//            var citiesRepository = new CityRepo(travelAPIContextMock.Object, logger);

//            //Act 
//            var theCity = await citiesRepository.GetCityByName(inlineName);

//            //Assert
//            Assert.Equal(expected, theCity.Population);
//        }

//        private static IList<CityModel> GenerateCities()
//        {
//            return new List<CityModel>
//            {
//                new CityModel
//                {
//                    CityId = 1,
//                    Name = "Gothenburg",
//                    Population = 700000,
//                    Country = new CountryModel
//                    {
//                        CountryId = 1,
//                        Name = "Sweden",
//                        CountryInfo = new CountryInfoModel
//                        {
//                            CountryInfoId = 1,
//                            Population = 10000000,
//                            Governance = "Republic",
//                            BNP = 500000,
//                            CapitalCity = "Stockholm",
//                            Area = 30000,
//                            TimeZone = "GMT+1",
//                            NationalDay = "Oktober 12",
//                            RightHandTraffic = true,
//                            Language = "Swedish"
//                        },
//                        TravelRestriction = new TravelRestrictionModel
//                        {
//                            TravelRestrictionId = 1,
//                            IsWorkTravelAllowed = true,
//                            IsTourismAllowed = true,
//                            IsImmigrationAllowed = true,
//                            IsCitizenshipAllowed = false,
//                            IsFamilyVisitAllowed = false,
//                            IsVisaNeeded = false,
//                            RiskLevel = 2
//                        },
//                    },
//                    Attractions = new List<AttractionModel>
//                    {
//                        new AttractionModel
//                        {
//                            AttractionId = 1,
//                            Name = "Liseberg",
//                            Location = "Gothenburg",
//                            IsChildFriendly = true,
//                            Information = "Rollercoasters",
//                            Rating = 8
//                        }
//                    }
//                },
//                new CityModel
//                {
//                    CityId = 2,
//                    Name = "Oslo",
//                    Population = 5000000,
//                    Country = new CountryModel
//                    {
//                        CountryId = 2,
//                        Name = "Norway",
//                        CountryInfo = new CountryInfoModel
//                        {
//                            CountryInfoId = 2,
//                            Population = 60000000,
//                            Governance = "communism",
//                            BNP = 100000,
//                            CapitalCity = "Oslo",
//                            Area = 10000,
//                            TimeZone = "GMT+1",
//                            NationalDay = "Oktober 27",
//                            RightHandTraffic = false,
//                            Language = "WeirdSwedish"
//                        },
//                        TravelRestriction = new TravelRestrictionModel
//                        {
//                            TravelRestrictionId = 2,
//                            IsWorkTravelAllowed = false,
//                            IsTourismAllowed = false,
//                            IsImmigrationAllowed = false,
//                            IsCitizenshipAllowed = true,
//                            IsFamilyVisitAllowed = true,
//                            IsVisaNeeded = true,
//                            RiskLevel = 5
//                        },
//                    },
//                    Attractions = new List<AttractionModel>
//                    {
//                        new AttractionModel
//                        {
//                            AttractionId = 2,
//                            Name = "The Bar",
//                            Location = "Oslo",
//                            IsChildFriendly = false,
//                            Information = "Contains alcohol",
//                            Rating = 10
//                        }
//                    }
//                },
//                new CityModel
//                {
//                    CityId = 3,
//                    Name = "Belgrade",
//                    Population = 1397939,
//                    Country = new CountryModel
//                    {
//                        CountryId = 3,
//                        Name = "Serbia",
//                        CountryInfo = new CountryInfoModel
//                        {
//                            CountryInfoId = 3,
//                            Population = 80000,
//                            Governance = "Parliamentary Republic",
//                            CapitalCity = "Belgrad",
//                            BNP = 7246,
//                            Area = 88361,
//                            TimeZone = "GMT+2",
//                            NationalDay = "15/02",
//                            Language = "Serbian",
//                            RightHandTraffic = true
//                        },
//                        TravelRestriction = new TravelRestrictionModel
//                        {
//                            TravelRestrictionId = 3,
//                            IsWorkTravelAllowed = false,
//                            IsTourismAllowed = false,
//                            IsImmigrationAllowed = false,
//                            IsCitizenshipAllowed = false,
//                            IsFamilyVisitAllowed = false,
//                            IsVisaNeeded = true,
//                            RiskLevel = 4
//                        },
//                    },
//                    Attractions = new List<AttractionModel>
//                    {
//                        new AttractionModel
//                        {
//                            AttractionId = 4,
//                            Name = "Kalemegdan Fortress",
//                            Location = "Belgrad",
//                            Information = "Kalemegdan is the most popular park among Belgraders and for many tourists visiting Belgrade because of the park's numerous winding walking paths, shaded benches, picturesque fountains, statues, historical architecture and scenic river views (Sahat kula – the clock tower; closed in 2007 for the reconstruction, reopened in April 2014,[6] Zindan kapija – Zindan gate, etc). The former canal which was used for city supplying in the Middle Ages is completely covered by earth but the idea of recreating it resurfaced in the early 2000s. Belgrade Fortress is known for its kilometers-long tunnels, underground corridors and catacombs, which are still largely unexplored. In the true sense, fortress is today the green oasis in the Belgrade's urban area. ",
//                            IsChildFriendly = true,
//                            Rating = 5,
//                            CityId = 3,
//                        }
//                    }
//                },

//                new CityModel
//                {
//                    CityId = 4,
//                    Name = "Novi Sad",
//                    Population = 289128,
//                    Country = new CountryModel
//                    {
//                        CountryId = 3,
//                        Name = "Serbia",
//                        CountryInfo = new CountryInfoModel
//                        {
//                            CountryInfoId = 3,
//                            Population = 80000,
//                            Governance = "Parliamentary Republic",
//                            CapitalCity = "Belgrad",
//                            BNP = 7246,
//                            Area = 88361,
//                            TimeZone = "GMT+2",
//                            NationalDay = "15/02",
//                            Language = "Serbian",
//                            RightHandTraffic = true
//                        },
//                        TravelRestriction = new TravelRestrictionModel
//                        {
//                            TravelRestrictionId = 3,
//                            IsWorkTravelAllowed = false,
//                            IsTourismAllowed = false,
//                            IsImmigrationAllowed = false,
//                            IsCitizenshipAllowed = false,
//                            IsFamilyVisitAllowed = false,
//                            IsVisaNeeded = true,
//                            RiskLevel = 4
//                        },
//                    },
//                    Attractions = new List<AttractionModel>
//                    {
//                        new AttractionModel
//                        {
//                            AttractionId = 5,
//                            Name = "Petrovaradin Clock Tower",
//                            Location = "Novi Sad",
//                            Information = "THE CLOCK TOWER is at the upper town of the fortress. On this site, it used to be an older one which was demolished in 18th century. The radius of the clock is more than two metres long, the four clock faces are directed toward all four cardinal directions, numbers are in roman numerals and the main characteristics of this clock is that the longer hand tells the hours and shorter tells the minutes. This type of a clock needs daily winding up. On the top of the tower there are a vane and a compass. Near the clock tower is, so called, the long barrack i.e. two storey building from the second half of 18th century. At this building, in 1926 was the Aviation NCO school of Kingdom of Serbs, Croats and Slovenians. The bestknown pupil was Franjo Kluz, the aviation pioneer in WWII. One of the most prominent buildings of the upper town is the Leopold’s gate with baroque foreground and suspension bridge, but also with a coat of arms and a motto of the Habsburg monarchy ‘’Viribusunitis’’(by the united forces).",
//                            IsChildFriendly = true,
//                            Rating = 5,
//                            CityId = 4
//                        }
//                    }
//                },

//                new CityModel
//                {
//                    CityId = 5,
//                    Name = "Niš",
//                    Population = 185987,
//                    Country = new CountryModel
//                    {
//                        CountryId = 3,
//                        Name = "Serbia",
//                        CountryInfo = new CountryInfoModel
//                        {
//                            CountryInfoId = 3,
//                            Population = 80000,
//                            Governance = "Parliamentary Republic",
//                            CapitalCity = "Belgrad",
//                            BNP = 7246,
//                            Area = 88361,
//                            TimeZone = "GMT+2",
//                            NationalDay = "15/02",
//                            Language = "Serbian",
//                            RightHandTraffic = true
//                        },
//                        TravelRestriction = new TravelRestrictionModel
//                        {
//                            TravelRestrictionId = 3,
//                            IsWorkTravelAllowed = false,
//                            IsTourismAllowed = false,
//                            IsImmigrationAllowed = false,
//                            IsCitizenshipAllowed = false,
//                            IsFamilyVisitAllowed = false,
//                            IsVisaNeeded = true,
//                            RiskLevel = 4
//                        },
//                    },
//                    Attractions = new List<AttractionModel>
//                    {
//                        new AttractionModel
//                        {
//                            AttractionId = 6,
//                            Name = "Grimace at the grisly Skull Tower",
//                            Location = "Niš",
//                            Information = "The Skull Tower was every bit as grim as the name suggests, and was constructed to warn the local Serbs against another rebellion. The tower was built in 1809 using the skulls of 952 fallen Serbian rebels, but less than 100 of the heads remain today.",
//                            IsChildFriendly = true,
//                            Rating = 4,
//                            CityId = 5
//                        }
//                    }
//                }                
//            };
//        }
//    }
//}