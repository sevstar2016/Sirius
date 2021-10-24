using System;
using BD.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieReviews.Database
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions<MarketContext> options) : base(options)
        {

        }

        public DbSet<Bouquet> bouquets { get; set; }
        public DbSet<Seller> sellers { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Purchase> purchases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bouquet>().ToTable("Bouquet");
            modelBuilder.Entity<Seller>().ToTable("Seller");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Purchase>().ToTable("Purchase");
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=test.db");
        }
    }
}