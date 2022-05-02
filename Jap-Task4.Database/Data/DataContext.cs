using Jap_Task4.Core.Entities;
using Jap_Task4.Database.DataSeed;
using Microsoft.EntityFrameworkCore;

namespace Jap_Task4.Database.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Offer> Offers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Offer>()
            .Property(b => b.CreatedDate)
            .HasDefaultValueSql("getdate()");
            modelBuilder
                .Entity<Product>()
                .Property(b => b.CreatedDate)
                .HasDefaultValueSql("getdate()");
            modelBuilder
                .Entity<Coupon>()
                .Property(b => b.CreatedDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Offers();
            modelBuilder.Products();
            modelBuilder.Coupons();
        }
    }
}