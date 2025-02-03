using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SizeConfiguration : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> builder)
    {
        builder.ToTable("Sizes").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(s => s.Name).HasColumnName("Name").IsRequired();

        builder.HasMany(s => s.ProductVariants).WithOne(pv => pv.Size).HasForeignKey(pv => pv.SizeId);

        builder.HasIndex(indexExpression: s => s.Name, name: "UK_Sizes_Name").IsUnique();

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
    }
}