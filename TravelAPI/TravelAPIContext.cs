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
        private readonly IConfiguration _travelAPIContext;

        public TravelAPIContext() {}

        public TravelAPIContext (IConfiguration config, DbContextOptions options) : base(options)
        {
            _travelAPIContext = config;
        }

        public DbSet<CountryModel> CountryModel { get; set; }
        public DbSet<CountryInfoModel> CountryInfoModel { get; set; }
        public DbSet<AttractionModel> AttractionModel { get; set; }
        public DbSet<CityModel> CityModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_travelAPIContext.GetConnectionString("TravelAPIContext"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryModel>()
                .HasData(new
                {
                    CountryId = 1,
                    Name = "Afghanistan",
                    CountryInfo = 1,
                });

            modelBuilder.Entity<CountryInfoModel>()
                .HasData(new
                {
                    CountryInfoModelId = 1,
                    Population = 50000000,
                    Governance = "Islamic Republic",
                    CapitalCity = "Kabul",
                    BNP = 19360000000,
                    Area = 652000237,
                    TimeZone = "GMT+4:30",
                    NationalDay = 08 / 19,
                    Language = "Dari/Pashtu/Iranian",
                    RightHandTraffic = true,
                    Country = 1
                });

            modelBuilder.Entity<CityModel>()
                .HasData(new
                {
                    Name = "Kabul",
                    Population = 4222000000,
                    Country = 1
                });

            modelBuilder.Entity<CityModel>()
                .HasData(new
                {
                    Name = "Balkh",
                    Population = 1382200,
                    Country = 1
                });

            modelBuilder.Entity<CityModel>()
                .HasData(new
                {
                    Name = "Kandahar",
                    Population = 614118,
                    Country = 1
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
                    City = 1
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
                    City = 1
                });
        }
    }
}
