using ECommerce.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infastructure.DbContexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {                
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductsDetails { get; set; }
    }
}
