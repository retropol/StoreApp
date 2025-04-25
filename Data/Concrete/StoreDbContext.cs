using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Concrete
{




    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products => Set<Product>();

        public DbSet<Category> Categories => Set<Category>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
           .HasMany(e => e.Categories)
           .WithMany(e => e.Products)
           .UsingEntity<ProductCategory>();  // bu kod otonmatik oluşturulur yazmasak bile. çoka çok ilişkiyi sağlar. eğer özel bir ayar yapacaksak bu kodu yazıp üzerinde değişiklik yaparız.


            modelBuilder.Entity<Category>()
                .HasIndex(e => e.Url)
                .IsUnique();

            modelBuilder.Entity<Product>().HasData(

                new List<Product>()
                {
                    new() { Id = 1, Name = "Samsung s24", Price = 4000, Description = "iyi telefon",  },
                    new() { Id = 2, Name = "Samsung s25", Price = 20300, Description = "iyi telefon",  },
                    new() { Id = 3, Name = "Samsung s26", Price = 50300, Description = "iyi telefon",  },
                }
                );

            modelBuilder.Entity<Category>().HasData(
                new List<Category>()
                {
                    new() { Id = 1, Name = "Telefon", Url = "telefon" },
                    new() { Id = 2, Name = "Bilgisayar", Url = "bilgisayar" },
                    new() { Id = 3, Name = "Elektronik", Url = "elektronik" },
                }
                );


            

            modelBuilder.Entity<ProductCategory>().
                HasData(
                new List<ProductCategory>() {

                    new ProductCategory() {ProductId = 1, CategoryId = 1},
                    new ProductCategory() {ProductId = 2, CategoryId = 2},
                    new ProductCategory() {ProductId = 3, CategoryId = 3},
                   

                    }
                );
        }




    }
}
