using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entites;
using System.Reflection;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly(); 
            modelBuilder.ApplyConfigurationsFromAssembly(assembly); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
