using ECommerce.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infastructure.DbContexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {                
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductDetail> ProductsDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<Category>().Property(B => B.Id).HasColumnType("tinyint").UseIdentityColumn();


            modelBuilder.Entity<Category>().Property(b => b.UId).ValueGeneratedOnAdd();  //UseIdentityColumn();
            modelBuilder.Entity<Category>().Property(b=>b.CreatedDate).HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Product>().Property(b => b.Price).HasPrecision(15, 4);
            modelBuilder.Entity<Product>().Property(b => b.CategoryId).HasColumnType("tinyint");

               


            base.OnModelCreating(modelBuilder);
        }

       
    }
}
