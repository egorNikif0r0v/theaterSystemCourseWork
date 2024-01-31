using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Theater;

namespace DataBase
{


    public class Context : DbContext
    {
        private string _dbName;

        public DbSet<Theaterl> Theater { get; set; }
        public DbSet<Performance> Performance { get; set; }
        public DbSet<Place> Place { get; set; }
        public DbSet<Address> Adress { get; set; }
        public DbSet<ThSy> TheaterChain { get; set; }

        public Context() { }
        public Context(string dbName = "My")
        {
            _dbName = dbName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                $@"data source=(localdb)\MSSQLLocalDB;Initial Catalog={_dbName};Integrated Security=True;"
                );

        }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Theaterl>()
                .HasMany(t => t.Performances)
                .WithOne(s => s.Theater)
                .HasForeignKey(s => s.IdTheater);

            modelBuilder.Entity<Place>()
                .HasOne(s => s.Performances)
                .WithMany(se => se.Places_)
                .HasForeignKey(se => se.IdPerformance);

            modelBuilder.Entity<Theaterl>(table =>
            {
                table.HasOne(p => p.Address_)
                    .WithOne(i => i.Theater)
                    .HasForeignKey<Address>(c => c.IdTheater)
                    .HasPrincipalKey<Theaterl>(d => d.IdTheater);
            });
        }*/
    }

    public static class EntityExtensions
    {
        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
    }

}
