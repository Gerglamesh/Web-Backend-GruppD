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
        private readonly IConfiguration _configuration;
        public TravelAPIContext (IConfiguration config, DbContextOptions options) : base(options)
        {
            _configuration = config;
        }

        public DbSet<CountryModel> CountryModel { get; set; }
        public DbSet<CountryInfoModel> CountryInfoModel { get; set; }
        public DbSet<AttractionModel> AttractionModel { get; set; }
        public DbSet<CityModel> CityModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("TravelAPIContext"));
        }


    }
}
