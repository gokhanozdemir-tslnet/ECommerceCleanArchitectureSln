using ECommerce.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infastructure.DbContexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {                
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductDetail> ProductsDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(b => b.Price)
                .HasPrecision(15, 4);

            base.OnModelCreating(modelBuilder);
        }
    }
}
