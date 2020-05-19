using EngineClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
            },
            new
            {
                TravelRestrictionId = 2,
                IsWorkTravelAllowed = false,
                IsTourismAllowed = false,
                IsImmigrationAllowed = false,
                IsCitizenshipAllowed = false,
                IsFamilyVisitAllowed = false,
                IsVisaNeeded = true,
                RiskLevel = 4
            },
            new
            {
                TravelRestrictionId = 3,
                IsWorkTravelAllowed = false,
                IsTourismAllowed = false,
                IsImmigrationAllowed = false,
                IsCitizenshipAllowed = false,
                IsFamilyVisitAllowed = false,
                IsVisaNeeded = false,
                RiskLevel = 3
            },
            new
            {
                TravelRestrictionId = 4,
                IsWorkTravelAllowed = false,
                IsTourismAllowed = false,
                IsImmigrationAllowed = true,
                IsCitizenshipAllowed = false,
                IsFamilyVisitAllowed = false,
                IsVisaNeeded = true,
                RiskLevel = 2
            },
            new
            {
                TravelRestrictionId = 5,
                IsWorkTravelAllowed = true,
                IsTourismAllowed = true,
                IsImmigrationAllowed = true,
                IsCitizenshipAllowed = true,
                IsFamilyVisitAllowed = true,
                IsVisaNeeded = true,
                RiskLevel = 1
            },
            new
            {
                TravelRestrictionId = 6,
                IsWorkTravelAllowed = true,
                IsTourismAllowed = true,
                IsImmigrationAllowed = true,
                IsCitizenshipAllowed = true,
                IsFamilyVisitAllowed = true,
                IsVisaNeeded = true,
                RiskLevel = 3
            },
            new
            {
                TravelRestrictionId = 7,
                IsWorkTravelAllowed = true,
                IsTourismAllowed = true,
                IsImmigrationAllowed = true,
                IsCitizenshipAllowed = true,
                IsFamilyVisitAllowed = true,
                IsVisaNeeded = true,
                RiskLevel = 5
            },
            new
            {
                TravelRestrictionId = 8,
                IsWorkTravelAllowed = true,
                IsTourismAllowed = true,
                IsImmigrationAllowed = false,
                IsCitizenshipAllowed = true,
                IsFamilyVisitAllowed = false,
                IsVisaNeeded = false,
                RiskLevel = 2
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
                Population = 4221532,
                CountryId = 1
            },

            new
            {
                CityId = 2,
                Name = "Balkh",
                Population = 1382200,
                CountryId = 1
            },
            new
            {
                CityId = 3,
                Name = "Kandahar",
                Population = 614118,
                CountryId = 1
            },

            new
            {
                CityId = 4,
                Name = "Belgrade",
                Population = 1397939,
                CountryId = 2
            },

            new
            {
                CityId = 5,
                Name = "Novi Sad",
                Population = 289128,
                CountryId = 2
            },

            new
            {
                CityId = 6,
                Name = "Niš",
                Population = 185987,
                CountryId = 2
            },

            new
            {
                CityId = 7,
                Name = "Tokyo",
                Population = 37435191,
                CountryId = 3
            },

            new
            {
                CityId = 8,
                Name = "Yokohama",
                Population = 3725000,
                CountryId = 3
            },

            new
            {
                CityId = 9,
                Name = "Osaka",
                Population = 2691000,
                CountryId = 3
            },

            new
            {
                CityId = 10,
                Name = "Kampala",
                Population = 1680600,
                CountryId = 4
            },

            new
            {
                CityId = 11,
                Name = "Nansana",
                Population = 365124,
                CountryId = 4
            },

            new
            {
                CityId = 12,
                Name = "Kira",
                Population = 317157,
                CountryId = 4
            },

            new
            {
                CityId = 13,
                Name = "Bridgetown",
                Population = 110000,
                CountryId = 5
            },

            new
            {
                CityId = 14,
                Name = "Speightstown",
                Population = 3634,
                CountryId = 5
            },

            new
            {
                CityId = 15,
                Name = "Oistins",
                Population = 2285,
                CountryId = 5
            },

            new
            {
                CityId = 16,
                Name = "Ottawa",
                Population = 994837,
                CountryId = 6
            },

            new
            {
                CityId = 17,
                Name = "Toronto",
                Population = 2930000,
                CountryId = 6
            },

            new
            {
                CityId = 18,
                Name = "Montreal",
                Population = 1780000,
                CountryId = 6
            },

            new
            {
                CityId = 19,
                Name = "Brasilia",
                Population = 4645943,
                CountryId = 7
            },

            new
            {
                CityId = 20,
                Name = "São Paulo",
                Population = 21846507,
                CountryId = 7
            },

            new
            {
                CityId = 21,
                Name = "Rio de Janeiro",
                Population = 13458075,
                CountryId = 7
            },

            new
            {
                CityId = 22,
                Name = "Auckland",
                Population = 1657000,
                CountryId = 8
            },

            new
            {
                CityId = 23,
                Name = "Christchurch",
                Population = 381500,
                CountryId = 8
            },

            new
            {
                CityId = 24,
                Name = "Wellington",
                Population = 212700,
                CountryId = 8
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
