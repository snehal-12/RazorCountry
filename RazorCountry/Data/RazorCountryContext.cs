using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorCountry.Models;

namespace RazorCountry.Data
{
    public class RazorCountryContext : DbContext
    {
        public RazorCountryContext (DbContextOptions<RazorCountryContext> options)
            : base(options)
        {
        }

        public DbSet<RazorCountry.Models.Continent> Continents { get; set; }

        public DbSet<RazorCountry.Models.Country> Countries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Continent>().ToTable("Continent");
            modelBuilder.Entity<Country>().ToTable("Country");
           
        }
    }
}
