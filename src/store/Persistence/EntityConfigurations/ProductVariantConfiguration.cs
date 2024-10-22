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
        builder.Property(pv => pv.CreatedDate).HasColumnName("Id").IsRequired();
        builder.Property(pv => pv.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pv => pv.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(pv => pv.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(pv => pv.ColorId).HasColumnName("ColorId").IsRequired();
        builder.Property(pv => pv.SizeId).HasColumnName("SizeId").IsRequired();
        builder.Property(pv => pv.UnitsInStock).HasColumnName("UnitsInStock").IsRequired();

        builder.HasOne(pv => pv.Product).WithMany(p => p.ProductVariants).HasForeignKey(pv => pv.ProductId);
        builder.HasOne(pv => pv.Color).WithMany(c => c.ProductVariants).HasForeignKey(pv => pv.ProductId);
        builder.HasOne(pv => pv.Size).WithMany(s => s.ProductVariants).HasForeignKey(pv => pv.ProductId);

        builder.HasQueryFilter(pv => !pv.DeletedDate.HasValue);
    }

    private IEnumerable<ProductVariant> _seeds
    {
        get
        {
            int id = 0;

            yield return new ProductVariant(id: ++id, productId: 2, colorId: 1, sizeId: 1, unitsInStock: 10);

            yield return new ProductVariant(id: ++id, productId: 2, colorId: 2, sizeId: 2, unitsInStock: 15);

            yield return new ProductVariant(id: ++id, productId: 2, colorId: 2, sizeId: 3, unitsInStock: 20);
        }
    }
}
