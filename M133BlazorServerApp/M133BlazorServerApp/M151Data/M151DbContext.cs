using Microsoft.EntityFrameworkCore;
using System;

namespace M133BlazorServerApp.M151Data
{
    public class M151DbContext : DbContext
    {
        public DbSet<GameUser> GameUsers { get; set; }
        public DbSet<GameChampion> GameChampions { get; set; }
        public DbSet<Head> Head { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(ApplicationSettings.AppOptions.DatabaseConnectionString); 
        }
    }
}
