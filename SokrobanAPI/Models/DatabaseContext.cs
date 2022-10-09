using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SokrobanAPI.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SokLogin>(entity =>
            {
                entity.HasNoKey(); //This does have a key now, they all do
            });

            modelBuilder.Entity<SokLevel>(entity =>
            {
                entity.HasNoKey(); //This does have a key now, they all do
            });

            modelBuilder.Entity<SokStats>(entity =>
            {
                entity.HasNoKey(); //This does have a key now, they all do
            });
        }

        public DbSet<SokLogin> sokLogin { get; set; }
        public DbSet<SokLevel> sokLevel { get; set; }
        public DbSet<SokStats> SokStats { get; set; }

    } //e=mc2
}
