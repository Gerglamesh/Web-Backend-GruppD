using Microsoft.EntityFrameworkCore;
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
        public DbSet<CountryInfoController> CountryInfoController { get; set; }
        public DbSet<CountryInfoModel> CountryInfoModel { get; set; }
    }
}
