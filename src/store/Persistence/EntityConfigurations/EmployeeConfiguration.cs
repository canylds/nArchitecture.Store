using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(e => e.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(e => e.Title).HasColumnName("Title").IsRequired();
        builder.Property(e => e.BirthDate).HasColumnName("BirthDate").IsRequired();
        builder.Property(e => e.HireDate).HasColumnName("HireDate").IsRequired();
        builder.Property(e => e.Address).HasColumnName("Address").IsRequired();
        builder.Property(e => e.City).HasColumnName("City").IsRequired();
        builder.Property(e => e.Region).HasColumnName("Region").IsRequired();
        builder.Property(e => e.PostalCode).HasColumnName("PostalCode").IsRequired();
        builder.Property(e => e.Country).HasColumnName("Country").IsRequired();
        builder.Property(e => e.Phone).HasColumnName("Phone").IsRequired();
        builder.Property(e => e.PhotoUrl).HasColumnName("PhotoUrl").IsRequired();

        builder.HasOne(e => e.User).WithOne(u => u.Employee).HasForeignKey<Employee>(e => e.UserId);

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
    }
}
