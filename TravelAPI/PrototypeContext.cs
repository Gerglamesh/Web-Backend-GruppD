using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EngineClasses;


namespace TravelAPI
{
    public class PrototypeContext : DbContext
    {
        public DbSet<PrototypeModel> PrototypeModel { get; set; }
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionSetup.GetConnectionString());
        }
     }
}
