using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    /// <summary>
    /// Seed data - seed datas is first test datas of the tables 
    /// </summary>
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, Name = "Books", CreatedDate = DateTime.Now },
                new Category { Id = 2, Name = "Wear", CreatedDate = DateTime.Now },
                new Category { Id = 3, Name = "Glases", CreatedDate = DateTime.Now },
                new Category { Id = 4, Name = "Electronics", CreatedDate = DateTime.Now });
        }
    }
}
