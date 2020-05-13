using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TravelAPI.Models;

namespace TravelAPI.Services.Tests
{
    [TestClass()]
    public class CountryRepoTests
    {
        [TestMethod()]
        public void GetCountriesTest()
        {
            //Arrange
            IList<CountryModel> countries = GenerateEvents();
            //Act 

            //Assert
            Assert.Fail();
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

        private static IList<CountryModel> GenerateEvents()
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

                    }
                }
            };
        }
    }
}