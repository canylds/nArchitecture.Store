﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.ToTable("Colors").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(c => c.Name).HasColumnName("Name").IsRequired();

        builder.HasMany(c => c.ProductVariants).WithOne(pv => pv.Color).HasForeignKey(pv => pv.ColorId);

        builder.HasIndex(indexExpression: c => c.Name, name: "UK_Colors_Name").IsUnique();

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}
