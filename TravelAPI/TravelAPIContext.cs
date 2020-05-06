using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI
{
    public class TravelAPIContext : DbContext
    {
        public DbSet<CountryModel> CountryModel { get; set; }
        public DbSet<CountryInfoModel> CountryInfoModel { get; set; }
        public DbSet<AttractionModel> AttractionModel { get; set; }
        public DbSet<CityModel> CityModel { get; set; }
    }
}
