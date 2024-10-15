using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(p => p.CategoryId).HasColumnName("CategoryId");
        builder.Property(p => p.Name).HasColumnName("Name").IsRequired();
        builder.Property(p => p.Description).HasColumnName("Description").IsRequired();
        builder.Property(p => p.UnitPrice).HasColumnName("UnitPrice").IsRequired();

        builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);

        builder.HasIndex(indexExpression: p => p.Name, name: "UK_Products_Name").IsUnique();

        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);

        builder.HasData(_seeds);
    }

    private IEnumerable<Product> _seeds
    {
        get
        {
            int id = 0;

            yield return new Product
            {
                Id = ++id,
                CreatedDate = DateTime.UtcNow,
                CategoryId = null,
                Name = "Asteroid Destroyer",
                Description = "This device is able to destroy asteroids.",
                UnitPrice = 50000000
            };

            yield return new Product
            {
                Id = ++id,
                CreatedDate = DateTime.UtcNow,
                CategoryId = 1,
                Name = "Mavi Ekose Gömlek",
                Description = string.Empty,
                UnitPrice = 900
            };
        }
    }
}