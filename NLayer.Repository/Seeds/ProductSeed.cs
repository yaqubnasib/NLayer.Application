using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entites;

namespace NLayer.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                    new Product
                    {
                        Id = 1,
                        CategoryId = 1,
                        Name = "C# in Nutshell",
                        CreatedDate = DateTime.Now,
                        Stock = 100,
                        Price = 200
                    },
                    new Product
                    {
                        Id = 2,
                        CategoryId = 3,
                        Name = "Ray-Ban",
                        CreatedDate = DateTime.Now,
                        Stock = 50,
                        Price = 350
                    },
                    new Product
                    {
                        Id = 3,
                        CategoryId = 2,
                        Name = "Adidas",
                        CreatedDate = DateTime.Now,
                        Stock = 10,
                        Price = 150
                    },
                    new Product
                    {
                        Id = 4,
                        CategoryId = 4,
                        Name = "HP Envy",
                        CreatedDate = DateTime.Now,
                        Stock = 10,
                        Price = 1500
                    }
                );
        }
    }
}
