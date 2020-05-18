using EngineClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Controller;
using TravelAPI.Models;

namespace TravelAPI
{
    public class TravelAPIContext : DbContext
    {
        //TODO: Do we need to change our setup to take advantage of this? 
        //We have another solution going right now (See line 32)
        private readonly IConfiguration _travelConfig;

        public TravelAPIContext() {}

        public TravelAPIContext (IConfiguration config, DbContextOptions options) : base(options)
        {
            _travelConfig = config;
        }

        public virtual DbSet<CountryModel> Countries { get; set; }
        public virtual DbSet<CountryInfoModel> CountryInfo { get; set; }
        public virtual DbSet<AttractionModel> Attractions { get; set; }
        public virtual DbSet<CityModel> Cities { get; set; }
        public virtual DbSet<TravelRestrictionModel> TravelRestrictions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionSetup.GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryModel>()
            .HasData(new
            {
                CountryId = 1,
                Name = "Afghanistan",
                CountryInfoId = 1,
                TravelRestrictionId = 1
            },
             new
            {
                CountryId = 2,
                Name = "Serbia",
                CountryInfoId = 2,
                TravelRestrictionId = 2
            },

             new
            {
                CountryId = 3,
                Name = "Japan",
                CountryInfoId = 3,
                TravelRestrictionId = 3
            },

            new
            {
                CountryId = 4,
                Name = "Uganda",
                CountryInfoId = 4,
                TravelRestrictionId = 4
            },

            new
            {
                CountryId = 5,
                Name = "Barbados",
                CountryInfoId = 5,
                TravelRestrictionId = 5
            },

            new
            {
                CountryId = 6,
                Name = "Canada",
                CountryInfoId = 6,
                TravelRestrictionId = 6
            },

            new
            {
                CountryId = 7,
                Name = "Brazil",
                CountryInfoId = 7,
                TravelRestrictionId = 7
            },

            new
            {
                CountryId = 8,
                Name = "New Zealand",
                CountryInfoId = 8,
                TravelRestrictionId = 8
            });

            modelBuilder.Entity<TravelRestrictionModel>()
            .HasData(new
            {
                TravelRestrictionId = 1,
                IsWorkTravelAllowed = true,
                IsTourismAllowed = false,
                IsImmigrationAllowed = true,
                IsCitizenshipAllowed = true,
                IsFamilyVisitAllowed = true,
                IsVisaNeeded = true,
                RiskLevel = 4
            });

            modelBuilder.Entity<CountryInfoModel>()
            .HasData(new
                {
                    CountryInfoId = 1,
                    Population = 50000,
                    Governance = "Islamic Republic",
                    CapitalCity = "Kabul",
                    BNP = 19360,
                    Area = 65200,
                    TimeZone = "GMT+4:30",
                    NationalDay = "19/08",
                    Language = "Dari/Pashtu/Iranian",
                    RightHandTraffic = true
                },

            new
            {
                CountryInfoId = 2,
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

            new
            {
                CountryInfoId = 3,
                Population = 126244,
                Governance = "Constitutional Monarch",
                CapitalCity = "Tokyo",
                BNP = 39289,
                Area = 377918,
                TimeZone = "GMT+9",
                NationalDay = "11/02",
                Language = "Japanese/Ryukyuan/Ainu/Orok/Evenki/Nivkh",
                RightHandTraffic = false
            },

            new
            {
                CountryInfoId = 4,
                Population = 4272,
                Governance = "Democratic State",
                CapitalCity = "Kampala",
                BNP = 2746,
                Area = 241037,
                TimeZone = "GMT+3",
                NationalDay = "18/05",
                Language = "Bantu/Nilotic/Central Sudanic",
                RightHandTraffic = false
            },

            new
            {
                CountryInfoId = 5,
                Population = 286641,
                Governance = "Monarch",
                CapitalCity = "Bridgetown",
                BNP = 5145,
                Area = 431,
                TimeZone = "GMT-4",
                NationalDay = "30/11",
                Language = "English/Bajan Dialect",
                RightHandTraffic = false
            },

            new
            {
                CountryInfoId = 6,
                Population = 3759,
                Governance = "Constitutional Monarchy",
                CapitalCity = "Ottawa",
                BNP = 1713,
                Area = 9985000,
                TimeZone = "GMT-4",
                NationalDay = "01/07",
                Language = "French/English",
                RightHandTraffic = true
            },

           new
            {
                CountryInfoId = 7,
                Population = 2095,
                Governance = "Democratic Federal Republic",
                CapitalCity = "Brasília",
                BNP = 1869,
                Area = 8516000,
                TimeZone = "GMT-3",
                NationalDay = "07/09",
                Language = "Portuguese",
                RightHandTraffic = true
            },

            new
            {
                CountryInfoId = 8,
                Population = 4886,
                Governance = "Unitary parliamentary constitutional monarchy",
                CapitalCity = "Wellington",
                BNP = 2049,
                Area = 268021,
                TimeZone = "GMT+12",
                NationalDay = "06/02",
                Language = "Maori/English",
                RightHandTraffic = false
            });

            modelBuilder.Entity<CityModel>()
                .HasData(new
                {
                    CityId = 1,
                    Name = "Kabul",
                    Population = 4222000,
                    CountryId = 1
                });

            modelBuilder.Entity<CityModel>()
                .HasData(new
                {
                    CityId = 2,
                    Name = "Balkh",
                    Population = 1382200,
                    CountryId = 1
                });

            modelBuilder.Entity<CityModel>()
                .HasData(new
                {
                    CityId = 3,
                    Name = "Kandahar",
                    Population = 614118,
                    CountryId = 1
                });

            modelBuilder.Entity<AttractionModel>()
                .HasData(new
                {
                    AttractionId = 1,
                    Name = "Buddha Niches",
                    Location = "Bamiyan Valley, west of Kabul",
                    Information = "The empty niches of the Buddha statues dominate the Bamiyan valley. Carved in the 6th century, the two statues, standing 38m and 55m respectively, were the tallest standing statues of Buddha ever made.",
                    IsChildFriendly = true,
                    Rating = 4,
                    CityId = 1
                });

            modelBuilder.Entity<AttractionModel>()
                .HasData(new
                {
                    AttractionId = 2,
                    Name = "Kabul Museum",
                    Location = "Kabul",
                    Information = "The Kabul Museum was once one of the greatest museums in the world. Its exhibits, ranging from Hellenistic gold coins to Buddhist statuary and Islamic bronzes, testified to Afghanistan’s location at the crossroads of Asia. After years of abuse during the civil war, help from the international community and the peerless dedication of its staff means the museum is slowly rising from the ashes. The museum opened in 1919, and was almost entirely stocked with items excavated in Afghanistan.",
                    IsChildFriendly = true,
                    Rating = 3,
                    CityId = 1
                });
        }
    }
}
