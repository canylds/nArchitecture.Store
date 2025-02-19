using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
{
    public void Configure(EntityTypeBuilder<ProductVariant> builder)
    {
        builder.ToTable("ProductVariants").HasKey(pv => pv.Id);

        builder.Property(pv => pv.Id).HasColumnName("Id").IsRequired();
        builder.Property(pv => pv.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pv => pv.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pv => pv.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(pv => pv.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(pv => pv.ColorId).HasColumnName("ColorId").IsRequired();
        builder.Property(pv => pv.SizeId).HasColumnName("SizeId").IsRequired();
        builder.Property(pv => pv.UnitsInStock).HasColumnName("UnitsInStock").IsRequired();

        builder.HasOne(pv => pv.Product).WithMany(p => p.ProductVariants).HasForeignKey(pv => pv.ProductId);
        builder.HasOne(pv => pv.Color).WithMany(c => c.ProductVariants).HasForeignKey(pv => pv.ColorId);
        builder.HasOne(pv => pv.Size).WithMany(s => s.ProductVariants).HasForeignKey(pv => pv.SizeId);

        builder.HasQueryFilter(pv => !pv.DeletedDate.HasValue);
    }
}
