using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EngineClasses


namespace TravelAPI
{
    public class FakeContext : DbContext
    {
        public DbSet<Session> Session { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<GamePiece> GamePiece { get; set; }
        public DbSet<GameLog> GameLog { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionSetup.GetConnectionString());
        }
     }
}
