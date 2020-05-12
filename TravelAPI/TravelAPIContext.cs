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

        public DbSet<CountryModel> Countries { get; set; }
        public DbSet<CountryInfoModel> CountryInfo { get; set; }
        public DbSet<AttractionModel> Attractions { get; set; }
        public DbSet<CityModel> Cities { get; set; }
        public DbSet<TravelRestrictionModel> TravelRestrictions { get; set; }

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
                CountryInfoId = 1
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
                RiskLevel = 4,
                CountryId = 1
            });

            modelBuilder.Entity<CountryInfoModel>()
            .HasData(new
                {
                    CountryInfoId = 1,
                    Population = 50000000,
                    Governance = "Islamic Republic",
                    CapitalCity = "Kabul",
                    BNP = 19360,
                    Area = 652000237,
                    TimeZone = "GMT+4:30",
                    NationalDay = "19/8",
                    Language = "Dari/Pashtu/Iranian",
                    RightHandTraffic = true
                });

            modelBuilder.Entity<CityModel>()
                .HasData(new
                {
                    CityId = 1,
                    Name = "Kabul",
                    Population = 4222000000,
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
