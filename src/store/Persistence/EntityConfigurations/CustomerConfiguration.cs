﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(c => c.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(c => c.Address).HasColumnName("Address").IsRequired();
        builder.Property(c => c.City).HasColumnName("City").IsRequired();
        builder.Property(c => c.Region).HasColumnName("Region").IsRequired();
        builder.Property(c => c.PostalCode).HasColumnName("PostalCode").IsRequired();
        builder.Property(c => c.Country).HasColumnName("Country").IsRequired();
        builder.Property(c => c.Phone).HasColumnName("Phone").IsRequired();

        builder.HasOne(c => c.User).WithOne(u => u.Customer).HasForeignKey<Customer>(c => c.UserId);

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}
