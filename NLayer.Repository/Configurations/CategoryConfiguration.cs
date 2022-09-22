﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);  
            builder.Property(x=>x.Id).UseIdentityColumn();  
            builder.Property(x=>x.Name).IsRequired();
            builder.Property(x=>x.CreatedDate).IsRequired();
            //builder.Property(x=>x.LastModifiedDate).IsRequired();

            builder.ToTable("Categories");
        }
    }
}
