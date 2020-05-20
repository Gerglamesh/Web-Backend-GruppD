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
        [InlineData(true, 8)]
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
        [InlineData(3, 2)]
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
                },
                new AttractionModel
                {
                    AttractionId = 1,
                    Name = "Buddha Niches",
                    Location = "Bamiyan Valley, west of Kabul",
                    Information = "The empty niches of the Buddha statues dominate the Bamiyan valley. Carved in the 6th century, the two statues, standing 38m and 55m respectively, were the tallest standing statues of Buddha ever made.",
                    IsChildFriendly = true,
                    Rating = 4,
                    City = new CityModel
                    {
                        CityId = 2,
                        Name = "Kabul"
                    }                    
                },
                new AttractionModel
                {
                    AttractionId = 2,
                    Name = "Kabul Museum",
                    Location = "Kabul",
                    Information = "The Kabul Museum was once one of the greatest museums in the world. Its exhibits, ranging from Hellenistic gold coins to Buddhist statuary and Islamic bronzes, testified to Afghanistan’s location at the crossroads of Asia. After years of abuse during the civil war, help from the international community and the peerless dedication of its staff means the museum is slowly rising from the ashes. The museum opened in 1919, and was almost entirely stocked with items excavated in Afghanistan.",
                    IsChildFriendly = true,
                    Rating = 3,
                    City = new CityModel
                    {
                        CityId = 2,
                        Name = "Kabul"
                    }
                },
                new AttractionModel
                {
                    AttractionId = 3,
                    Name = "Blue Mosque",
                    Location = "Balkh",
                    Information = "The Sultan of the Seljuq dynasty, Ahmed Sanjar, built the first known shrine at this location. It was destroyed or hidden under earthen embankment during the invasion of Genghis Khan around 1220. In the 15th century, Timurid Sultan Husayn Bayqarah Mirza built the current Blue Mosque here. It is by far the most important landmark in Mazar-i-Sharif and it is believed that the name of city (Noble Shrine, Grave of Hazrat-i-Ali Sharif) originates from this shrine. ",
                    IsChildFriendly = true,
                    Rating = 4,
                    City = new CityModel
                    {
                        CityId = 3,
                        Name = "Balkh"
                    }
                },
                new AttractionModel
                {
                    AttractionId = 4,
                    Name = "Kalemegdan Fortress",
                    Location = "Belgrad",
                    Information = "Kalemegdan is the most popular park among Belgraders and for many tourists visiting Belgrade because of the park's numerous winding walking paths, shaded benches, picturesque fountains, statues, historical architecture and scenic river views (Sahat kula – the clock tower; closed in 2007 for the reconstruction, reopened in April 2014,[6] Zindan kapija – Zindan gate, etc). The former canal which was used for city supplying in the Middle Ages is completely covered by earth but the idea of recreating it resurfaced in the early 2000s. Belgrade Fortress is known for its kilometers-long tunnels, underground corridors and catacombs, which are still largely unexplored. In the true sense, fortress is today the green oasis in the Belgrade's urban area. ",
                    IsChildFriendly = true,
                    Rating = 5,
                    City = new CityModel
                    {
                        CityId = 3,
                        Name = "Belgrad"
                    }
                },
                new AttractionModel
                {
                    AttractionId = 5,
                    Name = "Petrovaradin Clock Tower",
                    Location = "Novi Sad",
                    Information = "THE CLOCK TOWER is at the upper town of the fortress. On this site, it used to be an older one which was demolished in 18th century. The radius of the clock is more than two metres long, the four clock faces are directed toward all four cardinal directions, numbers are in roman numerals and the main characteristics of this clock is that the longer hand tells the hours and shorter tells the minutes. This type of a clock needs daily winding up. On the top of the tower there are a vane and a compass. Near the clock tower is, so called, the long barrack i.e. two storey building from the second half of 18th century. At this building, in 1926 was the Aviation NCO school of Kingdom of Serbs, Croats and Slovenians. The bestknown pupil was Franjo Kluz, the aviation pioneer in WWII. One of the most prominent buildings of the upper town is the Leopold’s gate with baroque foreground and suspension bridge, but also with a coat of arms and a motto of the Habsburg monarchy ‘’Viribusunitis’’(by the united forces).",
                    IsChildFriendly = true,
                    Rating = 5,
                    City = new CityModel
                    {
                        CityId = 4,
                        Name = "Novi Sad"
                    }
                },
                new AttractionModel
                {
                    AttractionId = 6,
                    Name = "Grimace at the grisly Skull Tower",
                    Location = "Niš",
                    Information = "The Skull Tower was every bit as grim as the name suggests, and was constructed to warn the local Serbs against another rebellion. The tower was built in 1809 using the skulls of 952 fallen Serbian rebels, but less than 100 of the heads remain today.",
                    IsChildFriendly = true,
                    Rating = 4,
                    City = new CityModel
                    {
                        CityId = 5,
                        Name = "Niš"
                    }
                }
            };
        }
    }
}