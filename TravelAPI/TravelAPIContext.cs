using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
using TravelAPI.Controller;
=======
>>>>>>> c27c810beabc2db4a3acc76c5cd81d0a00ff3e76
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
